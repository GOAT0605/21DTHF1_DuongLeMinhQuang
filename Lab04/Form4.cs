using DevExpress.XtraReports;
using Lab04.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            StudentContectDB context = new StudentContectDB(); List<Student> listStudent = context.Students.ToList(); //day stát rá List<Student Report> listReport = new List<StudentReport>();
            List<Student> ListStudent = context.Students.ToList();
            List<StudentReport> ReportList = new List<StudentReport>();
            foreach (Student i in listStudent)

            {

                StudentReport temp = new StudentReport();

                temp.StudentID = i.StudentID;

                temp.Name= i.Name; 
                temp.AverageScore = (Double)i.AverageScore;

                temp.FacultyName =i.Faculty.FacultyName; 

                
                ReportList.Add(temp);
            }
            reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            var source = new ReportDataSource("DataSet1", ReportList);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();

        }
    }
}
