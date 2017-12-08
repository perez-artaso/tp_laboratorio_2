using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net; // Avisar del espacio de nombre (¿Qué?)
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public string Html { get => html; set => html = value; }

        //Esto venía mal. Cuando inicializo mi obejto, aun no realicé la descarga.
        //No puedo asignarle nada a html. Además, dado que recibe un parámetro de tipo Uri,
        //la asignación debe realizarse en el atributo "direccion". 
        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
            this.avisarQueTerminoDescarga += AsignadorDeAtributoHtml;
        }

        //Este método se va a tener que ejecutar cuando se toque el botón Ir del formulario. 
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(direccion);
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Estos son los métodos que lanzan los eventos. Por eso los suscribí al manejador de eventos
        //de mi objeto WebClient, para que cuando a) Se produzca una transferencia exitosa de datos
        //se llame a la función WebClientDowloadProgressChanged y ésta le avise a la barra de progreso
        //que debe cambiar b) La descarga se complete, le avise al delegado correspondiente que informe
        //de esto a la función del browser encargada de asignar el html descargado al formulario. 

        //Ahora necesito un delegado cuya firma coincida con la del método del browser FinDeDescarga, 
        //así puedo suscribirlo al manejador de eventos de aquel y llamarlo desde el método WebClientDownloadCompleted()
       //que va a ser llamado por el manejador del evento que indica que la descarga finalizó (DownloadStringCompleted),
      //y así, cuando la descarga finalice, FinDeDescarga va a asignarle el html descargado al richTextBox del formulario. 

        public delegate void delegadoParaFinDeDescarga(string html);
        public event delegadoParaFinDeDescarga avisarQueTerminoDescarga;

        //Y ahora hago lo mismo para el método que se encarga de la barra de progreso (ProgresoDescarga(int progreso)).

        public delegate void delegadoParaProgresoDescarga(int progreso);
        public event delegadoParaProgresoDescarga avisarValorDeProgreso;


        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //La propiedad ProgressPercentage de la clase DownloadProgressChangedEventArgs devuelve un int
            //que representa el porcentaje de datos descargados. 
            this.avisarValorDeProgreso(e.ProgressPercentage);
        }

        //Cuando la descarga finaliza, el delegado DownloadStringCompletedEventHandler hace un llamado a este método.
        //Este método invoca al manejador del delegado al que está subscripto el método FinDescarga() del browser. 
        
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //Como parámetro le envío el resultado de la descarga, obtenido pero la propiedad Result de la clase 
            //DownloadStringCompletedEventArgs. 
            try
            {
                this.avisarQueTerminoDescarga(e.Result);
            }
            catch(System.Reflection.TargetInvocationException ex)
            {
                this.avisarQueTerminoDescarga("¡ LA PÁGINA WEB NO EXISTE !");
            }
        }

        //Cuando la descarga finaliza, el delegado DownloadStringCOmpletedEventHandler hace un llamado a este método.
        //La suscripción fue realizada en el constructor. 

        //Es totalmente innecesario, pero lo hice para jugar un poco con el delegado, ya que el atributo no tiene utilidad
        //en este programa. 
        
        public void AsignadorDeAtributoHtml(string html)
        {
            this.html = html;
        }
    }
}
