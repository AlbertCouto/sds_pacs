namespace NaveForm
{
    partial class NaveForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.btn_Conectar = new System.Windows.Forms.Button();
            this.btn_Archivo = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.console_Log = new System.Windows.Forms.RichTextBox();
            this.timer1 = new RepublicSystemClasses.Timer();
            this.SuspendLayout();
            // 
            // btn_Conectar
            // 
            this.btn_Conectar.Location = new System.Drawing.Point(136, 125);
            this.btn_Conectar.Name = "btn_Conectar";
            this.btn_Conectar.Size = new System.Drawing.Size(96, 24);
            this.btn_Conectar.TabIndex = 0;
            this.btn_Conectar.Text = "Conectar";
            this.btn_Conectar.UseVisualStyleBackColor = true;
            this.btn_Conectar.Click += new System.EventHandler(this.btn_Conectar_Click);
            // 
            // btn_Archivo
            // 
            this.btn_Archivo.Location = new System.Drawing.Point(268, 125);
            this.btn_Archivo.Name = "btn_Archivo";
            this.btn_Archivo.Size = new System.Drawing.Size(96, 24);
            this.btn_Archivo.TabIndex = 1;
            this.btn_Archivo.Text = "Enviar archivo";
            this.btn_Archivo.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(494, 295);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 24);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // console_Log
            // 
            this.console_Log.BackColor = System.Drawing.Color.Black;
            this.console_Log.ForeColor = System.Drawing.Color.White;
            this.console_Log.Location = new System.Drawing.Point(84, 248);
            this.console_Log.Name = "console_Log";
            this.console_Log.ReadOnly = true;
            this.console_Log.Size = new System.Drawing.Size(324, 153);
            this.console_Log.TabIndex = 5;
            this.console_Log.Text = "";
            // 
            // timer1
            // 
            this.timer1.Location = new System.Drawing.Point(524, 212);
            this.timer1.Name = "timer1";
            this.timer1.Size = new System.Drawing.Size(159, 62);
            this.timer1.TabIndex = 6;
            this.timer1.Visible = false;
            // 
            // NaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.timer1);
            this.Controls.Add(this.console_Log);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_Archivo);
            this.Controls.Add(this.btn_Conectar);
            this.Name = "NaveForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Conectar;
        private System.Windows.Forms.Button btn_Archivo;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox console_Log;
        private RepublicSystemClasses.Timer timer1;
    }
}

