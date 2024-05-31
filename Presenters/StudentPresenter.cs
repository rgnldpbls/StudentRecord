using StudentRecord.Models;
using StudentRecord.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRecord.Presenters
{
    public class StudentPresenter
    {
        private IStudentView view;
        private IStudentRepository repo;
        private BindingSource studBS;
        private IEnumerable<Student> studList;

        public StudentPresenter(IStudentView view, IStudentRepository repo)
        {
            this.studBS = new BindingSource();
            this.view = view;
            this.repo = repo;
            this.view.SearchEvent += SearchStudent;
            this.view.AddNewEvent += AddNewStudent;
            this.view.EditEvent += EditStudentRec;
            this.view.DeleteEvent += DeleteStudentRec;
            this.view.SaveEvent += SaveRec;
            this.view.CancelEvent += CancelAct;
            this.view.StudentListBindingSource(studBS);
            AllStudentList();
            this.view.Show();

        }

        private void AllStudentList()
        {
            studList = repo.GetAll();
            studBS.DataSource = studList;
        }

        private void SearchStudent(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                studList = repo.GetByValue(this.view.SearchValue);
            else studList = repo.GetAll();
            studBS.DataSource = studList;
        }

        private void CancelAct(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveRec(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteStudentRec(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditStudentRec(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewStudent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
