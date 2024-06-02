using StudentRecord.Models;
using StudentRecord.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            CleanViewFields();
        }

        private void SaveRec(object sender, EventArgs e)
        {
            var model = new Student();
            model.FName = view.FirstName;
            model.MName = view.MiddleName;
            model.LName = view.LastName;
            model.Level = view.Glevel;
            model.Section = view.Section;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)
                {
                    model.Id = Convert.ToInt32(view.StudentId);
                    repo.Edit(model);
                    view.Message = "Student edited successfully!";
                }
                else
                {
                    repo.Add(model);
                    view.Message = "Student added successfully!";
                }
                view.IsSuccesful = true;
                AllStudentList();
                CleanViewFields();
            }
            catch(Exception ex)
            {
                view.IsSuccesful = false;
                view.Message = ex.Message;
            }
        }

        private void CleanViewFields()
        {
            view.StudentId = "                          -";
            view.FirstName = "";
            view.MiddleName = "";
            view.LastName = "";
            view.Glevel = "";
            view.Section = "";
        }

        private void DeleteStudentRec(object sender, EventArgs e)
        {
            try
            {
                var student = (Student)studBS.Current;
                repo.Delete(student.Id);
                view.IsSuccesful = true;
                view.Message = "Student deleted successfully!";
                AllStudentList();
            }
            catch(Exception ex)
            {
                view.IsSuccesful = false;
                view.Message = "An error occured, could not delete the student!";
            }
        }

        private void EditStudentRec(object sender, EventArgs e)
        {
            var student = (Student)studBS.Current;
            view.StudentId = student.Id.ToString();
            view.FirstName = student.FName;
            view.MiddleName = student.MName;
            view.LastName = student.LName;
            view.Glevel = student.Level;
            view.Section = student.Section;
            view.IsEdit = true;
        }

        private void AddNewStudent(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }
    }
}
