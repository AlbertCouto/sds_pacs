namespace PlanetForm
{
    partial class PlanetForm
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
            this.Btn_encender = new System.Windows.Forms.Button();
            this.Btn_Apagar = new System.Windows.Forms.Button();
            this.console_Log = new System.Windows.Forms.RichTextBox();
            this.timer1 = new RepublicSystemClasses.Timer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_encender
            // 
            this.Btn_encender.Location = new System.Drawing.Point(107, 81);
            this.Btn_encender.Name = "Btn_encender";
            this.Btn_encender.Size = new System.Drawing.Size(90, 76);
            this.Btn_encender.TabIndex = 0;
            this.Btn_encender.Text = "Encender Servidor";
            this.Btn_encender.UseVisualStyleBackColor = true;
            this.Btn_encender.Click += new System.EventHandler(this.Btn_encender_Click);
            // 
            // Btn_Apagar
            // 
            this.Btn_Apagar.Location = new System.Drawing.Point(109, 270);
            this.Btn_Apagar.Name = "Btn_Apagar";
            this.Btn_Apagar.Size = new System.Drawing.Size(88, 78);
            this.Btn_Apagar.TabIndex = 1;
            this.Btn_Apagar.Text = "Apagar Servidor";
            this.Btn_Apagar.UseVisualStyleBackColor = true;
            this.Btn_Apagar.Click += new System.EventHandler(this.Btn_Apagar_Click);
            // 
            // console_Log
            // 
            this.console_Log.BackColor = System.Drawing.Color.Black;
            this.console_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console_Log.Location = new System.Drawing.Point(770, -2);
            this.console_Log.Name = "console_Log";
            this.console_Log.Size = new System.Drawing.Size(331, 573);
            this.console_Log.TabIndex = 3;
            this.console_Log.Text = "";
            // 
            // timer1
            // 
            this.timer1.Location = new System.Drawing.Point(463, 417);
            this.timer1.Name = "timer1";
            this.timer1.Size = new System.Drawing.Size(142, 65);
            this.timer1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::PlanetForm.Properties.Resources.Radar_Red;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 381);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // PlanetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PlanetForm.Properties.Resources.F25;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1099, 571);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.console_Log);
            this.Controls.Add(this.timer1);
            this.Controls.Add(this.Btn_Apagar);
            this.Controls.Add(this.Btn_encender);
            this.Name = "PlanetForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PlanetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_encender;
        private System.Windows.Forms.Button Btn_Apagar;
        private RepublicSystemClasses.Timer timer1;
        private System.Windows.Forms.RichTextBox console_Log;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

