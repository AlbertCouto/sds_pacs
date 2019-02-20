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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NaveForm));
            this.console_Log = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btn_Conectar = new System.Windows.Forms.PictureBox();
            this.btn_Mensaje = new System.Windows.Forms.PictureBox();
            this.btn_DevolverFichero = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer2 = new RepublicSystemClasses.Timer();
            this.timer1 = new RepublicSystemClasses.Timer();
            this.timer3 = new RepublicSystemClasses.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Conectar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Mensaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_DevolverFichero)).BeginInit();
            this.SuspendLayout();
            // 
            // console_Log
            // 
            this.console_Log.BackColor = System.Drawing.Color.Black;
            this.console_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console_Log.ForeColor = System.Drawing.Color.White;
            this.console_Log.Location = new System.Drawing.Point(768, 1);
            this.console_Log.Name = "console_Log";
            this.console_Log.ReadOnly = true;
            this.console_Log.Size = new System.Drawing.Size(331, 569);
            this.console_Log.TabIndex = 5;
            this.console_Log.Text = "";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(575, 667);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 24);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "zip";
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Title = "Seleccione fichero ZIP a descifrar:";
            // 
            // btn_Conectar
            // 
            this.btn_Conectar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Conectar.BackgroundImage = global::NaveForm.Properties.Resources._58afdad6829958a978a4a693;
            this.btn_Conectar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Conectar.Location = new System.Drawing.Point(106, 68);
            this.btn_Conectar.Name = "btn_Conectar";
            this.btn_Conectar.Size = new System.Drawing.Size(100, 100);
            this.btn_Conectar.TabIndex = 9;
            this.btn_Conectar.TabStop = false;
            this.btn_Conectar.Click += new System.EventHandler(this.btn_Conectar_Click);
            // 
            // btn_Mensaje
            // 
            this.btn_Mensaje.BackColor = System.Drawing.Color.Transparent;
            this.btn_Mensaje.BackgroundImage = global::NaveForm.Properties.Resources._58afdad6829958a978a4a693;
            this.btn_Mensaje.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Mensaje.Location = new System.Drawing.Point(106, 259);
            this.btn_Mensaje.Name = "btn_Mensaje";
            this.btn_Mensaje.Size = new System.Drawing.Size(100, 100);
            this.btn_Mensaje.TabIndex = 10;
            this.btn_Mensaje.TabStop = false;
            this.btn_Mensaje.Click += new System.EventHandler(this.btn_Mensaje_Click);
            // 
            // btn_DevolverFichero
            // 
            this.btn_DevolverFichero.BackColor = System.Drawing.Color.Transparent;
            this.btn_DevolverFichero.BackgroundImage = global::NaveForm.Properties.Resources._58afdad6829958a978a4a693;
            this.btn_DevolverFichero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DevolverFichero.Location = new System.Drawing.Point(106, 457);
            this.btn_DevolverFichero.Name = "btn_DevolverFichero";
            this.btn_DevolverFichero.Size = new System.Drawing.Size(100, 100);
            this.btn_DevolverFichero.TabIndex = 11;
            this.btn_DevolverFichero.TabStop = false;
            this.btn_DevolverFichero.Click += new System.EventHandler(this.btn_DevolverFicheroClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(125, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Verificar conexión";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(125, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Enviar Código";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(125, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Devolver Fichero";
            // 
            // timer2
            // 
            this.timer2.BackColor = System.Drawing.Color.Transparent;
            this.timer2.Location = new System.Drawing.Point(475, 364);
            this.timer2.Name = "timer2";
            this.timer2.Size = new System.Drawing.Size(142, 65);
            this.timer2.TabIndex = 15;
            // 
            // timer1
            // 
            this.timer1.BackColor = System.Drawing.Color.Transparent;
            this.timer1.Location = new System.Drawing.Point(710, 629);
            this.timer1.Name = "timer1";
            this.timer1.Size = new System.Drawing.Size(159, 62);
            this.timer1.TabIndex = 6;
            this.timer1.Visible = false;
            // 
            // timer3
            // 
            this.timer3.BackColor = System.Drawing.Color.Transparent;
            this.timer3.Location = new System.Drawing.Point(313, 329);
            this.timer3.Name = "timer3";
            this.timer3.Size = new System.Drawing.Size(449, 228);
            this.timer3.TabIndex = 16;
            // 
            // NaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1099, 571);
            this.Controls.Add(this.timer3);
            this.Controls.Add(this.timer2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_DevolverFichero);
            this.Controls.Add(this.btn_Mensaje);
            this.Controls.Add(this.btn_Conectar);
            this.Controls.Add(this.timer1);
            this.Controls.Add(this.console_Log);
            this.Controls.Add(this.button4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NaveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.NaveForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Conectar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Mensaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_DevolverFichero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox console_Log;
        private RepublicSystemClasses.Timer timer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox btn_Conectar;
        private System.Windows.Forms.PictureBox btn_Mensaje;
        private System.Windows.Forms.PictureBox btn_DevolverFichero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private RepublicSystemClasses.Timer timer2;
        private RepublicSystemClasses.Timer timer3;
    }
}

