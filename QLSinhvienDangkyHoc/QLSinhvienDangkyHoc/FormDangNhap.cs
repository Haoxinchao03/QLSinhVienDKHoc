using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhvienDangkyHoc
{
    public partial class FormDangNhap : Form
    {
        string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyHocPhan;Integrated Security=True";
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void llbQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormQuenMK frm = new FormQuenMK();
            frm.ShowDialog();
        }

        private void txtDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDangNhap_Enter(object sender, EventArgs e)
        {
            if (txtDangNhap.Text == "Tên đăng nhập")
            {
                txtDangNhap.Text = "";
                txtDangNhap.ForeColor = Color.Black;
            }
        }
        private void txtDangNhap_Leave(object sender, EventArgs e)
        {
            if (txtDangNhap.Text == "")
            {
                txtDangNhap.Text = "Tên đăng nhập";
                txtDangNhap.ForeColor = Color.Gray;
            }
        }

        private void txtDangNhap_Click(object sender, EventArgs e)
        {
            string email = txtDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!");
                txtDangNhap.Focus();
                return;
        
            }
        }

        private void txtMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                txtMatKhau.Text = "Mật khẩu";
                txtMatKhau.ForeColor = Color.Gray;
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Mật khẩu")
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.Black;
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtDangNhap.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!");
                return;
            }

            SqlConnection conn = new SqlConnection(connStr);
            string query = "SELECT COUNT(*) FROM Admin WHERE Email = @user AND MatKhau = @pass";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@user", txtDangNhap.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", txtMatKhau.Text.Trim());

            try
            {
                conn.Open();
                int dem = (int)cmd.ExecuteScalar();
                conn.Close();

                if (dem > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!");

                    FormQLHocPhan f = new FormQLHocPhan();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
    }
}
