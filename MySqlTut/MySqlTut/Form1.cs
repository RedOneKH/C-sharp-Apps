using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySqlTut
{
    public partial class Form1 : Form
    {

        private User currUser;

        public Form1()
        {
            InitializeComponent();
            User.InitializeDB();
        }

        private void LoadAll()
        {
            List<User> users = User.GetUsers();

            lvUsers.Items.Clear();

            foreach (User u in users)
            {

                ListViewItem item = new ListViewItem(new String[] { u.Id.ToString(), u.Username, u.Password });
                item.Tag = u;

                lvUsers.Items.Add(item);

            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                ListViewItem item = lvUsers.SelectedItems[0];
                currUser = (User)item.Tag;

                int id = currUser.Id;
                String u = currUser.Username;
                String p = currUser.Password;

                txtUsername.Text = u;
                txtId.Text = id.ToString();
                txtPassword.Text = p;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            String u = txtUsername.Text;
            String p = txtPassword.Text;

            if (String.IsNullOrEmpty(u) || String.IsNullOrEmpty(p))
            {
                MessageBox.Show("It's empty");
                return;
            }

            currUser = User.Insert(u, p);

            LoadAll();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String u = txtUsername.Text;
            String p = txtPassword.Text;

            if (String.IsNullOrEmpty(u) || String.IsNullOrEmpty(p))
            {
                MessageBox.Show("It's empty");
                return;
            }

            currUser.Update(u, p);

            LoadAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currUser == null)
            {
                MessageBox.Show("No user selected!");
                return;
            }

            currUser.Delete();

            LoadAll();
        }
    }
}
