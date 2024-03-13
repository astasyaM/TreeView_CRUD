using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TreeView_CRUD
{
    public partial class EditTypeForm : Form
    {
        public string TypeTitle
        {
            get { return txtType.Text; }
            set { txtType.Text = value; }
        }

        public EditTypeForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtType.Text != string.Empty)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Заполните все поля!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
