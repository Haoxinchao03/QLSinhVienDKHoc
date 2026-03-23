using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhvienDangkyHoc
{
    public partial class FormThemThuCong : Form
    {
        string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyHocPhan;Integrated Security=True";
        FormQLHocPhan frmCha;
        public FormThemThuCong(FormQLHocPhan f)
        {
            InitializeComponent();
            frmCha = f;
        }

        private void FormThemThuCong_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLopMonHoc.Text;
            string tenMonHoc = cboMonHoc.Text;
            string thu = cboThu.Text;
            string tiet = txtTiet.Text.Trim();
            string gioiHan = txtSiSo.Text.Trim();

            string soTinChi = "";
            string daDangKy = "0";

            if (tenMonHoc == "")
            {
                MessageBox.Show("Vui lòng chọn môn học!");
                return;
            }

            if (thu == "")
            {
                MessageBox.Show("Vui lòng chọn thứ!");
                return;
            }

            if (tiet == "")
            {
                MessageBox.Show("Vui lòng nhập tiết!");
                txtTiet.Focus();
                return;
            }

            if (gioiHan == "")
            {
                MessageBox.Show("Vui lòng nhập sĩ số tối đa!");
                txtSiSo.Focus();
                return;
            }

            // Gán số tín chỉ theo môn học
            if (tenMonHoc == "Trí tuệ nhân tạo")
                soTinChi = "3";
            else if (tenMonHoc == "Lập trình C#")
                soTinChi = "3";
            else if (tenMonHoc == "Cơ sở dữ liệu")
                soTinChi = "3";
            else if (tenMonHoc == "Mạng máy tính")
                soTinChi = "2";
            else
                soTinChi = "3";

            frmCha.ThemDongVaoDGV(maLop, tenMonHoc, soTinChi, thu, tiet, gioiHan, daDangKy);

            MessageBox.Show("Thêm lớp học thành công!");
            this.Close();
        }
    }
}
