using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLSinhvienDangkyHoc
{
    public partial class FormQuenMK : Form
    {
        string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyHocPhan;Integrated Security=True";
        string otpCode = "";

        public FormQuenMK()
        {
            InitializeComponent();
        }

        private void FormQuenMK_Load(object sender, EventArgs e)
        {
            txtEmail.Text = "Email";
            txtEmail.ForeColor = Color.Gray;

            txtOTP.Text = "Nhập mã OTP";
            txtOTP.ForeColor = Color.Gray;

            txtMatKhauMoi.Text = "Mật khẩu mới";
            txtMatKhauMoi.ForeColor = Color.Gray;
            txtMatKhauMoi.UseSystemPasswordChar = false;

            txtNhapLaiMatKhau.Text = "Nhập lại mật khẩu";
            txtNhapLaiMatKhau.ForeColor = Color.Gray;
            txtNhapLaiMatKhau.UseSystemPasswordChar = false;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        private void txtOTP_Enter(object sender, EventArgs e)
        {
            if (txtOTP.Text == "Nhập mã OTP")
            {
                txtOTP.Text = "";
                txtOTP.ForeColor = Color.Black;
            }
        }

        private void txtOTP_Leave(object sender, EventArgs e)
        {
            if (txtOTP.Text.Trim() == "")
            {
                txtOTP.Text = "Nhập mã OTP";
                txtOTP.ForeColor = Color.Gray;
            }
        }

        private void txtMatKhauMoi_Enter(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text == "Mật khẩu mới")
            {
                txtMatKhauMoi.Text = "";
                txtMatKhauMoi.ForeColor = Color.Black;
                txtMatKhauMoi.UseSystemPasswordChar = true;
            }
        }

        private void txtMatKhauMoi_Leave(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text.Trim() == "")
            {
                txtMatKhauMoi.Text = "Mật khẩu mới";
                txtMatKhauMoi.ForeColor = Color.Gray;
                txtMatKhauMoi.UseSystemPasswordChar = false;
            }
        }

        private void txtNhapLaiMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtNhapLaiMatKhau.Text == "Nhập lại mật khẩu")
            {
                txtNhapLaiMatKhau.Text = "";
                txtNhapLaiMatKhau.ForeColor = Color.Black;
                txtNhapLaiMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void txtNhapLaiMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtNhapLaiMatKhau.Text.Trim() == "")
            {
                txtNhapLaiMatKhau.Text = "Nhập lại mật khẩu";
                txtNhapLaiMatKhau.ForeColor = Color.Gray;
                txtNhapLaiMatKhau.UseSystemPasswordChar = false;
            }
        }

        private void llbGuiOTP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (email == "" || email == "Email")
            {
                MessageBox.Show("Vui lòng nhập email trước!");
                txtEmail.Focus();
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!");
                txtEmail.Focus();
                return;
            }

            Random rnd = new Random();
            otpCode = rnd.Next(100000, 999999).ToString();

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("yourgmail@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Mã OTP đặt lại mật khẩu";
                mail.Body = "Mã OTP của bạn là: " + otpCode;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("daomaichi25@gmail.com", "ccxm zzqx zvip yqju");
                smtp.EnableSsl = true;

                smtp.Send(mail);

                MessageBox.Show("Đã gửi mã OTP về email!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi email: " + ex.Message);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string otp = txtOTP.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string nhapLai = txtNhapLaiMatKhau.Text.Trim();

            if (email == "" || email == "Email")
            {
                MessageBox.Show("Vui lòng nhập email!");
                txtEmail.Focus();
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!");
                txtEmail.Focus();
                return;
            }

            if (otp == "" || otp == "Nhập mã OTP")
            {
                MessageBox.Show("Vui lòng nhập mã OTP!");
                txtOTP.Focus();
                return;
            }

            if (otpCode == "")
            {
                MessageBox.Show("Bạn chưa gửi mã OTP!");
                return;
            }

            if (otp != otpCode)
            {
                MessageBox.Show("Mã OTP không đúng!");
                txtOTP.Focus();
                return;
            }

            if (matKhauMoi == "" || matKhauMoi == "Mật khẩu mới")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!");
                txtMatKhauMoi.Focus();
                return;
            }

            if (nhapLai == "" || nhapLai == "Nhập lại mật khẩu")
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu!");
                txtNhapLaiMatKhau.Focus();
                return;
            }

            if (matKhauMoi != nhapLai)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                txtNhapLaiMatKhau.Focus();
                return;
            }

            MessageBox.Show("Đặt lại mật khẩu thành công!");
            this.Close();
        }

        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "" ||
                txtOTP.Text.Trim() == "" ||
                txtMatKhauMoi.Text.Trim() == "" ||
                txtNhapLaiMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (txtOTP.Text.Trim() != otpCode)
            {
                MessageBox.Show("Mã OTP không đúng!");
                txtOTP.Focus();
                return;
            }

            if (txtMatKhauMoi.Text.Trim() != txtNhapLaiMatKhau.Text.Trim())
            {
                MessageBox.Show("Nhập lại mật khẩu không khớp!");
                txtNhapLaiMatKhau.Focus();
                return;
            }

            SqlConnection conn = new SqlConnection(connStr);
            string query = "UPDATE Admin SET MatKhau = @mk WHERE Email = @email";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@mk", txtMatKhauMoi.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());

            try
            {
                conn.Open();
                int kq = cmd.ExecuteNonQuery();
                conn.Close();

                if (kq > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");

                    FormDangNhap f = new FormDangNhap();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}