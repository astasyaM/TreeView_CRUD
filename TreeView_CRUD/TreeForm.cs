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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
                        var node = new TreeNodeID(dr["Type"].ToString(), (int)dr["TypeID"]);
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
                        var node = new TreeNodeID(dr["Title"].ToString(), (int)dr["EventID"]);
                        node.ContextMenuStrip = ctmEvents;
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
                    var cmdUpdate = new MySqlCommand(@"UPDATE `volunteers` SET `Name`=@name,`Surname`=@surname WHERE VOLUNTEERS.VolunteerID = @ID", con);


                    cmdUpdate.Parameters.AddWithValue("@name", frm.VolunteerName);
                    cmdUpdate.Parameters.AddWithValue("@surname", frm.VolunteerSurname);
                    cmdUpdate.Parameters.AddWithValue("@ID", node.ID);

                    cmdUpdate.ExecuteNonQuery();

                    node.Text = $"{frm.VolunteerName[0]}. {frm.VolunteerSurname}";
                }
            }

            
        }

        private void tsmУдалитьVolunteer_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;

            TreeNodeID node = treeView.SelectedNode as TreeNodeID;
            if (node == null)
            {
                MessageBox.Show("Выберите волонтёра из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var con = new MySqlConnection(cs))
            {
                con.Open();
                var cmd = new MySqlCommand(@"DELETE FROM `volunteers` WHERE volunteers.VolunteerID = @volunteerID", con);

                cmd.Parameters.AddWithValue("@volunteerID", node.ID);

                cmd.ExecuteNonQuery();

                node.Remove();
            }
        }

        private void tsmДобавитьVolunteer_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;
            var frm = new EditVolunteerForm();

            TreeNodeID node = treeView.SelectedNode as TreeNodeID;
            if (node == null)
            {
                MessageBox.Show("Выберите волонтёра из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TreeNodeID nodeParent = treeView.SelectedNode.Parent as TreeNodeID;

            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var cmdUpdate = new MySqlCommand(@"INSERT INTO `volunteers`(`EventID`, `Name`, `Surname`) VALUES (@eventID, @name, @surname)", con);

                    cmdUpdate.Parameters.AddWithValue("@name", frm.VolunteerName);
                    cmdUpdate.Parameters.AddWithValue("@surname", frm.VolunteerSurname);
                    cmdUpdate.Parameters.AddWithValue("@eventID", nodeParent.ID);

                    cmdUpdate.ExecuteNonQuery();

                    var cmd = new MySqlCommand(@"SELECT CONCAT(LEFT(Name, 1), '. ', Surname) AS FullName, volunteers.VolunteerID FROM `volunteers` ORDER BY VolunteerID DESC LIMIT 1", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var newNode = new TreeNodeID(dr["FullName"].ToString(), (int)dr["VolunteerID"]);
                            newNode.ContextMenuStrip = ctmVolunteer;
                            nodeParent.Nodes.Add(newNode);
                        }
                    }
                }
            }
        }

        private void tsmУдалитьEvents_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;

            TreeNodeID node = treeView.SelectedNode as TreeNodeID;
            if (node == null)
            {
                MessageBox.Show("Выберите событие из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var con = new MySqlConnection(cs))
            {
                con.Open();
                var cmd = new MySqlCommand(@"DELETE FROM `volunteers` WHERE volunteers.EventID = @eventID", con);

                cmd.Parameters.AddWithValue("@eventID", node.ID);

                cmd.ExecuteNonQuery();

                node.Remove();
            }
        }
    }
}
