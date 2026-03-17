using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QLSinhvienDangkyHoc
{
    public partial class FormDangNhap : Form
    {
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

            if (email == "" || email == "Tên đăng nhập")
            {
                MessageBox.Show("Vui lòng nhập email!");
                txtDangNhap.Focus();
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!");
                txtDangNhap.Focus();
                return;
            }
            if (matKhau == "" || matKhau == "Mật khẩu")
            {
                MessageBox.Show("Mật khẩu không được để trống!");
                txtMatKhau.Focus();
                return;
            }

            MessageBox.Show("Đăng nhập thành công!");
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
    }
}
