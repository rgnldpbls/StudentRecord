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
        private string level;
        private string section;

        [DisplayName("Student Id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("First Name")]
        [Required(ErrorMessage="Student First Name is required")]
        [StringLength(100, MinimumLength=0, ErrorMessage= "Student First Name can only accept up to 100 characters")]
        public string FName
        {
            get { return fname; }
            set { fname = value; }
        }

        [DisplayName("Middle Name")]
        [StringLength(100, MinimumLength= 0, ErrorMessage="Student Middle Name can only accept up to 100 characters")]
        public string MName
        {
            get { return mname; }
            set { mname = value; }
        }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Student Last Name is required")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Student Last Name can only accept up to 100 characters")]
        public string LName
        {
            get { return lname; }
            set { lname = value; }
        }

        [DisplayName("Level")]
        [Required(ErrorMessage = "Student Level is required")]
        public string Level
        {
            get { return level; }
            set { level = value; }
        }

        [DisplayName("Section")]
        [Required(ErrorMessage = "Student Section is required")]
        public string Section
        {
            get { return section; }
            set { section = value; }
        }
    }
}
