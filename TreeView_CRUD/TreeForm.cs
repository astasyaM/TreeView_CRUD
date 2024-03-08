using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView_CRUD
{
    public partial class TreeForm : Form
    {
        public TreeForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;

            using (var con = new MySqlConnection(cs))
            {
                con.Open();
                var cmd = new MySqlCommand(@"SELECT * FROM `types`", con);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var node = new TreeNode(dr["Type"].ToString());
                        node.ContextMenuStrip = ctmType;
                        treeView.Nodes.Add(node);
                        LoadEvents(node, (int)dr["TypeID"]);
                    }
                }
            }

        }

        void LoadEvents(TreeNode parent, int typeID)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;

            using (var con = new MySqlConnection(cs))
            {
                con.Open();
                var cmd = new MySqlCommand(@"SELECT * FROM `events` WHERE EVENTS.EventTypeID = @typeID", con);

                cmd.Parameters.AddWithValue("@typeID", typeID);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var node = new TreeNode(dr["Title"].ToString());
                        parent.Nodes.Add(node);
                        LoadVolunteers(node, (int)dr["EventID"]);
                    }
                }
            }
        }

        void LoadVolunteers(TreeNode parent, int eventID)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;

            using (var con = new MySqlConnection(cs))
            {
                con.Open();
                var cmd = new MySqlCommand(@"SELECT CONCAT(LEFT(Name, 1), '. ', Surname) AS FullName, volunteers.VolunteerID FROM volunteers WHERE VOLUNTEERS.EventID = @eventID", con);

                cmd.Parameters.AddWithValue("@eventID", eventID);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var node = new TreeNodeID(dr["FullName"].ToString(), (int)dr["VolunteerID"]);
                        node.ContextMenuStrip = ctmVolunteer;
                        parent.Nodes.Add(node);
                    }
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;

            int id = 0;

            using (var con = new MySqlConnection(cs))
            {
                con.Open();
                var cmd = new MySqlCommand(@"DELETE FROM `types` WHERE types.TypeID = @typeID", con);

                cmd.Parameters.AddWithValue("@typeID", id);

                cmd.ExecuteNonQuery();
            }
        }

        private void tsiИзменитьВолонтёра_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;
            var frm = new EditVolunteerForm();

            TreeNodeID node = treeView.SelectedNode as TreeNodeID;
            if (node == null)
            {
                MessageBox.Show("Выберите волонтёра из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                var query = "SELECT * FROM volunteers WHERE VolunteerID = @ID";
                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", node.ID);

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            frm.VolunteerName = dr["Name"].ToString();
                            frm.VolunteerSurname = dr["Surname"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Волонтёр не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
            }

            
        }

    }
}
