using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO.NET_HW4
{
    public partial class Form1 : Form
    {
        private DatabaseAccess db;
        public Form1()
        {
            InitializeComponent();
            db = new DatabaseAccess("Data Source=(local);Initial Catalog=mydb;Integrated Security=True");
            db.OpenConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
             string values = "'value1', 'value2', 'value3'";
            db.InsertData("mytable", values);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
             string set = "column1 = 'new value'";
            string where = "column2 = 'some value'";
            db.UpdateData("mytable", set, where);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
             string where = "column3 = 'another value'";
            db.DeleteData("mytable", where);
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
             string columns = "column1, column2, column3";
            string where = "column4 = 'some value'";
            SqlDataReader reader = db.SelectData("mytable", columns, where);

             while (reader.Read())
            {
                string value1 = reader["column1"].ToString();
                string value2 = reader["column2"].ToString();
                string value3 = reader["column3"].ToString();
                Console.WriteLine(value1 + " " + value2 + " " + value3);
            }

             reader.Close();
        }

        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
             db.CloseConnection();
        }


    }

     
}
