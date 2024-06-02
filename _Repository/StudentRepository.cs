using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using StudentRecord.Models;

namespace StudentRecord._Repository
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public StudentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(Student student)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Student VALUES(@fname, @mname, @lname, @level, @section)";
                command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = student.FName;
                command.Parameters.Add("@mname", SqlDbType.NVarChar).Value = student.MName;
                command.Parameters.Add("@lname", SqlDbType.NVarChar).Value = student.LName;
                command.Parameters.Add("@level", SqlDbType.NVarChar).Value = student.Level;
                command.Parameters.Add("@section", SqlDbType.NVarChar).Value = student.Section;
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM Student WHERE studentId=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(Student student)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE Student SET FName=@fname, MName=@mname, LName=@lname, Lvl=@level, Section=@section WHERE studentId=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;
                command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = student.FName;
                command.Parameters.Add("@mname", SqlDbType.NVarChar).Value = student.MName;
                command.Parameters.Add("@lname", SqlDbType.NVarChar).Value = student.LName;
                command.Parameters.Add("@level", SqlDbType.NVarChar).Value = student.Level;
                command.Parameters.Add("@section", SqlDbType.NVarChar).Value = student.Section;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Student> GetAll()
        {
            var studList = new List<Student>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Student ORDER BY studentId DESC";
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var studentModel = new Student();
                        studentModel.Id = (int)reader[0];
                        studentModel.FName = reader[1].ToString();
                        studentModel.MName = reader[2].ToString();
                        studentModel.LName = reader[3].ToString();
                        studentModel.Level = reader[4].ToString();
                        studentModel.Section = reader[5].ToString();
                        studList.Add(studentModel);
                    }
                }
            }
                return studList;
        }

        public IEnumerable<Student> GetByValue(string value)
        {
            var studList = new List<Student>();
            int studentId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string studentName = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Student WHERE studentId=@id or (Fname + ' ' + Lname) like @name+'%'" +
                    "ORDER BY studentId DESC";
                command.Parameters.Add("@id", SqlDbType.Int).Value = studentId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = studentName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var studentModel = new Student();
                        studentModel.Id = (int)reader[0];
                        studentModel.FName = reader[1].ToString();
                        studentModel.MName = reader[2].ToString();
                        studentModel.LName = reader[3].ToString();
                        studentModel.Level = reader[4].ToString();
                        studentModel.Section = reader[5].ToString();
                        studList.Add(studentModel);
                    }
                }
            }
            return studList;
        }
    }
}
