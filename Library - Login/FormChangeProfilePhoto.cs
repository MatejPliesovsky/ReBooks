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
    /// <summary>
    /// form for change user's profile image
    /// </summary>
    public partial class FormChangeProfilePhoto : Form
    {
        private string userID, image;
        private Connect2DB connect;

        public FormChangeProfilePhoto(string userID)
        {
            InitializeComponent();
            this.userID = userID;
            connect = new Connect2DB();
            image = this.txtImagePath.Text;

            ProfilePictureBox.Image = Image.FromStream(new System.IO.MemoryStream(connect.getUserProfileImage(userID)));
            ProfilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ProfilePictureBox.Refresh();
        }

        /// <summary>
        /// call method for saving image to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            image = txtImagePath.Text;
            if (connect.uploadUserImage(image, userID))
            {
                DatabaseInfo.Text = "Profile image was changed.";
                timer1.Interval = 5000;
                timer1.Tick += new EventHandler(Timer1_Tick);
                DatabaseInfo.Visible = true;
                timer1.Start();
            }
            else
            {
                DatabaseInfo.Text = "Cannot upload profile image.\nTry again later.";
                timer1.Interval = 5000;
                timer1.Tick += new EventHandler(Timer1_Tick);
                DatabaseInfo.Visible = true;
                timer1.Start();
            }
        }

        /// <summary>
        /// button which call method for uploading image to form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog imgSrc = new OpenFileDialog();
            imgSrc.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (imgSrc.ShowDialog() == DialogResult.OK)
            {
                string src = imgSrc.FileName.ToString();
                txtImagePath.Text = src;
                ProfilePictureBox.ImageLocation = src;
            }
        }

        private void Upload_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save_Click(Upload, null);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DatabaseInfo.Visible = false;
            timer1.Stop();
        }
    }
}
