using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArchiveHelper
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (!Login()){
                MessageBox.Show("用户名或口令不正确。");
                return ;
            }
            this.Hide();
            MainForm f = new MainForm();
            f.Show();
        }

        private bool Login()
        {
            List<string> list = new List<string>();
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand sql_cmd = conn.CreateCommand();
                sql_cmd.CommandText = string.Format("select * from User where name='{0}' and password='{1}'", Username.Text, Password.Text);
                SQLiteDataReader dr = sql_cmd.ExecuteReader();
                bool avild = dr.HasRows;
                if (avild && dr.Read())
                {
                    User user = new User() { Id = dr.GetInt16(0), Name = dr.GetString(1), Password = dr.GetString(2), RealName = dr.GetString(3), Unit = dr.GetString(4), RoleType = dr.GetInt16(5) };
                    Authority.Init(user);
                }
                conn.Close();
                return avild;
            }
        }
    }
}
