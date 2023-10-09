using System;
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
    public partial class Form1 : Form
    {
        private List<Faculty> FacultyList = new List<Faculty>();
        StudentContectDB db = new StudentContectDB();
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

            if (Application.OpenForms.Count != 0)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void TxtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var ID = TxtStdID.Text;
            var ten = TxtName.Text;
            var DTB = TxtAverageScore.Text;
            var Khoa = (int)cmbFacluty.SelectedValue;
            StudentContectDB db = new StudentContectDB();

            Student student = new Student()
            {
                Name = ten,
                StudentID = ID,
                AverageScore = float.Parse(DTB),
                FacultyID = Khoa,
            };
            db.Students.Add(student);
            db.SaveChanges();
            BindGrid(db.Students.ToList());
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            if (RowIndex >= 0)
            {
                TxtName.Text = dgvStudent.Rows[RowIndex].Cells["STDName"].Value.ToString();
                TxtStdID.Text = dgvStudent.Rows[RowIndex].Cells["StdID"].Value.ToString();
                cmbFacluty.SelectedItem = dgvStudent.Rows[RowIndex].Cells["Faculty"].Value;
                TxtAverageScore.Text = dgvStudent.Rows[RowIndex].Cells["AvgScore"].Value.ToString();
                cmbFacluty.Refresh();


            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            StudentContectDB db = new StudentContectDB();
            var updateStudent = db.Students.SingleOrDefault(c => c.StudentID.Equals(TxtStdID.Text));
            updateStudent.Name = TxtName.Text;
            updateStudent.FacultyID = (int)cmbFacluty.SelectedValue;
            updateStudent.AverageScore = double.Parse(TxtAverageScore.Text);
            updateStudent.StudentID = TxtStdID.Text;
            db.SaveChanges();
            BindGrid(db.Students.ToList());
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            StudentContectDB db = new StudentContectDB();
            int rowIndex = dgvStudent.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                string studentID = dgvStudent.Rows[rowIndex].Cells["StdID"].Value.ToString();


                var student = db.Students.FirstOrDefault(s => s.StudentID == studentID);
                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                }


                BindGrid(db.Students.ToList());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            this.Hide();


            Form2 form2 = new Form2();


            form2.Show();
        }

        private void StrSearch_Click(object sender, EventArgs e)
        {
            this.Hide();


            Form3 form3 = new Form3();


            form3.Show();
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            this.Hide();


            Form4 form4 = new Form4();


            form4.Show();
        }
    }
}
