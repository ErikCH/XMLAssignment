// By: Erik Hanchett
// Date:4/09/2011
// Assignment: #7
// 

// This is the main GUI class that displays output from all the tasks.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLAssignment7
{
    public partial class XMLMain : Form
    {
        public Business business;
        public const string TASK1 = "Task1: ";
        public const string TASK2 = "\n\nTask2 completed";
        public const string TASK3 = "\n\nTask3 Total number of banks: ";
        public const string TASK4 = "\n\nTask4:";
        public const string TASK5 = "\n\nTask5:";
        public const string ERROR = "Error: ";
        
        //Constructor
        public XMLMain()
        {
            InitializeComponent();
            business = new Business();
        }

        //press go button
        private void goBtn_Click(object sender, EventArgs e)
        {
            try
            {
                goRTB.Text = TASK1 + business.Task1();
                business.Task2();
                goRTB.Text += TASK2;
                goRTB.Text += TASK3 + business.Task3();
                goRTB.Text += TASK4 + business.Task4();
                goRTB.Text += TASK5 + business.Task5();
            }
            catch (Exception m)
            {
                MessageBox.Show(ERROR + m.Message);
            }
        }
    }
}
