using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SE_15_DTO;
using SE_15_BLL;

namespace SE_15_UI
{
    public partial class QLHDForm : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;
        public MyDel D { get => _D; set => _D = value; }

        private string typeUser;
        public string TypeUser { get => typeUser; set => typeUser = value; }

        private Nullable<int> _IDSinhVien;
        public Nullable<int> IDSinhVien { get => _IDSinhVien; set => _IDSinhVien = value; }

        public QLHDForm(string typeUser, Nullable<int> idsv)
        {
            TypeUser = typeUser;
            IDSinhVien = idsv;
            InitializeComponent();
            if (TypeUser == "UserSinhVien")
            {
                SetView_SV();
            }
            SetCBBKhoa();
            ShowHoatDongs();

        }
        private void SetView_SV()
        {
            btnSua.Visible = false;
            layoutButton.RowCount = 3;
            btnTao.Text = "Đăng ký";
            btnHuy.Text = "Hủy đăng ký";
            layoutButton.SetRow(btnTao, 1);
            SinhVien sv = SinhVien_BLL.Instance.ShowSV_BLL(Convert.ToInt32(IDSinhVien));
            string khoa = Khoa_BLL.Instance.Get_ByID_BLL(Convert.ToInt32(sv.IDKhoa)).ToString();
            cbbKhoa.Text = khoa;
            cbbKhoa.Enabled = false;
        }
        private void SetCBBKhoa()
        {
            if (TypeUser == "UserAdmin")
            {
                cbbKhoa.Items.Add(new Khoa_DTO { IDKhoa = 0, TenKhoa = "All", SoLuongSV = 0, TenDangNhap = "" }) ;
                foreach (Khoa_DTO item in Khoa_BLL.Instance.GetAll_BLL())
                {
                    cbbKhoa.Items.Add(item);
                }
                //cbbKhoa.DisplayMember = "TenKhoa";
                cbbKhoa.SelectedIndex = 0;

            }
            else if (TypeUser == "UserKhoa")
            {
                DashboardForm dashboardForm = (DashboardForm)Application.OpenForms["DashboardForm"];
                Khoa khoa = Khoa_BLL.Instance.Get_ByTaiKhoan_BLL(dashboardForm.ID_TK);
                cbbKhoa.Text = khoa.TenKhoa;
                cbbKhoa.Enabled = false;
            }
            else
            {
                DashboardForm dashboardForm = (DashboardForm)Application.OpenForms["DashboardForm"];
                SinhVien sv = SinhVien_BLL.Instance.Get_ByTaiKhoan_BLL(dashboardForm.ID_TK);
                cbbKhoa.Text = sv.Khoa.TenKhoa;
                cbbKhoa.Enabled = false;
            }
        }
        public void ShowHoatDongs()
        {
            if (TypeUser == "UserAdmin")
            {
                dtgvHoatDong.DataSource = HoatDong_BLL.Instance.GetALL_BLL();
            }
            else if (TypeUser == "UserKhoa")
            {
                DashboardForm dashboardForm = (DashboardForm)Application.OpenForms["DashboardForm"];
                Khoa khoa = Khoa_BLL.Instance.Get_ByTaiKhoan_BLL(dashboardForm.ID_TK);
                dtgvHoatDong.DataSource = HoatDong_BLL.Instance.Get_ByKhoa_BLL(khoa.IDKhoa);
            }
            else
            {
                ResetDataGridView();
                DashboardForm dashboardForm = (DashboardForm)Application.OpenForms["DashboardForm"];
                SinhVien sv = SinhVien_BLL.Instance.Get_ByTaiKhoan_BLL(dashboardForm.ID_TK);
                dtgvHoatDong.DataSource = DangKy_BLL.Instance.GetListDK_BLL(sv.IDKhoa.Value, sv.IDSinhVien);
                SetData();
            }
        }
        private void ResetDataGridView()
        {
            dtgvHoatDong.CancelEdit();
            dtgvHoatDong.Columns.Clear();
            dtgvHoatDong.DataSource = null;
        }
        private void SetData()
        {
            dtgvHoatDong.Columns[0].HeaderText = "ID";
            dtgvHoatDong.Columns[1].HeaderText = "Tên hoạt động";
            dtgvHoatDong.Columns[2].HeaderText = "ID Sinh viên";
            dtgvHoatDong.Columns[3].HeaderText = "Thời gian";
            dtgvHoatDong.Columns[4].HeaderText = "ID đăng ký";
            dtgvHoatDong.Columns[5].HeaderText = "Trạng thái";
            dtgvHoatDong.Columns[6].HeaderText = "Ngày đăng ký";
            dtgvHoatDong.Columns[7].HeaderText = "Ngày huỷ đăng ký";


            dtgvHoatDong.Columns[2].Visible = false;
            dtgvHoatDong.Columns[4].Visible = false;

            dtgvHoatDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dtgvHoatDong.SelectedRows;
            if (r.Count == 0) return;
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            HoatDongForm hd = new HoatDongForm(r[0].Cells[0].Value.ToString(), typeUser);
            hd.VisibleButtonSave();
            this.D(hd);
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (TypeUser == "UserSinhVien")
            {
                if(CheckHuyDK())
                {
                    DataGridViewSelectedRowCollection r = dtgvHoatDong.SelectedRows;
                    DangKy dk = new DangKy
                    {
                        IDDangKy = Convert.ToInt32(r[0].Cells[4].Value.ToString()),
                        IDSinhVien = this.IDSinhVien,
                        IDHoatDong = r[0].Cells[0].Value.ToString(),
                        ThoiGianDangKy = Convert.ToDateTime(r[0].Cells[6].Value.ToString()),
                        ThoiGianHuyDangKy = DateTime.Now,
                        TrangThai = "Hủy đăng ký"
                    };
                    DangKy_BLL.Instance.CancelDK_BLL(dk);
                    DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
                    this.D = new MyDel(df.openForm);
                    QLHDForm hd = new QLHDForm(TypeUser, IDSinhVien);
                    this.D(hd);
                }
                else
                {
                    MessageBox.Show("Hoạt động này đã huỷ/chưa đăng ký!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ConfirmForm cf = new ConfirmForm();
                cf.ShowDialog();
                if (cf.ConfirmSuccess)
                {
                    DataGridViewSelectedRowCollection r = dtgvHoatDong.SelectedRows;
                    HoatDong_BLL.Instance.Del_BLL(r[0].Cells["Column1"].Value.ToString());
                    ShowHoatDongs();
                    MessageBox.Show("Xoa/Huy thanh cong");
                }
            }

        }
        private bool CheckHuyDK()
        {
            DataGridViewSelectedRowCollection r = dtgvHoatDong.SelectedRows;
            if (r[0].Cells[5].Value.ToString() == "Chưa đăng ký")
            {
                return false;
            }
            if (r[0].Cells[5].Value.ToString() == "Đã huỷ đăng ký")
            {
                return false;
            }
            return true;

        }

        private bool CheckDK()
        {
            DataGridViewSelectedRowCollection r = dtgvHoatDong.SelectedRows;
            if (r[0].Cells[5].Value.ToString() == "Đã đăng ký")
            {
                return false;
            }
            return true;
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if(TypeUser=="UserSinhVien")
            {
                if (CheckDK())
                {
                    DataGridViewSelectedRowCollection r = dtgvHoatDong.SelectedRows;
                    DangKy dangKy = new DangKy();
                    //Nếu hd là chưa đăng ký thì không có id dk nên try catch
                    try
                    {
                        dangKy = DangKy_BLL.Instance.GetDK_ByID_BLL(Convert.ToInt32(r[0].Cells[4].Value.ToString()));
                    }
                    catch (Exception)
                    {
                        dangKy = null;
                    }
                    if (dangKy == null)
                    {
                        DangKy dk = new DangKy
                        {
                            IDSinhVien = this.IDSinhVien,
                            IDHoatDong = r[0].Cells[0].Value.ToString(),
                            ThoiGianDangKy = DateTime.Now,
                            ThoiGianHuyDangKy = null,
                            TrangThai = "Đã đăng ký"
                        };
                        DangKy_BLL.Instance.AddDK_BLL(dk);
                    }
                    else
                    {
                        DangKy dk = new DangKy
                        {
                            IDDangKy = Convert.ToInt32(r[0].Cells[4].Value.ToString()),
                            IDSinhVien = IDSinhVien,
                            IDHoatDong = r[0].Cells[0].Value.ToString(),
                            ThoiGianDangKy = DateTime.Now,
                            ThoiGianHuyDangKy = null,
                            TrangThai = "Đã đăng ký"
                        };
                        DangKy_BLL.Instance.CancelDK_BLL(dk);
                    }

                    DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
                    this.D = new MyDel(df.openForm);
                    QLHDForm hd = new QLHDForm(TypeUser, IDSinhVien);
                    this.D(hd);
                }
                else
                {
                    MessageBox.Show("Hoạt động này đã đăng ký!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
                this.D = new MyDel(df.openForm);
                HoatDongForm hd = new HoatDongForm("", typeUser);
                this.D(hd);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dtgvHoatDong.SelectedRows;
            if (r.Count == 0) return;

            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            HoatDongForm hd = new HoatDongForm(r[0].Cells[0].Value.ToString(), typeUser);
            this.D(hd);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbKhoa.SelectedIndex == 0)
                {
                    try
                    {
                        dtgvHoatDong.DataSource = HoatDong_BLL.Instance.Get_ConstainName_BLL(txtTimKiem.Text, 0);
                    }
                    catch (Exception)
                    {
                        ShowHoatDongs();
                    }
                }
                else
                {
                    int id_Khoa = ((Khoa_DTO)cbbKhoa.SelectedItem).IDKhoa;
                    try
                    {
                        dtgvHoatDong.DataSource = HoatDong_BLL.Instance.Get_ConstainName_BLL(txtTimKiem.Text, id_Khoa);
                    }
                    catch (Exception)
                    {
                        dtgvHoatDong.DataSource = HoatDong_BLL.Instance.Get_ByKhoa_BLL(id_Khoa);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void QLHD1_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
            {
                btnXem.Image = new Bitmap("Resource\\Read64.png");
                btnHuy.Image = new Bitmap("Resource\\Delete64.png");
                btnTao.Image = new Bitmap("Resource\\Create64.png");
                btnSua.Image = new Bitmap("Resource\\Edit64.png");
            }
            else
            {
                btnXem.Image = new Bitmap("Resource\\Read32.png");
                btnHuy.Image = new Bitmap("Resource\\Delete32.png");
                btnTao.Image = new Bitmap("Resource\\Create32.png");
                btnSua.Image = new Bitmap("Resource\\Edit32.png");
            }
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbKhoa.SelectedIndex == 0)
            {
                ShowHoatDongs();
            }
            else
            {
                dtgvHoatDong.DataSource = HoatDong_BLL.Instance.Get_ByKhoa_BLL(((Khoa_DTO)cbbKhoa.SelectedItem).IDKhoa);
            }
        }
    }
}
