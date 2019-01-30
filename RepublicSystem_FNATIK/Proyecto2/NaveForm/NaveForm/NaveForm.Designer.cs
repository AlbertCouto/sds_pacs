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
            this.btn_Mensaje = new System.Windows.Forms.Button();
            this.console_Log = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.Titulo = new System.Windows.Forms.Label();
            this.btn_DevolverFichero = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new RepublicSystemClasses.Timer();
            this.SuspendLayout();
            // 
            // btn_Conectar
            // 
            this.btn_Conectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Conectar.Location = new System.Drawing.Point(46, 128);
            this.btn_Conectar.Name = "btn_Conectar";
            this.btn_Conectar.Size = new System.Drawing.Size(96, 78);
            this.btn_Conectar.TabIndex = 0;
            this.btn_Conectar.Text = "Verificar Conexión";
            this.btn_Conectar.UseVisualStyleBackColor = true;
            this.btn_Conectar.Click += new System.EventHandler(this.btn_Conectar_Click);
            // 
            // btn_Mensaje
            // 
            this.btn_Mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Mensaje.Location = new System.Drawing.Point(189, 128);
            this.btn_Mensaje.Name = "btn_Mensaje";
            this.btn_Mensaje.Size = new System.Drawing.Size(96, 80);
            this.btn_Mensaje.TabIndex = 1;
            this.btn_Mensaje.Text = "Enviar Código";
            this.btn_Mensaje.UseVisualStyleBackColor = true;
            this.btn_Mensaje.Click += new System.EventHandler(this.btn_Mensaje_Click);
            // 
            // console_Log
            // 
            this.console_Log.BackColor = System.Drawing.Color.Black;
            this.console_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console_Log.ForeColor = System.Drawing.Color.White;
            this.console_Log.Location = new System.Drawing.Point(474, 32);
            this.console_Log.Name = "console_Log";
            this.console_Log.ReadOnly = true;
            this.console_Log.Size = new System.Drawing.Size(314, 341);
            this.console_Log.TabIndex = 5;
            this.console_Log.Text = "";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(308, 306);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 24);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Titulo
            // 
            this.Titulo.AutoEllipsis = true;
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.Location = new System.Drawing.Point(69, 32);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(321, 33);
            this.Titulo.TabIndex = 7;
            this.Titulo.Text = "Spacefighter Software";
            // 
            // btn_DevolverFichero
            // 
            this.btn_DevolverFichero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DevolverFichero.Location = new System.Drawing.Point(329, 127);
            this.btn_DevolverFichero.Name = "btn_DevolverFichero";
            this.btn_DevolverFichero.Size = new System.Drawing.Size(96, 80);
            this.btn_DevolverFichero.TabIndex = 8;
            this.btn_DevolverFichero.Text = "Devolver Fichero";
            this.btn_DevolverFichero.UseVisualStyleBackColor = true;
            this.btn_DevolverFichero.Click += new System.EventHandler(this.btn_DevolverFicheroClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "zip";
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Title = "Seleccione fichero ZIP a descifrar:";
            // 
            // timer1
            // 
            this.timer1.Location = new System.Drawing.Point(22, 311);
            this.timer1.Name = "timer1";
            this.timer1.Size = new System.Drawing.Size(159, 62);
            this.timer1.TabIndex = 6;
            this.timer1.Visible = false;
            // 
            // NaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 392);
            this.Controls.Add(this.btn_DevolverFichero);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.timer1);
            this.Controls.Add(this.console_Log);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_Mensaje);
            this.Controls.Add(this.btn_Conectar);
            this.Name = "NaveForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.NaveForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Conectar;
        private System.Windows.Forms.Button btn_Mensaje;
        private System.Windows.Forms.RichTextBox console_Log;
        private RepublicSystemClasses.Timer timer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Button btn_DevolverFichero;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

