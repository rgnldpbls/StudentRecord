using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRecord.Views
{
    public partial class StudentView : Form, IStudentView
    {
        private string message;
        private bool isSuccesful;
        private bool isEdit;

        public StudentView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPage2);
        }

        private void AssociateAndRaiseViewEvents()
        {
            button1.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            textBox1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            button2.Click += delegate 
            { 
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                tabPage2.Text = "Add New Student";
            };
            button3.Click += delegate 
            { 
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                tabPage2.Text = "Edit Student";
            };
            button4.Click += delegate 
            { 
                var result = MessageBox.Show("Are you sure you want to delete the seleted student?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
            button5.Click += delegate 
            { 
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccesful)
                {
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Add(tabPage1);
                }
                MessageBox.Show(Message);
            };
            button6.Click += delegate 
            { 
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage1);
            };
        }

        public string StudentId { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string FirstName { get { return textBox3.Text; } set { textBox3.Text = value; } }
        public string MiddleName { get { return textBox4.Text; } set { textBox4.Text = value; } }
        public string LastName { get { return textBox5.Text; } set { textBox5.Text = value; } }
        public string Glevel { get { return comboBox1.Text; } set { comboBox1.Text = value;  } }
        public string Section { get { return comboBox2.Text; } set { comboBox2.Text = value; } }
        public string SearchValue { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public bool IsEdit { get { return isEdit; } set { isEdit = value; } }
        public bool IsSuccesful { get { return isSuccesful; } set { isSuccesful = value; } }
        public string Message { get { return message; } set { message = value; } }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void StudentListBindingSource(BindingSource studentList)
        {
            dataGridView.DataSource = studentList;
        }
    }
}
