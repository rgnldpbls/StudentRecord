using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecord.Models
{
    public interface IStudentRepository
    {
        void Add (Student student);
        void Edit(Student student);
        void Delete(int id);
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetByValue(string value);
    }
}
