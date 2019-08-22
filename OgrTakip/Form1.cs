using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrTakip
{
    public partial class Form1 : Form
    {
        List<Student> studentList;
        public Form1()
        {
            InitializeComponent();
            loadData();
        }
        
        public void loadData()
        {
            studentList = DbOperations.LoadData();
            
            dataGridView1.DataSource = studentList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.Age = Convert.ToInt32(txtAge.Text);
            s.Name = txtName.Text;
            s.Surname = txtSurname.Text;

            DbOperations.InsertData(s);

            loadData();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count<=0)
            {
                MessageBox.Show("Select row to Delete");
                return;
            }

            Student s=(Student)dataGridView1.SelectedRows[0].DataBoundItem;

            DbOperations.DeleteStudent(s.Id);

            loadData();
        }
    }
}
