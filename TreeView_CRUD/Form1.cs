using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView_CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
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
                var cmd = new MySqlCommand(@"SELECT CONCAT(LEFT(Name, 1), '. ', Surname) AS FullName FROM volunteers WHERE VOLUNTEERS.EventID = @eventID", con);

                cmd.Parameters.AddWithValue("@eventID", eventID);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var node = new TreeNode(dr["FullName"].ToString());
                        parent.Nodes.Add(node);
                    }
                }
            }
        }
    }
}
