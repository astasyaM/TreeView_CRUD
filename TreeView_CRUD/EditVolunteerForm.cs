using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView_CRUD
{
    public partial class EditVolunteerForm : Form
    {
        public EditVolunteerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        public string VolunteerName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public string VolunteerSurname
        {
            get { return txtSurname.Text; }
            set { txtSurname.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
