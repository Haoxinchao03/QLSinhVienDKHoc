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

namespace QLSinhvienDangkyHoc
{
    public partial class FormQLHocPhan : Form
    {
        string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyHocPhan;Integrated Security=True";
        public FormQLHocPhan()
        {
            InitializeComponent();
        }

        private void FormQLHocPhan_Load(object sender, EventArgs e)
        {

        }
        public void ThemDongVaoDGV(string maLop, string tenMonHoc, string soTinChi,
                           string thu, string tiet, string gioiHan, string daDangKy)
        {
            dgvHocPhan.Rows.Add(false, maLop, tenMonHoc, soTinChi, thu, tiet, gioiHan, daDangKy);
        }

        private void btnTaoHocKy_Click(object sender, EventArgs e)
        {
            pnlTaoHocKy.Visible = !pnlTaoHocKy.Visible;
        }


        private void btnThemThuCong_Click(object sender, EventArgs e)
        {
            FormThemThuCong f = new FormThemThuCong(this);
            f.ShowDialog();
        }

        private void dgvHocPhan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvHocPhan.IsCurrentCellDirty)
            {
                dgvHocPhan.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvHocPhan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            KiemTraNutXoa();
        }
        private void KiemTraNutXoa()
        {
            bool coChon = false;

            foreach (DataGridViewRow row in dgvHocPhan.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    coChon = true;
                    break;
                }
            }

            if (coChon)
            {
                btnXoaCacLop.Enabled = true;
                btnXoaCacLop.BackColor = Color.Red;
                btnXoaCacLop.ForeColor = Color.White;
            }
            else
            {
                btnXoaCacLop.Enabled = false;
                btnXoaCacLop.BackColor = Color.LightGray;
                btnXoaCacLop.ForeColor = Color.Black;
            }
        }

        private void btnXoaCacLop_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show(
       "Bạn có chắc chắn muốn xóa các lớp đã chọn không?",
       "Xác nhận xóa",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question);

            if (kq == DialogResult.No)
                return;

            for (int i = dgvHocPhan.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dgvHocPhan.Rows[i];

                if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    dgvHocPhan.Rows.RemoveAt(i);
                }
            }

            KiemTraNutXoa();
        }
        private void TestLoad()
        {
            SqlConnection conn = new SqlConnection(connStr);
            string query = "SELECT * FROM HocKy";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
                MessageBox.Show("Đã kết nối và có dữ liệu!");
            else
                MessageBox.Show("Kết nối OK nhưng chưa có dữ liệu!");
        }

        private void bntTest_Click(object sender, EventArgs e)
        {
            TestLoad();
        }
    }
}
