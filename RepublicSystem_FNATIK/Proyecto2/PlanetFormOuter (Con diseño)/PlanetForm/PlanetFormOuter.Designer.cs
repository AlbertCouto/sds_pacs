namespace PlanetForm
{
    partial class PlanetFormOuter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanetFormOuter));
            this.console_Log = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEncender = new System.Windows.Forms.PictureBox();
            this.lbl_Encender = new System.Windows.Forms.Label();
            this.lblApagar = new System.Windows.Forms.Label();
            this.btnApagarServer = new System.Windows.Forms.PictureBox();
            this.timer1 = new RepublicSystemClasses.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEncender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApagarServer)).BeginInit();
            this.SuspendLayout();
            // 
            // console_Log
            // 
            this.console_Log.BackColor = System.Drawing.Color.Black;
            this.console_Log.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.console_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console_Log.ForeColor = System.Drawing.Color.White;
            this.console_Log.Location = new System.Drawing.Point(770, -2);
            this.console_Log.Name = "console_Log";
            this.console_Log.ReadOnly = true;
            this.console_Log.Size = new System.Drawing.Size(331, 561);
            this.console_Log.TabIndex = 5;
            this.console_Log.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 388);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnEncender
            // 
            this.btnEncender.BackColor = System.Drawing.Color.Transparent;
            this.btnEncender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEncender.Image = global::PlanetForm.Properties.Resources.red_button;
            this.btnEncender.Location = new System.Drawing.Point(105, 67);
            this.btnEncender.Name = "btnEncender";
            this.btnEncender.Size = new System.Drawing.Size(100, 100);
            this.btnEncender.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEncender.TabIndex = 5;
            this.btnEncender.TabStop = false;
            this.btnEncender.Click += new System.EventHandler(this.btnEncender_Click);
            this.btnEncender.MouseHover += new System.EventHandler(this.btnEncender_MouseHover);
            // 
            // lbl_Encender
            // 
            this.lbl_Encender.AutoSize = true;
            this.lbl_Encender.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Encender.Font = new System.Drawing.Font("Microsoft Tai Le", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Encender.ForeColor = System.Drawing.Color.White;
            this.lbl_Encender.Location = new System.Drawing.Point(126, 31);
            this.lbl_Encender.Name = "lbl_Encender";
            this.lbl_Encender.Size = new System.Drawing.Size(71, 13);
            this.lbl_Encender.TabIndex = 6;
            this.lbl_Encender.Text = "Encender Server";
            // 
            // lblApagar
            // 
            this.lblApagar.AutoSize = true;
            this.lblApagar.BackColor = System.Drawing.Color.Transparent;
            this.lblApagar.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApagar.ForeColor = System.Drawing.Color.White;
            this.lblApagar.Location = new System.Drawing.Point(126, 220);
            this.lblApagar.Name = "lblApagar";
            this.lblApagar.Size = new System.Drawing.Size(78, 14);
            this.lblApagar.TabIndex = 7;
            this.lblApagar.Text = "Apagar Server";
            // 
            // btnApagarServer
            // 
            this.btnApagarServer.BackColor = System.Drawing.Color.Transparent;
            this.btnApagarServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnApagarServer.Image = global::PlanetForm.Properties.Resources.red_button;
            this.btnApagarServer.Location = new System.Drawing.Point(105, 257);
            this.btnApagarServer.Name = "btnApagarServer";
            this.btnApagarServer.Size = new System.Drawing.Size(100, 100);
            this.btnApagarServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnApagarServer.TabIndex = 8;
            this.btnApagarServer.TabStop = false;
            this.btnApagarServer.Click += new System.EventHandler(this.btnApagarServer_Click);
            // 
            // timer1
            // 
            this.timer1.BackColor = System.Drawing.Color.Transparent;
            this.timer1.Location = new System.Drawing.Point(315, 331);
            this.timer1.Name = "timer1";
            this.timer1.Size = new System.Drawing.Size(449, 228);
            this.timer1.TabIndex = 9;
            this.timer1.Visible = false;
            // 
            // PlanetFormOuter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1099, 571);
            this.Controls.Add(this.timer1);
            this.Controls.Add(this.btnApagarServer);
            this.Controls.Add(this.lblApagar);
            this.Controls.Add(this.lbl_Encender);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.console_Log);
            this.Controls.Add(this.btnEncender);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlanetFormOuter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planet";
            this.Load += new System.EventHandler(this.PlanetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEncender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApagarServer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox console_Log;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnEncender;
        private System.Windows.Forms.Label lbl_Encender;
        private System.Windows.Forms.Label lblApagar;
        private System.Windows.Forms.PictureBox btnApagarServer;
        private RepublicSystemClasses.Timer timer1;
    }
}

