using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace TP1
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);

            if(cmbOperador.Text == "")
            {
                lblResultado.Text = "Ingresar operador.";
                //cmbOperador.Text = "+";
            }
            else
            {
                lblResultado.Text = Calculadora.Operar(numero1, numero2, cmbOperador.Text).ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
            cmbOperador.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(!(lblResultado.Text.Equals("0")) && double.TryParse(lblResultado.Text, out double num))
            {
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!(lblResultado.Text.Equals("0")))
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            }

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }
    }
}
