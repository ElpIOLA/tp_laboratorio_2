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

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();

            //Agregamos los operandos en el comboBox
            string[] arrayOperador = { "+", "-", "*", "/" };

            for (int i = 0; i < arrayOperador.GetLength(0); i++)
            {
                this.cmbOperador.Items.Add(arrayOperador.GetValue(i));
            }
            this.cmbOperador.SelectedItem = "+";

            //Quitamos el boton minimizar y agrandar.
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //Centramos el formulario.
            this.StartPosition = FormStartPosition.CenterScreen;

            //Bloqueamos los botones de conversiones hasta que el usuario haga una operacion.
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        #region Botones
        /// <summary>
        /// Boton que invoca el metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        
        /// <summary>
        /// Boton que invoca el metodo Operar y muestra el resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString());
            lblResultado.Text = resultado.ToString();

            //Habilitamos la conversion a Binario
            btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Este boton verifica que alla un resultado decimal y despues lo convierte a Binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero(lblResultado.Text);
            string resultado = "";
            if(!(string.IsNullOrEmpty(lblResultado.Text)))
            {
                resultado = numero.DecimalBinario(lblResultado.Text);
                lblResultado.Text = resultado;

                //Habilitamos la conversion a Decimal y inhabilitamos la conversion a Binario
                btnConvertirADecimal.Enabled = true;
                btnConvertirABinario.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        /// <summary>
        /// Este boton verifica que alla un resultado binario y despues lo convierte a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero(lblResultado.Text);
            string resultado = "";
            if (!(string.IsNullOrEmpty(lblResultado.Text)))
            {
                resultado = numero.BinarioDecimal(lblResultado.Text);
                lblResultado.Text = resultado;

                //Habilitamos la conversion a Binario y inhabilitamos la conversion a Decimal
                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que limpia los textBox, comboBox y label.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.SelectedItem = "+";
            lblResultado.Text = "";

            //Volvemos a inhabilitar los botones de conversion hasta que el usuario vuelva hacer una operacion.
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Este método invoca el metodo estatico de Calculadora y retorna el resultado.
        /// </summary>
        /// <param name="numero1">Variable de tipo string, primer numero.</param>
        /// <param name="numero2">Variable de tipo string, segundo numero.</param>
        /// <param name="operador">Operador elegido por el usuario.</param>
        /// <returns>Variable double.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado = 0;
            if(!(object.ReferenceEquals(numero1,null)) && !(object.ReferenceEquals(numero2, null)))
            {
                resultado = Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
            }
            return resultado;
        }
        #endregion
    }
}
