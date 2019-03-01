using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Practica_TreeView
{
    public partial class TreeView_form : Form
    {
        //Aquí hay que obtener Diccionario de otra clase
        IDictionary <string, List<string>> dict = new Dictionary <string, List<string>>()
        {
            { "Item 1", new List<string> {"Value 1", "Value 2", "Value 3"} },
            { "Item 2", new List<string> {"Value 1"} },
            { "Item 3", new List<string> {"Value 1", "Value 2"} }
        };

        //Llenamos el TreeView al Iniciar y Escogemos Elemento Seleccionado
        public TreeView_form()
        {
            InitializeComponent();
            foreach (var elemento in dict)
            {
                TreeNode item = new TreeNode(elemento.Key);
                treeView1.Nodes.Add(item);
                foreach (string value in elemento.Value)
                {
                    TreeNode val = new TreeNode(value);
                    item.Nodes.Add(val);
                }
            }
        }
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = treeView1.SelectedNode.Parent != null ? textBox1.Text = treeView1.SelectedNode.Parent.Text + ": " + treeView1.SelectedNode.Text : textBox1.Text = treeView1.SelectedNode.Text;
        }
    }
}
