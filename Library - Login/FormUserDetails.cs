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
    public partial class FormUserDetails : Form
    {
        string adminID; // id of user, who made changes. It can be admin, or user
        string userID, firstName, lastName, age, email, userRole, active, street, streetNumber, postalCode, city, country, telephone, details;
        string[] items;
        Connect2DB connect = new Connect2DB();

        public FormUserDetails(string adminID, string firstName)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.adminID = adminID;
            details = connect.findUserByFirstName(firstName);
            items = details.Split(';');

            userID = items[0];
            this.firstName = items[1];
            lastName = items[2];
            age = items[3];
            email = items[4];
            userRole = items[5];
            active = items[6];
            street = items[7];
            streetNumber = items[8];
            postalCode = items[9];
            city = items[10];
            country = items[11];
            telephone = items[12];

            ID.Text = userID;
            FirstName.Text = this.firstName;
            LastName.Text = lastName;
            Age.Text = age;
            Email.Text = email;
            UserRole.Text = userRole;
            Active.Text = active;
            Street.Text = street;
            StreetNumber.Text = streetNumber;
            PostalCode.Text = postalCode;
            City.Text = city;
            Country.Text = country;
            Telephone.Text = telephone;

            ID.Enabled = false;
            Age.Enabled = false;
        }

        public FormUserDetails(string userID)
        {
            InitializeComponent();
            this.adminID = null;
            details = connect.findUserByID(userID);
            items = details.Split(';');

            userID = items[0];
            firstName = items[1];
            lastName = items[2];
            age = items[3];
            email = items[4];
            userRole = items[5];
            active = items[6];
            street = items[7];
            streetNumber = items[8];
            postalCode = items[9];
            city = items[10];
            country = items[11];
            telephone = items[12];

            ID.Text = userID;
            FirstName.Text = firstName;
            LastName.Text = lastName;
            Age.Text = age;
            Email.Text = email;
            UserRole.Text = userRole;
            Active.Text = active;
            Street.Text = street;
            StreetNumber.Text = streetNumber;
            PostalCode.Text = postalCode;
            City.Text = city;
            Country.Text = country;
            Telephone.Text = telephone;

            if (userRole.Equals("user"))
            {
                ID.Enabled = false;
                Age.Enabled = false;
                UserRole.Enabled = false;
                Active.Enabled = false;
            }
        }
              

        private void Apply_Click(object sender, EventArgs e)
        {
            userID = ID.Text;
            firstName = FirstName.Text;
            lastName = LastName.Text;
            email = Email.Text;
            userRole = UserRole.Text.ToLower();
            active = Active.Text.ToLower();
            street = Street.Text;
            streetNumber = StreetNumber.Text;
            postalCode = PostalCode.Text;
            city = City.Text;
            country = Country.Text;
            telephone = Telephone.Text;

            string details = userID + ";" + firstName + ";" + lastName + ";" + email + ";" + userRole + ";" + active + ";" + street + ";"
                + streetNumber + ";" + postalCode + ";" + city + ";" + country + ";" + telephone;

            if (connect.updateUserData(details))
            {
                DatabaseInfo.Text = "User data was updated";
                DatabaseInfo.Visible = true;
            }
            else
            {
                DatabaseInfo.Text = "Cannot connect to the database!";
                DatabaseInfo.Visible = true;
            }
        }

        private void ReturnChanges_Click(object sender, EventArgs e)
        {
            ID.Text = userID;
            FirstName.Text = firstName;
            LastName.Text = lastName;
            Age.Text = age;
            Email.Text = email;
            UserRole.Text = userRole;
            Active.Text = active;
            Street.Text = street;
            StreetNumber.Text = streetNumber;
            PostalCode.Text = postalCode;
            City.Text = city;
            Country.Text = country;
            Telephone.Text = telephone;
        }
    }
}
