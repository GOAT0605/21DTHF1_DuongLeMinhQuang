﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04.Model;
namespace Lab04
{
    public partial class Form3 : Form
    {
        private List<Faculty> FacultyList = new List<Faculty>();
        StudentContectDB db = new StudentContectDB();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            StudentContectDB db = new StudentContectDB();
            FillFaculty(db.Faculties.ToList());
            BindGrid(db.Students.ToList());
        }
        private void BindGrid(List<Student> ListStudents)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in ListStudents)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells["StdID"].Value = item.StudentID;
                dgvStudent.Rows[index].Cells["StdName"].Value = item.Name;
                dgvStudent.Rows[index].Cells["Faculty"].Value = item.Faculty.FacultyName;
                dgvStudent.Rows[index].Cells["AvgScore"].Value = item.AverageScore;
            }
        }
        private void FillFaculty(List<Faculty> listFaculties)
        {
            this.cmbFacluty.DataSource = listFaculties;
            this.cmbFacluty.DisplayMember = "FacultyName";
            this.cmbFacluty.ValueMember = "FacultyID";
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            StudentContectDB db = new StudentContectDB();
            var StdID = TxtID;
       //     var existingID = db.Students.FirstOrDefault(c => c.StudentID == StdID);
        //    if (existingID != null)
//            {

  //          }
        }
    }
}
