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
    public partial class FormQLHocPhan : Form
    {
        public FormQLHocPhan()
        {
            InitializeComponent();
        }

        private void FormQLHocPhan_Load(object sender, EventArgs e)
        {

        }

        private void btnTaoHocKy_Click(object sender, EventArgs e)
        {
            pnlTaoHocKy.Visible = !pnlTaoHocKy.Visible;
        }


        private void btnThemThuCong_Click(object sender, EventArgs e)
        {
            FormThemThuCong f = new FormThemThuCong();
            f.ShowDialog();
        }
    }
}
