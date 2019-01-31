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
            this.timer1 = new RepublicSystemClasses.Timer();
            this.consoleLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Btn_encender
            // 
            this.Btn_encender.Location = new System.Drawing.Point(181, 126);
            this.Btn_encender.Name = "Btn_encender";
            this.Btn_encender.Size = new System.Drawing.Size(90, 76);
            this.Btn_encender.TabIndex = 0;
            this.Btn_encender.Text = "Encender Servidor";
            this.Btn_encender.UseVisualStyleBackColor = true;
            this.Btn_encender.Click += new System.EventHandler(this.Btn_encender_Click);
            // 
            // Btn_Apagar
            // 
            this.Btn_Apagar.Location = new System.Drawing.Point(307, 125);
            this.Btn_Apagar.Name = "Btn_Apagar";
            this.Btn_Apagar.Size = new System.Drawing.Size(88, 78);
            this.Btn_Apagar.TabIndex = 1;
            this.Btn_Apagar.Text = "Apagar Servidor";
            this.Btn_Apagar.UseVisualStyleBackColor = true;
            this.Btn_Apagar.Click += new System.EventHandler(this.Btn_Apagar_Click);
            // 
            // timer1
            // 
            this.timer1.Location = new System.Drawing.Point(199, 274);
            this.timer1.Name = "timer1";
            this.timer1.Size = new System.Drawing.Size(142, 65);
            this.timer1.TabIndex = 2;
            // 
            // consoleLog
            // 
            this.consoleLog.BackColor = System.Drawing.Color.Black;
            this.consoleLog.Location = new System.Drawing.Point(459, 96);
            this.consoleLog.Name = "consoleLog";
            this.consoleLog.Size = new System.Drawing.Size(314, 341);
            this.consoleLog.TabIndex = 3;
            this.consoleLog.Text = "";
            // 
            // PlanetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 536);
            this.Controls.Add(this.consoleLog);
            this.Controls.Add(this.timer1);
            this.Controls.Add(this.Btn_Apagar);
            this.Controls.Add(this.Btn_encender);
            this.Name = "PlanetForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PlanetForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_encender;
        private System.Windows.Forms.Button Btn_Apagar;
        private RepublicSystemClasses.Timer timer1;
        private System.Windows.Forms.RichTextBox consoleLog;
    }
}

