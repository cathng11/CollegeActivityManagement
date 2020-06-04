namespace SE_15_UI
{
    partial class KhoaForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.layoutButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.table1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTenTK = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtIDTaiKhoan = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSoLuongSV = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTenKhoa = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIDKhoa = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.layoutButton.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.table1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.layoutButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 597);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // layoutButton
            // 
            this.layoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(173)))), ((int)(((byte)(190)))));
            this.layoutButton.ColumnCount = 3;
            this.layoutButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutButton.Controls.Add(this.btnThoat, 2, 0);
            this.layoutButton.Controls.Add(this.btnSave, 0, 0);
            this.layoutButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutButton.Location = new System.Drawing.Point(3, 510);
            this.layoutButton.Name = "layoutButton";
            this.layoutButton.RowCount = 2;
            this.layoutButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutButton.Size = new System.Drawing.Size(994, 84);
            this.layoutButton.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(58)))), ((int)(((byte)(101)))));
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI Semilight", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Black;
            this.btnThoat.Location = new System.Drawing.Point(598, 11);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(113, 28);
            this.btnThoat.TabIndex = 30;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(117)))), ((int)(((byte)(122)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semilight", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(281, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 28);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(173)))), ((int)(((byte)(190)))));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.table1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(994, 501);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // table1
            // 
            this.table1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(173)))), ((int)(((byte)(190)))));
            this.table1.ColumnCount = 2;
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.70392F));
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.29608F));
            this.table1.Controls.Add(this.txtTenTK, 1, 4);
            this.table1.Controls.Add(this.label14, 0, 4);
            this.table1.Controls.Add(this.txtIDTaiKhoan, 1, 3);
            this.table1.Controls.Add(this.label13, 0, 3);
            this.table1.Controls.Add(this.txtSoLuongSV, 1, 2);
            this.table1.Controls.Add(this.label12, 0, 2);
            this.table1.Controls.Add(this.txtTenKhoa, 1, 1);
            this.table1.Controls.Add(this.label11, 0, 1);
            this.table1.Controls.Add(this.label10, 0, 0);
            this.table1.Controls.Add(this.txtIDKhoa, 1, 0);
            this.table1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.table1.Location = new System.Drawing.Point(149, 100);
            this.table1.Margin = new System.Windows.Forms.Padding(0);
            this.table1.Name = "table1";
            this.table1.RowCount = 5;
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table1.Size = new System.Drawing.Size(695, 401);
            this.table1.TabIndex = 28;
            // 
            // txtTenTK
            // 
            this.txtTenTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.txtTenTK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenTK.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTenTK.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTK.Location = new System.Drawing.Point(248, 320);
            this.txtTenTK.Margin = new System.Windows.Forms.Padding(0);
            this.txtTenTK.Name = "txtTenTK";
            this.txtTenTK.Size = new System.Drawing.Size(447, 22);
            this.txtTenTK.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(3, 320);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(242, 21);
            this.label14.TabIndex = 20;
            this.label14.Text = "Tên tài khoản";
            // 
            // txtIDTaiKhoan
            // 
            this.txtIDTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.txtIDTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIDTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtIDTaiKhoan.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDTaiKhoan.Location = new System.Drawing.Point(248, 240);
            this.txtIDTaiKhoan.Margin = new System.Windows.Forms.Padding(0);
            this.txtIDTaiKhoan.Name = "txtIDTaiKhoan";
            this.txtIDTaiKhoan.Size = new System.Drawing.Size(447, 22);
            this.txtIDTaiKhoan.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(3, 240);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(242, 21);
            this.label13.TabIndex = 20;
            this.label13.Text = "Mã số tài khoản";
            // 
            // txtSoLuongSV
            // 
            this.txtSoLuongSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.txtSoLuongSV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSoLuongSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSoLuongSV.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuongSV.Location = new System.Drawing.Point(248, 160);
            this.txtSoLuongSV.Margin = new System.Windows.Forms.Padding(0);
            this.txtSoLuongSV.Name = "txtSoLuongSV";
            this.txtSoLuongSV.Size = new System.Drawing.Size(447, 22);
            this.txtSoLuongSV.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(3, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(242, 21);
            this.label12.TabIndex = 20;
            this.label12.Text = "Số lượng sinh viên";
            // 
            // txtTenKhoa
            // 
            this.txtTenKhoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.txtTenKhoa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenKhoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTenKhoa.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhoa.Location = new System.Drawing.Point(248, 80);
            this.txtTenKhoa.Margin = new System.Windows.Forms.Padding(0);
            this.txtTenKhoa.Name = "txtTenKhoa";
            this.txtTenKhoa.Size = new System.Drawing.Size(447, 22);
            this.txtTenKhoa.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(3, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(242, 21);
            this.label11.TabIndex = 20;
            this.label11.Text = "Tên khoa";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(242, 21);
            this.label10.TabIndex = 20;
            this.label10.Text = "Mã số khoa";
            // 
            // txtIDKhoa
            // 
            this.txtIDKhoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.txtIDKhoa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIDKhoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtIDKhoa.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDKhoa.Location = new System.Drawing.Point(248, 0);
            this.txtIDKhoa.Margin = new System.Windows.Forms.Padding(0);
            this.txtIDKhoa.Name = "txtIDKhoa";
            this.txtIDKhoa.Size = new System.Drawing.Size(447, 22);
            this.txtIDKhoa.TabIndex = 20;
            // 
            // KhoaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(173)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(1000, 597);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KhoaForm";
            this.Text = "KhoaForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.layoutButton.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.table1.ResumeLayout(false);
            this.table1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel table1;
        private System.Windows.Forms.TextBox txtTenTK;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtIDTaiKhoan;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSoLuongSV;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTenKhoa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIDKhoa;
        private System.Windows.Forms.TableLayoutPanel layoutButton;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}