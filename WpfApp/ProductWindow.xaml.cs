using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using BusinessObjects;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductService  productService = new ProductService();
        bool isCompleted = false;
        public ProductWindow()
        {
            InitializeComponent();

            isCompleted = false;
            productService.GenerateSampleDataset();
            lvProduct.ItemsSource = productService.GetProducts();
            isCompleted = true;
        }

        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                Product p = new Product();
                p.Id = int.Parse(txtId.Text);
                p.Name = txtName.Text;
                p.Quantity = int.Parse(txtQuantity.Text);
                p.Price = double.Parse(txtPrice.Text);

                bool kq = productService.SaveProduct(p);
                if (kq)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productService.GetProducts();
                }
                isCompleted = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!" + ex.Message);
            }
            
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;

                int id = int.Parse(txtId.Text);
                Product p = productService.GetProduct(id);
                if (p == null)
                {
                    return; // không tìm thấy sản phẩm để sửa
                }
                // nếu tìm thấy thì thay đổi dữ liệu
                p.Name = txtName.Text;
                p.Quantity = int.Parse(txtQuantity.Text);
                p.Price = double.Parse(txtPrice.Text);

                bool kq = productService.UpdateProduct(p);
                if (kq)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productService.GetProducts();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để sửa!");
                }
                isCompleted = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!" + ex.Message);

            }
            
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isCompleted == false)
                return; // tránh trường hợp đang sửa mà click vào listview thì sẽ bị lỗi
            if (e.AddedItems.Count < 0)
                return; // không có sản phẩm nào được chọn
            // lấy ra Product
            Product p = e.AddedItems[0] as Product;
            if (p == null) return;
            // hiển thị lên các textbox
            txtId.Text = p.Id.ToString();
            txtName.Text = p.Name;
            txtQuantity.Text = p.Quantity.ToString();
            txtPrice.Text = p.Price.ToString(); 
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // luôn luôn phải xác thực có muốn xóa hay khômg
                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này không?", // nội dung hỏi
                                                          "Xác nhận xóa", //tiêu đề của cửa sửa 
                                                          MessageBoxButton.YesNo,  // hiển thị 2 lựa chọn YES/ NO cho người dùng
                                                          MessageBoxImage.Question); // hiển thi thị biểu tượng hỏi
                if (result == MessageBoxResult.No)
                    return; // nếu người dùng chọn No thì không làm gì cả
                isCompleted = false; // tránh trường hợp đang sửa mà click vào listview thì sẽ bị lỗi
                int id = int.Parse(txtId.Text);
                bool kq = productService.DeleteProduct(id);
                if (kq == false) return;

                lvProduct.ItemsSource = null; // xóa dữ liệu cũ
                lvProduct.ItemsSource = productService.GetProducts(); // lấy lại dữ liệu mới
                // xóa dữ liệu trên các textbox
                txtId.Text = "";
                txtName.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = "";

                isCompleted = true; // đã hoàn thành thao tác xóa

            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa bị lỗi: " + ex.Message);
            }
        }
    }
}
