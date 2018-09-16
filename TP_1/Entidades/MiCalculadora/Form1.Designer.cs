namespace MiCalculadora
{
    partial class LaCalculadora
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer _components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_components != null))
            {
                _components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaCalculadora));
            this.textNum1 = new System.Windows.Forms.TextBox();
            this.textNum2 = new System.Windows.Forms.TextBox();
            this._btnOperar = new System.Windows.Forms.Button();
            this._btnLimpiar = new System.Windows.Forms.Button();
            this._btnCerrar = new System.Windows.Forms.Button();
            this._btnBinario = new System.Windows.Forms.Button();
            this._btnDecimal = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._cmbOperar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textNum1
            // 
            this.textNum1.Location = new System.Drawing.Point(16, 89);
            this.textNum1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textNum1.Name = "textNum1";
            this.textNum1.Size = new System.Drawing.Size(248, 22);
            this.textNum1.TabIndex = 0;
            this.textNum1.TextChanged += new System.EventHandler(this.textNum1_TextChanged);
            // 
            // textNum2
            // 
            this.textNum2.Location = new System.Drawing.Point(531, 89);
            this.textNum2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textNum2.Name = "textNum2";
            this.textNum2.Size = new System.Drawing.Size(248, 22);
            this.textNum2.TabIndex = 1;
            // 
            // _btnOperar
            // 
            this._btnOperar.Location = new System.Drawing.Point(16, 150);
            this._btnOperar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._btnOperar.Name = "_btnOperar";
            this._btnOperar.Size = new System.Drawing.Size(249, 60);
            this._btnOperar.TabIndex = 2;
            this._btnOperar.Text = "Operar";
            this._btnOperar.UseVisualStyleBackColor = true;
            this._btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
            // 
            // _btnLimpiar
            // 
            this._btnLimpiar.Location = new System.Drawing.Point(273, 150);
            this._btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._btnLimpiar.Name = "_btnLimpiar";
            this._btnLimpiar.Size = new System.Drawing.Size(249, 60);
            this._btnLimpiar.TabIndex = 3;
            this._btnLimpiar.Text = "Limpiar";
            this._btnLimpiar.UseVisualStyleBackColor = true;
            this._btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // _btnCerrar
            // 
            this._btnCerrar.Location = new System.Drawing.Point(531, 150);
            this._btnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._btnCerrar.Name = "_btnCerrar";
            this._btnCerrar.Size = new System.Drawing.Size(249, 60);
            this._btnCerrar.TabIndex = 4;
            this._btnCerrar.Text = "Cerrar";
            this._btnCerrar.UseVisualStyleBackColor = true;
            this._btnCerrar.Click += new System.EventHandler(this._btnCerrar_Click);
            // 
            // _btnBinario
            // 
            this._btnBinario.Location = new System.Drawing.Point(144, 218);
            this._btnBinario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._btnBinario.Name = "_btnBinario";
            this._btnBinario.Size = new System.Drawing.Size(249, 60);
            this._btnBinario.TabIndex = 5;
            this._btnBinario.Text = "Convertir a Binario";
            this._btnBinario.UseVisualStyleBackColor = true;
            this._btnBinario.Click += new System.EventHandler(this._btnBinario_Click);
            // 
            // _btnDecimal
            // 
            this._btnDecimal.Location = new System.Drawing.Point(401, 218);
            this._btnDecimal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._btnDecimal.Name = "_btnDecimal";
            this._btnDecimal.Size = new System.Drawing.Size(249, 60);
            this._btnDecimal.TabIndex = 6;
            this._btnDecimal.Text = "Convertir a Decimal";
            this._btnDecimal.UseVisualStyleBackColor = true;
            this._btnDecimal.Click += new System.EventHandler(this._btnDecimal_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(733, 33);
            this.labelResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 17);
            this.labelResult.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1364, 318);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // _cmbOperar
            // 
            this._cmbOperar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this._cmbOperar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbOperar.FormattingEnabled = true;
            this._cmbOperar.IntegralHeight = false;
            this._cmbOperar.Location = new System.Drawing.Point(273, 87);
            this._cmbOperar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._cmbOperar.Name = "_cmbOperar";
            this._cmbOperar.Size = new System.Drawing.Size(248, 28);
            this._cmbOperar.TabIndex = 10;
            this._cmbOperar.SelectedIndexChanged += new System.EventHandler(this._cmbOperar_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(660, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "Resultado";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // LaCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(807, 294);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cmbOperar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this._btnDecimal);
            this.Controls.Add(this._btnBinario);
            this.Controls.Add(this._btnCerrar);
            this.Controls.Add(this._btnLimpiar);
            this.Controls.Add(this._btnOperar);
            this.Controls.Add(this.textNum2);
            this.Controls.Add(this.textNum1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LaCalculadora";
            this.Text = "Calculadora de Hernán Franco del curso 2°A";
            this.Load += new System.EventHandler(this.LaCalculadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textNum1;
        private System.Windows.Forms.TextBox textNum2;
        private System.Windows.Forms.Button _btnOperar;
        private System.Windows.Forms.Button _btnLimpiar;
        private System.Windows.Forms.Button _btnCerrar;
        private System.Windows.Forms.Button _btnBinario;
        private System.Windows.Forms.Button _btnDecimal;
        
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _cmbOperar;
        private System.Windows.Forms.Label label2;
    }
}

