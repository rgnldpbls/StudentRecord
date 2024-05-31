using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentRecord.Models
{
    public class Student
    {
        private int id;
        private string fname;
        private string mname;
        private string lname;
        private int glevel;
        private int section;

        [DisplayName("Student Id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Student First Name")]
        [Required(ErrorMessage ="Student First Name is required")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="Student First Name must be between 3 and 100 characters")]
        public string FName
        {
            get { return fname; }
            set { fname = value; }
        }

        [DisplayName("Student Middle Name")]
        [Required(ErrorMessage = "Student Middle Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Student Middle Name must be between 3 and 100 characters")]
        public string MName
        {
            get { return mname; }
            set { mname = value; }
        }

        [DisplayName("Student Last Name")]
        [Required(ErrorMessage = "Student Last Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Student Last Name must be between 3 and 100 characters")]
        public string LName
        {
            get { return lname; }
            set { lname = value; }
        }

        [DisplayName("Student Level")]
        [Required(ErrorMessage = "Student Level is required")]
        public int GLevel
        {
            get { return glevel; }
            set { glevel = value; }
        }

        [DisplayName("Student Section")]
        [Required(ErrorMessage = "Student Section is required")]
        public int Section
        {
            get { return section; }
            set { section = value; }
        }
    }
}
