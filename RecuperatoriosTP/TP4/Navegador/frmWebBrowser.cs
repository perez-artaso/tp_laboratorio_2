using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Archivos;
using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Texto archivos;

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }
        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmHistorial().ShowDialog();
        }

        private void btnIr_Click(object sender, EventArgs e)
        {
            //Si la dirección no contiene el protocolo, se agrega al principio de la URL.
            if(!(txtUrl.Text.StartsWith ("https://")) && !(txtUrl.Text.StartsWith("http://")))
            {
                string aux = txtUrl.Text;
                txtUrl.Text = "http://" + aux;
            }

            try
            {

                Descargador nuevaDescarga = new Descargador(new Uri(txtUrl.Text));
                

                //Suscribo el método que se encarga de asignar el valor recibido por la función del WebClient.
                nuevaDescarga.avisarQueTerminoDescarga += FinDescarga;
                //Y suscribo el método que se encarga de asignar el porcentaje de descarga a la barra de progreso.
                nuevaDescarga.avisarValorDeProgreso += ProgresoDescarga;

                //Declaro un hilo para la descarga.
                Thread hiloDeDescarga = new Thread(nuevaDescarga.IniciarDescarga);
                //Y lo inicializo. Esto desencadena la secuencia de llamados a delegados y sus correspondientes métodos. 
                hiloDeDescarga.Start();

                //Guardo la dirección ingresada en el historial.
                archivos = new Texto("historico.dat");
                archivos.guardar(txtUrl.Text);

                
            }
            catch(System.UriFormatException ex)
            {
                this.FinDescarga("¡ERROR! El URL ingresado contiene caracteres no válidos. Revíselo.");
            }
            





        }

       
    }
}
