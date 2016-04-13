﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library___Login
{
    public partial class Users : Form
    {
        public Users(string username, string password)
        {
            InitializeComponent();
            ErrorMessage.Visible = false;
            Connect2DB con = new Connect2DB();
            int userId = con.FindUser(username, password);

            UserAllName.Text = con.getUserAllName(userId);
            if (UserAllName.Text == null)
            {
                ErrorMessage.Visible = true;
            }
            else
            {
                UserAge.Text = "Age: " + con.getUserAge(userId);
            }
        }
    }
}