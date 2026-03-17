namespace QLSinhvienDangkyHoc
{
    partial class FormQuenMK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.txtNhapLaiMatKhau = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.llbGuiOTP = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐẶT LẠI MẬT KHẨU";
            // 
            // txtEmail
            // 
            this.txtEmail.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtEmail.Location = new System.Drawing.Point(46, 171);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(433, 42);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Text = "Email";
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtOTP
            // 
            this.txtOTP.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtOTP.Location = new System.Drawing.Point(46, 246);
            this.txtOTP.Multiline = true;
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(433, 42);
            this.txtOTP.TabIndex = 2;
            this.txtOTP.Text = "Nhập mã OTP";
            this.txtOTP.Enter += new System.EventHandler(this.txtOTP_Enter);
            this.txtOTP.Leave += new System.EventHandler(this.txtOTP_Leave);
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtMatKhauMoi.Location = new System.Drawing.Point(46, 325);
            this.txtMatKhauMoi.Multiline = true;
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(433, 42);
            this.txtMatKhauMoi.TabIndex = 3;
            this.txtMatKhauMoi.Text = "Mật khẩu mới";
            this.txtMatKhauMoi.Enter += new System.EventHandler(this.txtMatKhauMoi_Enter);
            this.txtMatKhauMoi.Leave += new System.EventHandler(this.txtMatKhauMoi_Leave);
            // 
            // txtNhapLaiMatKhau
            // 
            this.txtNhapLaiMatKhau.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtNhapLaiMatKhau.Location = new System.Drawing.Point(46, 405);
            this.txtNhapLaiMatKhau.Multiline = true;
            this.txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            this.txtNhapLaiMatKhau.Size = new System.Drawing.Size(433, 42);
            this.txtNhapLaiMatKhau.TabIndex = 4;
            this.txtNhapLaiMatKhau.Text = "Nhập lại mật khẩu";
            this.txtNhapLaiMatKhau.Enter += new System.EventHandler(this.txtNhapLaiMatKhau_Enter);
            this.txtNhapLaiMatKhau.Leave += new System.EventHandler(this.txtNhapLaiMatKhau_Leave);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(180, 490);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(122, 60);
            this.btnXacNhan.TabIndex = 5;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // llbGuiOTP
            // 
            this.llbGuiOTP.AutoSize = true;
            this.llbGuiOTP.BackColor = System.Drawing.SystemColors.Window;
            this.llbGuiOTP.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.llbGuiOTP.Location = new System.Drawing.Point(409, 182);
            this.llbGuiOTP.Name = "llbGuiOTP";
            this.llbGuiOTP.Size = new System.Drawing.Size(60, 21);
            this.llbGuiOTP.TabIndex = 6;
            this.llbGuiOTP.TabStop = true;
            this.llbGuiOTP.Text = "Gửi mã";
            this.llbGuiOTP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbGuiOTP_LinkClicked);
            // 
            // FormQuenMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 639);
            this.Controls.Add(this.llbGuiOTP);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtNhapLaiMatKhau);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Name = "FormQuenMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormQuenMK";
            this.Load += new System.EventHandler(this.FormQuenMK_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.TextBox txtNhapLaiMatKhau;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.LinkLabel llbGuiOTP;
    }
}