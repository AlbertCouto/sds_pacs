namespace Practica_TreeView
{
    partial class TreeView_form
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label_treeview = new System.Windows.Forms.Label();
            this.label_titulo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_seleccionado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(71, 122);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(294, 301);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // label_treeview
            // 
            this.label_treeview.AutoSize = true;
            this.label_treeview.Location = new System.Drawing.Point(68, 88);
            this.label_treeview.Name = "label_treeview";
            this.label_treeview.Size = new System.Drawing.Size(88, 13);
            this.label_treeview.TabIndex = 1;
            this.label_treeview.Text = "Escoja elemento:";
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titulo.Location = new System.Drawing.Point(285, 25);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(234, 29);
            this.label_titulo.TabIndex = 2;
            this.label_titulo.Text = "Práctica Tree View";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(503, 249);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label_seleccionado
            // 
            this.label_seleccionado.AutoSize = true;
            this.label_seleccionado.Location = new System.Drawing.Point(423, 252);
            this.label_seleccionado.Name = "label_seleccionado";
            this.label_seleccionado.Size = new System.Drawing.Size(54, 13);
            this.label_seleccionado.TabIndex = 5;
            this.label_seleccionado.Text = "Elemento:";
            // 
            // TreeView_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_seleccionado);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_titulo);
            this.Controls.Add(this.label_treeview);
            this.Controls.Add(this.treeView1);
            this.Name = "TreeView_form";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label_treeview;
        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_seleccionado;
    }
}

