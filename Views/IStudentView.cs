using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRecord.Views
{
    public interface IStudentView
    {
        string StudentId {  get; set; }
        string FirstName {  get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string Glevel { get; set; }
        string Section { get; set; }

        string SearchValue {  get; set; }
        bool IsEdit { get; set; }
        bool IsSuccesful {  get; set; }
        string Message { get; set; }

        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        void StudentListBindingSource(BindingSource studentList);
        void Show();
    }
}
