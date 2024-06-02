using StudentRecord._Repository;
using StudentRecord.Models;
using StudentRecord.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using StudentRecord.Presenters;

namespace StudentRecord
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            IStudentView view = new StudentView();
            IStudentRepository repo = new StudentRepository(sqlConnectionString);
            new StudentPresenter(view, repo);
            Application.Run((Form)view);
        }
    }
}
