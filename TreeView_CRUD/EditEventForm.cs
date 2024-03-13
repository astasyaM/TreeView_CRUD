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
    public partial class EditEventForm : Form
    {
        public string EventTitle
        {
            get { return txtTitle.Text; }
            set { txtTitle.Text = value; }
        }

        public string EventDescription
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public EditEventForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text!=String.Empty && txtDescription.Text!=String.Empty)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }

        }
    }
}
