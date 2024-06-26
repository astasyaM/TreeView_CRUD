﻿using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TreeView_CRUD;
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
                        var node = new TreeNodeID(dr["Type"].ToString(), (int)dr["TypeID"], 1);
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
                        var node = new TreeNodeID(dr["Title"].ToString(), (int)dr["EventID"], 2);
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
                        var node = new TreeNodeID(dr["FullName"].ToString(), (int)dr["VolunteerID"], 3);
                        node.ContextMenuStrip = ctmVolunteer;
                        parent.Nodes.Add(node);
                    }
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;

            TreeNodeID node = treeView.SelectedNode as TreeNodeID;
            if (node == null)
            {
                MessageBox.Show("Выберите тип события из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var con = new MySqlConnection(cs))
            {
                con.Open();
                var cmd = new MySqlCommand(@"DELETE FROM `types` WHERE types.TypeID = @typeID", con);

                cmd.Parameters.AddWithValue("@typeID", node.ID);

                cmd.ExecuteNonQuery();

                node.Remove();
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
                            var newNode = new TreeNodeID(dr["FullName"].ToString(), (int)dr["VolunteerID"], 3);
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
                var cmd = new MySqlCommand(@"DELETE FROM `events` WHERE events.EventID = @eventID", con);

                cmd.Parameters.AddWithValue("@eventID", node.ID);

                cmd.ExecuteNonQuery();

                node.Remove();
            }
        }

        private void tsmИзменитьEvents_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;
            var frm = new EditEventForm();

            TreeNodeID node = treeView.SelectedNode as TreeNodeID;
            if (node == null)
            {
                MessageBox.Show("Выберите событие из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                var query = "SELECT * FROM events WHERE EventID = @ID";
                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", node.ID);

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            frm.EventTitle = dr["Title"].ToString();
                            frm.EventDescription = dr["Description"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Событие не найдено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var cmdUpdate = new MySqlCommand(@"UPDATE `events` SET `Title`=@title,`Description`=@description WHERE EVENTS.EventID = @ID", con);


                    cmdUpdate.Parameters.AddWithValue("@title", frm.EventTitle);
                    cmdUpdate.Parameters.AddWithValue("@description", frm.EventDescription);
                    cmdUpdate.Parameters.AddWithValue("@ID", node.ID);

                    cmdUpdate.ExecuteNonQuery();

                    node.Text = $"{frm.EventTitle}";
                }
            }
        }

        private void tsmДобавитьEvents_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;
            var frm = new EditEventForm();

            TreeNodeID node = treeView.SelectedNode as TreeNodeID;
            if (node == null)
            {
                MessageBox.Show("Выберите событие из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TreeNodeID nodeParent = treeView.SelectedNode.Parent as TreeNodeID;

            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var cmdUpdate = new MySqlCommand(@"INSERT INTO `Events`(`EventTypeID`, `Title`, `Description`) VALUES (@eventTypeID, @title, @description)", con);

                    cmdUpdate.Parameters.AddWithValue("@title", frm.EventTitle);
                    cmdUpdate.Parameters.AddWithValue("@description", frm.EventDescription);
                    cmdUpdate.Parameters.AddWithValue("@eventTypeID", nodeParent.ID);

                    cmdUpdate.ExecuteNonQuery();

                    var cmd = new MySqlCommand(@"SELECT events.Title, events.EventID FROM `events` ORDER BY EventID DESC LIMIT 1", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var newNode = new TreeNodeID(dr["Title"].ToString(), (int)dr["EventID"], 2);
                            newNode.ContextMenuStrip = ctmEvents;
                            nodeParent.Nodes.Add(newNode);
                        }
                    }
                }
            }
        }

        private void tsmДобавитьType_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;
            var frm = new EditTypeForm();

            TreeNodeID node = treeView.SelectedNode as TreeNodeID;
            if (node == null)
            {
                MessageBox.Show("Выберите тип мероприятия из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TreeNodeID nodeParent = treeView.SelectedNode.Parent as TreeNodeID;

            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var cmdUpdate = new MySqlCommand(@"INSERT INTO `Types`(`Type`) VALUES (@type)", con);

                    cmdUpdate.Parameters.AddWithValue("@type", frm.TypeTitle);

                    cmdUpdate.ExecuteNonQuery();

                    var cmd = new MySqlCommand(@"SELECT types.Type, types.TypeID FROM `types` ORDER BY TypeID DESC LIMIT 1", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var newNode = new TreeNodeID(dr["Type"].ToString(), (int)dr["typeID"], 1);
                            newNode.ContextMenuStrip = ctmType;
                            treeView.Nodes.Add(newNode);
                        }
                    }
                }
            }
        }

        private void tsmИзменитьTypes_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;
            var frm = new EditTypeForm();

            TreeNodeID node = treeView.SelectedNode as TreeNodeID;
            if (node == null)
            {
                MessageBox.Show("Выберите тип событий из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                var query = "SELECT * FROM types WHERE TypeID = @ID";
                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", node.ID);

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            frm.TypeTitle = dr["Type"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Тип события не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var cmdUpdate = new MySqlCommand(@"UPDATE `types` SET `Type`=@type WHERE TYPES.TypeID = @ID", con);


                    cmdUpdate.Parameters.AddWithValue("@type", frm.TypeTitle);
                    cmdUpdate.Parameters.AddWithValue("@ID", node.ID);

                    cmdUpdate.ExecuteNonQuery();

                    node.Text = $"{frm.TypeTitle}";
                }
            }
        }

        private void добавитьСобытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;
            var frm = new EditEventForm();

            TreeNodeID node = treeView.SelectedNode as TreeNodeID;
            if (node == null)
            {
                MessageBox.Show("Выберите тип событий из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var cmdUpdate = new MySqlCommand(@"INSERT INTO `Events`(`EventTypeID`, `Title`, `Description`) VALUES (@eventTypeID, @title, @description)", con);

                    cmdUpdate.Parameters.AddWithValue("@title", frm.EventTitle);
                    cmdUpdate.Parameters.AddWithValue("@description", frm.EventDescription);
                    cmdUpdate.Parameters.AddWithValue("@eventTypeID", node.ID);

                    cmdUpdate.ExecuteNonQuery();

                    var cmd = new MySqlCommand(@"SELECT events.Title, events.EventID FROM `events` ORDER BY EventID DESC LIMIT 1", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var newNode = new TreeNodeID(dr["Title"].ToString(), (int)dr["EventID"], 2);
                            newNode.ContextMenuStrip = ctmEvents;
                            node.Nodes.Add(newNode);
                        }
                    }
                }
            }
        }

        private void добавитьВолонтёраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;
            var frm = new EditVolunteerForm();

            TreeNodeID node = treeView.SelectedNode as TreeNodeID;
            if (node == null)
            {
                MessageBox.Show("Выберите событие из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var cmdUpdate = new MySqlCommand(@"INSERT INTO `volunteers`(`EventID`, `Name`, `Surname`) VALUES (@eventID, @name, @surname)", con);

                    cmdUpdate.Parameters.AddWithValue("@name", frm.VolunteerName);
                    cmdUpdate.Parameters.AddWithValue("@surname", frm.VolunteerSurname);
                    cmdUpdate.Parameters.AddWithValue("@eventID", node.ID);

                    cmdUpdate.ExecuteNonQuery();

                    var cmd = new MySqlCommand(@"SELECT CONCAT(LEFT(Name, 1), '. ', Surname) AS FullName, volunteers.VolunteerID FROM `volunteers` ORDER BY VolunteerID DESC LIMIT 1", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var newNode = new TreeNodeID(dr["FullName"].ToString(), (int)dr["VolunteerID"], 3);
                            newNode.ContextMenuStrip = ctmVolunteer;
                            node.Nodes.Add(newNode);
                        }
                    }
                }
            }
        }

        private void treeView_ItemDrag_1(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2 == null || node2.Parent == null)
                return false;
            if (node2.Parent.Equals(node1))
                return true;
            return ContainsNode(node1, node2.Parent);
        }

        private void treeView_DragDrop_1(object sender, DragEventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["Volunteers"].ConnectionString;

            TreeNodeID draggedNode = (TreeNodeID)e.Data.GetData(typeof(TreeNodeID));
            Point targetPoint = treeView.PointToClient(new Point(e.X, e.Y));
            TreeNodeID targetNode = (TreeNodeID)treeView.GetNodeAt(targetPoint);

            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode) && draggedNode.NodeLevel == 3)
            {
                draggedNode.Remove();

                if (targetNode == null)
                    treeView.Nodes.Add(draggedNode);
                else
                    targetNode.Nodes.Add(draggedNode);
                targetNode.Expand();

                using (var con = new MySqlConnection(cs))
                {
                    con.Open();

                    if (draggedNode.NodeLevel == 3)
                    {
                        var cmdUpdate = new MySqlCommand(@"UPDATE `volunteers` SET `EventID`=@idEvent WHERE volunteers.VolunteerID = @IDVolunteer", con);
                        cmdUpdate.Parameters.AddWithValue("@idEvent", targetNode.ID);
                        cmdUpdate.Parameters.AddWithValue("@IDVolunteer", draggedNode.ID);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView.SelectedNode = e.Node;
        }
    }
}
