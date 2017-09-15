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

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero num1 = new Numero(txtNumero1.Text.ToString());
            Numero num2 = new Numero(txtNumero2.Text.ToString());

            lblResultado.Text = operar(num1, num2, cmbOperacion.Text.ToString()).ToString();


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            lblResultado.Text = "0";
            cmbOperacion.Text = " ";
        }
    }
}
