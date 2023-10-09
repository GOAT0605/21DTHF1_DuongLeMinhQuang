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
    public partial class Form2 : Form
    {
        StudentContectDB db = new StudentContectDB();
        private List<Faculty> FacultyList = new List<Faculty>();
        public Form2()
        {
            InitializeComponent();
        }
       
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            StudentContectDB db = new StudentContectDB();
            BindGrid(db.Faculties.ToList());
        }
        private void BindGrid(List<Faculty> ListStudents)
        {
            dvgFaculty.Rows.Clear();
            foreach (var item in ListStudents)
            {
                int index = dvgFaculty.Rows.Add();
                dvgFaculty.Rows[index].Cells["KhoaID"].Value = item.FacultyID;
                dvgFaculty.Rows[index].Cells["TenKhoa"].Value = item.FacultyName;
                dvgFaculty.Rows[index].Cells["NumberProssesor"].Value = item.TotolProfessor;
            }
        }

        private void dvgFaculty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dvgFaculty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            if (RowIndex >= 0)
            {
                txtFacultyID.Text = dvgFaculty.Rows[RowIndex].Cells["KhoaID"].Value.ToString();
                txtFacultyName.Text = dvgFaculty.Rows[RowIndex].Cells["TenKhoa"].Value.ToString();
                if (dvgFaculty.Rows[RowIndex].Cells["NumberProssesor"].Value.ToString() == null)
                {
                    txtNum.Text = "0";
                }
                txtNum.Text = dvgFaculty.Rows[RowIndex].Cells["NumberProssesor"].Value.ToString();



            }
        }

        private void BtnEditAndAdd_Click(object sender, EventArgs e)
        {
            StudentContectDB db = new StudentContectDB();
            var facultyID = int.Parse(txtFacultyID.Text);

            var existingFaculty = db.Faculties.FirstOrDefault(c => c.FacultyID == facultyID);
            if (existingFaculty == null)
            {
                var ten = txtFacultyName.Text;
                var SL = int.Parse(txtNum.Text);

                Faculty faculty = new Faculty()
                {
                    FacultyID = facultyID,
                    FacultyName = ten,
                    TotolProfessor = SL
                };
                db.Faculties.Add(faculty);
            }
            else
            {
                existingFaculty.FacultyName = txtFacultyName.Text;
                existingFaculty.TotolProfessor = int.Parse(txtNum.Text);
            }

            db.SaveChanges();
            BindGrid(db.Faculties.ToList());
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            StudentContectDB db = new StudentContectDB();
            int rowIndex = dvgFaculty.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                int FacultyID =int.Parse( dvgFaculty.Rows[rowIndex].Cells["KhoaID"].Value.ToString());


                var Faculty = db.Faculties.FirstOrDefault(s => s.FacultyID == FacultyID);
                if (Faculty != null)
                {
                    db.Faculties.Remove(Faculty);
                    db.SaveChanges();
                }


                BindGrid(db.Faculties.ToList());
            }
        }
    }
}
