using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Al clickear el botón 'btnOperar', se declarán dos objetos del tipo Numero,
        /// llamando al constructor que recibe un string por parámetro. Dicho string corresponderá
        /// al texto ingresado en los textBox txtNumero1 y txtNumero2. Luego se le asignará
        /// al texto del label 'lblResultado' el valor devuelto por metodo 'operar', de la clase Calculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero num1 = new Numero(txtNumero1.Text.ToString());
            Numero num2 = new Numero(txtNumero2.Text.ToString());

            lblResultado.Text = operar(num1, num2, cmbOperacion.Text.ToString()).ToString();


        }
        /// <summary>
        /// Al clickear sobre el botón btnLimpiar, el texto de los textBoxs y del label 
        /// será '0', y el del cmbOperacion será " ". 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            lblResultado.Text = "0";
            cmbOperacion.Text = " ";
        }
    }
}
