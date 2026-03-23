using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLSinhvienDangkyHoc
{
    public partial class FormQLHocPhan : Form
    {
        // Chuỗi kết nối
        string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyHocPhan;Integrated Security=True";

        // --- Thành phần giao diện chi tiết ---
        Panel pnlChiTiet;
        TextBox txtMaLop, txtTenMon, txtSoTinChi, txtThu, txtTiet, txtGioiHan, txtDaDangKy;

        public FormQLHocPhan()
        {
            InitializeComponent();

            // Khởi tạo Panel chi tiết
            TaoPanelChiTiet();

            // Gán sự kiện CellClick cho DataGridView
            dgvHocPhan.CellClick += dgvHocPhan_CellClick;
        }

        private void FormQLHocPhan_Load(object sender, EventArgs e)
        {
            if (pnlChiTiet != null) pnlChiTiet.Visible = false; // ẩn ban đầu
        }

        // --- TẠO PANEL CHI TIẾT HIỆN ĐẠI ---
        private void TaoPanelChiTiet()
        {
            // Panel chính
            pnlChiTiet = new Panel();
            pnlChiTiet.Dock = DockStyle.Fill;
            pnlChiTiet.BackColor = Color.White;
            pnlChiTiet.Font = new Font("Calibri", 11); // font toàn bộ Panel
            panel3.Controls.Add(pnlChiTiet);
            pnlChiTiet.BringToFront();

            // Header
            Label lblHeader = new Label();
            lblHeader.Text = "THÔNG TIN CHI TIẾT";
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Height = 50;
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblHeader.BackColor = Color.FromArgb(52, 152, 219); // xanh đẹp
            lblHeader.ForeColor = Color.White;
            lblHeader.Font = new Font("Calibri", 12, FontStyle.Bold);
            pnlChiTiet.Controls.Add(lblHeader);

            // Panel con chứa các TextBox và Label
            Panel pnlContent = new Panel();
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Padding = new Padding(20);
            pnlChiTiet.Controls.Add(pnlContent);
            pnlContent.BringToFront();

            int currentTop = 20;

            // Hàm tạo Label hiện đại
            Label TaoLabelHienDai(string text, int y)
            {
                Label lbl = new Label();
                lbl.Text = text;
                lbl.Left = 20;
                lbl.Top = y;
                lbl.AutoSize = true;
                lbl.ForeColor = Color.Black;
                lbl.Font = new Font("Calibri", 10, FontStyle.Bold);
                return lbl;
            }

            // Hàm tạo TextBox hiện đại
            TextBox TaoTextBoxHienDai(int y, int width = 250)
            {
                TextBox txt = new TextBox();
                txt.Left = 20;
                txt.Top = y + 20;
                txt.Width = width;
                txt.ReadOnly = true;
                txt.BorderStyle = BorderStyle.None;
                txt.BackColor = Color.FromArgb(240, 240, 240);
                txt.Font = new Font("Calibri", 11, FontStyle.Regular);
                return txt;
            }

            // --- Thêm các trường ---
            pnlContent.Controls.Add(TaoLabelHienDai("Mã lớp học", currentTop));
            txtMaLop = TaoTextBoxHienDai(currentTop, 150);
            pnlContent.Controls.Add(txtMaLop);

            currentTop += 65;
            pnlContent.Controls.Add(TaoLabelHienDai("Tên môn học", currentTop));
            txtTenMon = TaoTextBoxHienDai(currentTop, 150);
            pnlContent.Controls.Add(txtTenMon);

            currentTop += 65;
            pnlContent.Controls.Add(TaoLabelHienDai("Số tín chỉ", currentTop));
            txtSoTinChi = TaoTextBoxHienDai(currentTop, 100);
            pnlContent.Controls.Add(txtSoTinChi);

            currentTop += 65;
            pnlContent.Controls.Add(TaoLabelHienDai("Thứ / Tiết học", currentTop));
            txtThu = TaoTextBoxHienDai(currentTop, 100 );
            pnlContent.Controls.Add(txtThu);

            txtTiet = TaoTextBoxHienDai(currentTop, 100);
            txtTiet.Left = 110;
            pnlContent.Controls.Add(txtTiet);

            currentTop += 65;
            pnlContent.Controls.Add(TaoLabelHienDai("Giới hạn sinh viên", currentTop));
            txtGioiHan = TaoTextBoxHienDai(currentTop, 100);
            pnlContent.Controls.Add(txtGioiHan);

            currentTop += 65;
            pnlContent.Controls.Add(TaoLabelHienDai("Số lượng đã đăng ký", currentTop));
            txtDaDangKy = TaoTextBoxHienDai(currentTop, 100);
            txtDaDangKy.ForeColor = Color.FromArgb(41, 128, 185);
            txtDaDangKy.Font = new Font("Calibri", 11, FontStyle.Bold);
            pnlContent.Controls.Add(txtDaDangKy);
        }

        // --- Xử lý khi chọn dòng trong DataGridView ---
        private void dgvHocPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Ẩn các control khác trừ Panel chi tiết
            foreach (Control ctrl in panel3.Controls)
            {
                if (ctrl != pnlChiTiet) ctrl.Visible = false;
            }

            pnlChiTiet.Visible = true;

            // Đổ dữ liệu
            DataGridViewRow row = dgvHocPhan.Rows[e.RowIndex];
            txtMaLop.Text = row.Cells[1].Value?.ToString();
            txtTenMon.Text = row.Cells[2].Value?.ToString();
            txtSoTinChi.Text = row.Cells[3].Value?.ToString();
            txtThu.Text = row.Cells[4].Value?.ToString();
            txtTiet.Text = row.Cells[5].Value?.ToString();
            txtGioiHan.Text = row.Cells[6].Value?.ToString();
            txtDaDangKy.Text = row.Cells[7].Value?.ToString();
        }

        // --- Các hàm stub để tránh lỗi build ---
        private void label7_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        // --- Logic khác ---
        public void ThemDongVaoDGV(string maLop, string tenMonHoc, string soTinChi, string thu, string tiet, string gioiHan, string daDangKy)
        {
            dgvHocPhan.Rows.Add(false, maLop, tenMonHoc, soTinChi, thu, tiet, gioiHan, daDangKy);
        }

        private void btnThemThuCong_Click(object sender, EventArgs e)
        {
            FormThemThuCong f = new FormThemThuCong(this);
            f.ShowDialog();
        }

        private void btnXoaCacLop_Click(object sender, EventArgs e )
        {
            DialogResult kq = MessageBox.Show("Xác nhận xóa?", "Thông báo", MessageBoxButtons.YesNo);
            if (kq == DialogResult.No) return;

            for (int i = dgvHocPhan.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dgvHocPhan.Rows[i].Cells[0].Value) ==true)
                    dgvHocPhan.Rows.RemoveAt(i);
            }
            KiemTraNutXoa();
        }

        private void KiemTraNutXoa()
        {
            bool coChon = dgvHocPhan.Rows.Cast<DataGridViewRow>().Any(r => Convert.ToBoolean(r.Cells[0].Value));
            btnXoaCacLop.Enabled = coChon;
            btnXoaCacLop.BackColor = coChon ? Color.Red : Color.LightGray;
        }

        private void dgvHocPhan_CellValueChanged(object sender, DataGridViewCellEventArgs e) { KiemTraNutXoa(); }
        private void dgvHocPhan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvHocPhan.IsCurrentCellDirty) dgvHocPhan.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void btnTaoHocKy_Click(object sender, EventArgs e) { pnlTaoHocKy.Visible = !pnlTaoHocKy.Visible; }
    }
}