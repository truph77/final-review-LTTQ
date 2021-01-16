using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OnCuoiKy
{
    public partial class fMain : Form
    {
        DAO d = new DAO();
        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            dgvEmployee.DataSource = d.loadData();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

        }

        public bool check_field()
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Oops, nhập đủ thông tin bạn ơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (cbbDepartment.Text == string.Empty)
            {
                MessageBox.Show("Oops, nhập đủ thông tin bạn ơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbDepartment.Focus();
                return false;
            }
            if (cbbOffice.Text == string.Empty)
            {
                MessageBox.Show("Oops, nhập đủ thông tin bạn ơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbOffice.Focus();
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (check_field())
            {
                string s = @"INSERT INTO dbo.NhanVien( TenNV, Luong, MaPB, MaCV ) VALUES  ( (N'" + txtName.Text + "'), 400000, '" + (cbbDepartment.SelectedIndex + 1) + "', '" + (cbbOffice.SelectedIndex + 1) + "'  )";
                if (d.createData(s))
                {
                    MessageBox.Show("Oke rồi đó bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvEmployee.DataSource = d.loadData();
                }
                else
                {
                    MessageBox.Show("Không được rồi :<", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtName.Text = "";
                cbbDepartment.SelectedIndex = -1;
                cbbOffice.SelectedIndex = -1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát ư? T.T", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dgvEmployee.CurrentRow.Cells[0].Value.ToString());
            string s = @"UPDATE dbo.NhanVien SET TenNV= N'" + txtName.Text + "', MaPB='" + cbbDepartment.SelectedIndex + "', MaCV='" + cbbOffice.SelectedIndex + "' WHERE MaNV='" + i + "'";
            if (d.createData(s))
            {
                MessageBox.Show("Oke ròi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvEmployee.DataSource = d.loadData();
            }
            else
            {
                MessageBox.Show("Oh No", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dgvEmployee.CurrentRow.Cells[0].Value.ToString());
            string s = @"DELETE dbo.NhanVien WHERE MaNV = '" + i + "'";
            if (d.createData(s))
            {
                MessageBox.Show("Oke ròi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvEmployee.DataSource = d.loadData();
            }
            else
            {
                MessageBox.Show("Oh No", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dgvEmployee.Rows.Count == 0)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                txtName.Text = "";
                cbbDepartment.SelectedIndex = -1;
                cbbOffice.SelectedIndex = -1;

            }
        }

        private void dgvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployee.Rows.Count > 0)
            {
                txtName.Text = dgvEmployee.CurrentRow.Cells[1].Value.ToString();
                cbbDepartment.Text = dgvEmployee.CurrentRow.Cells[2].Value.ToString();
                cbbOffice.Text = dgvEmployee.CurrentRow.Cells[3].Value.ToString();

            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

        }

        private void cbbSort_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string s = @" SELECT MaNV, TenNV,PhongBan,ChucVu,Luong FROM dbo.PhongBan,dbo.NhanVien,dbo.ChucVu
		  WHERE ChucVu.MaCV = NhanVien.MaCV
		  AND PhongBan.MaPB = NhanVien.MaPB
		  AND TenNV LIKE N'%" + txtSearch.Text + "%'";
            dgvEmployee.DataSource = d.searhData(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    Image file;
            //    OpenFileDialog openFileDialog = new OpenFileDialog();

            //    //pictureBox1.ImageLocation =
            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        file = Image.FromFile(openFileDialog.FileName);
            //        pictureBox1.Image = file;

        }

    }
}
