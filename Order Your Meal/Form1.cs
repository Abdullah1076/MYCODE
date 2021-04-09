using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.IO;

namespace Order_Your_Meal
{
    public partial class Form1 : Form

    {
        public Form1()


        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currDirectory = Directory.GetCurrentDirectory();
            string dataFilePath = Path.Combine(currDirectory, "meal.db");
            using (SqliteConnection myDBConnection = new SqliteConnection($"Filename={dataFilePath}"))
            {
                if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && label6.Text != "click here to confirm dessert selection")
                {
                    MessageBox.Show("YOUR ORDER IS PLACED SUCCESSFULLY", "Thanks for coming");
                }
                else
                {
                    MessageBox.Show("enter the required fields please be carefull", "warning");
                    return;

                }
                myDBConnection.Open();
                SqliteCommand myInsertCommand = new SqliteCommand();
                myInsertCommand.Connection = myDBConnection;
                myInsertCommand.CommandType = CommandType.Text;
                myInsertCommand.CommandText = "INSERT INTO ELEMENTS VALUES (@CustomerName,@ServingCounter,@MainCources,@Dessert);";
                myInsertCommand.Parameters.AddWithValue("@CustomerName", textBox1.Text);
                myInsertCommand.Parameters.AddWithValue("@ServingCounter", comboBox1.Text);
                myInsertCommand.Parameters.AddWithValue("@MainCources", comboBox2.Text);
                myInsertCommand.Parameters.AddWithValue("@Dessert", label6.Text);
                var resultoftheCommand = myInsertCommand.ExecuteReader();
                
                
                textBox1.Clear();
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                label6.Text = "click here to confirm dessert selection";
                return;

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string dessertData = radioButton1.Text;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string dessertData = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            string dessertData = radioButton3.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            string dessertData = radioButton4.Text;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            string dessertData;
            if (radioButton1.Checked==true)
            {
                label6.Text = radioButton1.Text;
                dessertData = radioButton1.Text;
            }

            if (radioButton2.Checked == true)
            {
                label6.Text = radioButton2.Text;
                dessertData = radioButton2.Text;
            }
            if (radioButton3.Checked == true)
            {
                label6.Text = radioButton3.Text;
                dessertData = radioButton3.Text;
            }
            if (radioButton4.Checked == true)
            {
                label6.Text = radioButton4.Text;
                dessertData = radioButton4.Text;
            }
        }
    }
}