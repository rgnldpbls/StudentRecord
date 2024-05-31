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
        }

        public string StudentId { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string FirstName { get { return textBox3.Text; } set { textBox3.Text = value; } }
        public string MiddleName { get { return textBox4.Text; } set { textBox4.Text = value; } }
        public string LastName { get { return textBox5.Text; } set { textBox5.Text = value; } }
        public string Glevel { get { return textBox6.Text; } set { textBox6.Text = value;  } }
        public string Section { get { return textBox7.Text; } set { textBox7.Text = value; } }
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
