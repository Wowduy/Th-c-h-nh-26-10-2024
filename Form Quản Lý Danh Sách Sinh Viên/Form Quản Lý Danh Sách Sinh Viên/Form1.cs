using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Form_Quản_Lý_Danh_Sách_Sinh_Viên
{
    public partial class Form1 : Form
    {
        List<Student> studentList = new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo mới sinh viên với thông tin từ các TextBox và thêm vào danh sách
            Student student = new Student()
            {
                ID = textBox1.Text,
                Name = textBox2.Text,
                Class = textBox3.Text,
                Score = Convert.ToDouble(textBox5.Text) // Lấy điểm từ textBox5
            };
            studentList.Add(student);
            RefreshGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Lấy ID của sinh viên được chọn trong DataGridView
                string selectedId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Student student = studentList.Find(s => s.ID == selectedId);

                // Cập nhật thông tin sinh viên với dữ liệu từ các TextBox
                student.ID = textBox1.Text;
                student.Name = textBox2.Text;
                student.Class = textBox3.Text;
                student.Score = Convert.ToDouble(textBox5.Text); // Cập nhật điểm từ textBox5

                RefreshGridView();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Lấy ID của sinh viên cần xóa
                string selectedId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                studentList.RemoveAll(s => s.ID == selectedId);
                RefreshGridView();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void RefreshGridView()
        {
            // Cập nhật lại DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = studentList;
        }

        public class Student
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }
            public double Score { get; set; } // Thêm thuộc tính điểm
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string searchID = textBox4.Text.ToLower();

            // Lọc danh sách sinh viên theo ID
            var filteredList = studentList.Where(student => student.ID.ToLower().Contains(searchID)).ToList();

            // Cập nhật DataGridView để hiển thị danh sách đã lọc
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filteredList;
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }
    }
}
