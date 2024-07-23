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

namespace PROJECT_OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string sql;
        string chuoiketnoi = @"Data Source=LAPTOP-FAD3KR2U\SQLEXPRESS01;Initial Catalog=KHACHHANG;Integrated Security=True";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.PHONG' table. You can move, or remove it, as needed.
            this.pHONGTableAdapter.Fill(this.dataSet1.PHONG);
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Select MaKH, HoVaTen, SoCCCD,NgayDen,MaPhong From KHACHHANG1 ";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView1.Items.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[4].ToString());
                i++;

            }
            ketnoi.Close();

            listView4.Items.Clear();
            ketnoi.Open();
            sql = "SELECT MaHD, NgayThanhToan, TongTien, MaPhong, MaKH FROM dbo.QLHoaDon";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            while (docdulieu.Read())
            {
                ListViewItem item = new ListViewItem(docdulieu["MaHD"].ToString());
                item.SubItems.Add(docdulieu["NgayThanhToan"].ToString());
                item.SubItems.Add(docdulieu["TongTien"].ToString());
                item.SubItems.Add(docdulieu["MaPhong"].ToString());
                item.SubItems.Add(docdulieu["MaKH"].ToString());
                listView4.Items.Add(item);
            }
            ketnoi.Close();
        }

        private void btntkmaphong_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = "Select MaKH, HoVaTen, SoCCCD,NgayDen,MaPhong From KHACHHANG1 Where (MaPhong like '%" + cbmaphong.Text + "%')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView1.Items.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[4].ToString());
                i++;

            }
            ketnoi.Close();

        }

        private void btntkhovaten_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = "Select MaKH, HoVaTen, SoCCCD,NgayDen,MaPhong From KHACHHANG1 Where (HoVaTen like '%" + txthovaten.Text + "%')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView1.Items.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[4].ToString());
                i++;

            }
            ketnoi.Close();
        }

        private void btntinhtien_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            sql = @"Select PHONG.MaPhong, KHACHHANG1.HoVaTen, Datediff(day,KHACHHANG1.NgayDen, GETDATE()), Datediff(day,KHACHHANG1.NgayDen, GETDATE()) * PHONG.DonGia
FROM        PHONG Inner Join KHACHHANG1
ON          PHONG.MaPhong = KHACHHANG1.MaPhong
Where       (KHACHHANG1.MaPhong = N'" + cbmaphong.Text + @"') and      (KHACHHANG1.HoVaTen = N'" + txthovaten.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            while (docdulieu.Read())
            {
                lbphong.Text = docdulieu[0].ToString();
                lbsongayo.Text = docdulieu[2].ToString();
                lbtongtien.Text = docdulieu[3].ToString();
                i++;
            }
            ketnoi.Close();
        }

      


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cbmaphong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
 
                // Hiển thị MessageBox với các nút Yes và No
                var result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thoát Ứng Dụng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra xem người dùng đã nhấn Yes hay chưa
                if (result == DialogResult.Yes)
                {
                    this.Close(); // Đóng form hiện tại và thoát ứng dụng nếu đây là form chính
                }
            

        }

        private void listView1_Click(object sender, EventArgs e)
        {

                cbmaphong.Text = listView1.SelectedItems[0].SubItems[4].Text;
                txthovaten.Text = listView1.SelectedItems[0].SubItems[1].Text;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnxemtinhtrang_Click(object sender, EventArgs e)
        {
            
                listView2.Items.Clear();
                ketnoi.Open();
                sql = "SELECT MaPhong, TinhTrang FROM dbo.PHONG";
                thuchien = new SqlCommand(sql, ketnoi);
                docdulieu = thuchien.ExecuteReader();

                while (docdulieu.Read())
                {
                    string maPhong = docdulieu["MaPhong"].ToString();
                    string tinhTrang = docdulieu["TinhTrang"].ToString();

                    ListViewItem item = new ListViewItem(maPhong);
                    item.SubItems.Add(tinhTrang);
                    listView2.Items.Add(item);
                }

                ketnoi.Close();
            

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnbooking_Click(object sender, EventArgs e)
        {

        }

        private void btndatphong_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btndatphong_Click_1(object sender, EventArgs e)
        {

      
                // Lấy thông tin từ các controls
                string maKH = makh.Text; // Giả định rằng tên của TextBox là makh
                string hoTen = txthoten.Text; // Giả định rằng tên của TextBox là txthoten
                string cccd = txtcccd.Text; // Giả định rằng tên của TextBox là txtcccd
                DateTime ngayNhanPhong = datengaynhanphong.Value; // Giả định rằng tên của DateTimePicker là datengaynhanphong
                DateTime ngayTraPhong = datengaytraphong.Value; // Giả định rằng tên của DateTimePicker là datengaytraphong
                string loaiPhong = cbloaiphong.Text; // Giả định rằng tên của ComboBox là cbloaiphong

                // Thêm dữ liệu vào listView3
                var item = new ListViewItem(new[] {
        maKH,
        hoTen,
        cccd,
        ngayNhanPhong.ToString("yyyy-MM-dd"),
        ngayTraPhong.ToString("yyyy-MM-dd"),
        loaiPhong
    });
                listView3.Items.Add(item);

                // Kết nối và thêm dữ liệu vào cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                {
                    try
                    {
                        conn.Open();
                        // Tạo SQL command để insert dữ liệu
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.booking (MaKH, HoVaTen, SoCCCD, NgayNhanPhong, NgayTraPhong, LoaiPhong) VALUES (@MaKH, @HoVaTen, @SoCCCD, @NgayNhanPhong, @NgayTraPhong, @LoaiPhong)", conn))
                        {
                            // Thêm các parameters vào command
                            cmd.Parameters.AddWithValue("@MaKH", maKH);
                            cmd.Parameters.AddWithValue("@HoVaTen", hoTen);
                            cmd.Parameters.AddWithValue("@SoCCCD", cccd);
                            cmd.Parameters.AddWithValue("@NgayNhanPhong", ngayNhanPhong);
                            cmd.Parameters.AddWithValue("@NgayTraPhong", ngayTraPhong);
                            cmd.Parameters.AddWithValue("@LoaiPhong", loaiPhong);

                            // Thực thi command
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Đặt phòng thành công và thông tin đã được thêm vào danh sách!");
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Nếu có lỗi, hiển thị thông báo và xóa item khỏi listView3
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                        listView3.Items.Remove(item);
                    }
                    finally
                    {
                        // Đóng kết nối
                        conn.Close();
                    }
                }
            

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnchinhsua_Click(object sender, EventArgs e)
        {

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn một hàng trong listView3 chưa
            if (listView3.SelectedItems.Count > 0)
            {
                // Hiển thị hộp thoại xác nhận với người dùng
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Xóa dòng được chọn từ listView3
                    foreach (ListViewItem item in listView3.SelectedItems)
                    {
                        listView3.Items.Remove(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.");
            }
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtcccd_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthemhoadon_Click(object sender, EventArgs e)
        {
           
                // Lấy dữ liệu từ các control trên form
                string maHD = txtMaHoaDon.Text; // Lấy Mã Hóa Đơn từ TextBox
                string maKH = txtMaKH.Text; // Lấy Mã Khách Hàng từ TextBox
                DateTime ngayThanhToan = dateTimePickerNgayThanhToan.Value; // Lấy Ngày Thanh Toán từ DateTimePicker
                string maPhong = comboBoxMaPhong.Text; // Lấy Mã Phòng từ ComboBox
                int tongTien; // Khởi tạo biến để chứa giá trị Tổng Tiền

                // Kiểm tra định dạng và chuyển đổi giá trị Tổng Tiền từ TextBox
                if (!int.TryParse(txtTongTien.Text, out tongTien))
                {
                    MessageBox.Show("Tổng tiền phải là một số nguyên.");
                    return;
                }

                // Tiến hành kết nối và thêm hóa đơn mới vào cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO dbo.QLHoaDon (MaHD, NgayThanhToan, TongTien, MaPhong, MaKH) VALUES (@MaHD, @NgayThanhToan, @TongTien, @MaPhong, @MaKH)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaHD", maHD);
                            cmd.Parameters.AddWithValue("@NgayThanhToan", ngayThanhToan);
                            cmd.Parameters.AddWithValue("@TongTien", tongTien);
                            cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                            cmd.Parameters.AddWithValue("@MaKH", maKH);
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Hóa đơn đã được thêm thành công.");
                            }
                            else
                            {
                                MessageBox.Show("Không thêm được hóa đơn.");
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Có lỗi khi thêm hóa đơn: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

                // Gọi hàm hiển thị hóa đơn mới trên listView4
                hienthi();
            }

        private void btnXoaa_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa.");
                return;
            }

            // Lấy MaHD từ mục được chọn trong listView4
            string maHD = listView4.SelectedItems[0].Text; // Giả định MaHD là cột đầu tiên trong ListView

            // Xác nhận trước khi xóa
            DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM dbo.QLHoaDon WHERE MaHD = @MaHD";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaHD", maHD);
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Hóa đơn đã được xóa thành công.");
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy hóa đơn để xóa.");
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Có lỗi khi xóa hóa đơn: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

                // Xóa mục khỏi ListView
                listView4.Items.Remove(listView4.SelectedItems[0]);

                // Cập nhật ListView để phản ánh sự thay đổi
                hienthi();
            }
        }


        // Đảm bảo bạn đã định nghĩa hàm hienthiHoaDon để cập nhật listView4



    }
}
