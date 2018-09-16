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
        #region Atributos
        private Button btnCerrar;
        private Button btnLimpiar;
        private Button btnConvertirABinario;
        private Button btnConvertirADecimal;
        private Button btnOperar;
        private ComboBox cmbOperador;
        private Label lblResultado;
        private TextBox txtNumero1;
        private TextBox txtNumero2;
        #endregion

        public LaCalculadora()
        {
            InitializeComponent();

            this.btnLimpiar = _btnLimpiar;
            this.btnCerrar = _btnCerrar;
            this.btnOperar = _btnOperar;
            this.btnConvertirABinario = _btnBinario;
            this.btnConvertirADecimal = _btnDecimal;
            this.cmbOperador = _cmbOperar;
            this.txtNumero1 = textNum1;
            this.txtNumero2 = textNum2;
            this.lblResultado = label2;

            //Inicializamos las dos cajas de texto en 0
            this.txtNumero1.Text = "0";
            this.txtNumero2.Text = "0";

            //Agregamos los operandos en el comboBox
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDown;
            string[] arrayOperador = { "+", "-", "*", "/" };
            for(int i = 0; i < arrayOperador.GetLength(0); i++)
            {
                this.cmbOperador.Items.Add(arrayOperador.GetValue(i));
            }
            this.cmbOperador.Items.Add("Selecciona");
            this.cmbOperador.SelectedItem = "Selecciona";
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;

            //Quitamos el boton minimizar y agrandar.
            this.MaximizeBox = false; 
            this.MinimizeBox = false;

            //Centramos el formulario.
            this.StartPosition = FormStartPosition.CenterScreen;

            //Anulamos las operaciones de conversion
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Metodo que llama al metodo Operar y muestra el valor recibido de dicho metodo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
            btnOperar.DialogResult = DialogResult.OK;
            this.btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Metodo que borra los valores que muestra TextBox, ComboBox y Label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach(Control item in this.Controls)
            {
                if(item is TextBox || item is ComboBox || item is Label)
                {
                    item.Text = "";
                    btnLimpiar.DialogResult = DialogResult.OK;
                }
            }
            if(btnLimpiar.DialogResult == DialogResult.OK)
            {
                this.txtNumero1.Text = "0";
                this.txtNumero2.Text = "0";
                this.btnConvertirABinario.Enabled = false;
                this.btnConvertirADecimal.Enabled = false;
                this.cmbOperador.SelectedItem = "Selecciona";
            }
        }

        /// <summary>
        /// Metodo que crea dos objetos de tipo Numero y se les pasa valores. luego retorna el metodo Operar.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            return Calculadora.Operar(n1, n2, operador);
        }

        /// <summary>
        /// Metodo que cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo que llama al metodo DecimalBinario y muestra el valor de dicho metodo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnBinario_Click(object sender, EventArgs e)
        {
            if(btnOperar.DialogResult == DialogResult.OK)
            {
                this.btnConvertirADecimal.Enabled = true;
                string resultado = Numero.DecimalBinario(lblResultado.Text);
                lblResultado.Text = resultado;
                btnConvertirABinario.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Metodo que llama al metodo BinarioDecimal y muestra el valor de dicho metodo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnDecimal_Click(object sender, EventArgs e)
        {
            if (btnConvertirABinario.DialogResult == DialogResult.OK)
            {
                string resultado = Numero.BinarioDecimal(lblResultado.Text).ToString();
                lblResultado.Text = resultado;
                btnConvertirADecimal.DialogResult = DialogResult.OK;
            }
        }

        private void _cmbOperar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LaCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void textNum1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
