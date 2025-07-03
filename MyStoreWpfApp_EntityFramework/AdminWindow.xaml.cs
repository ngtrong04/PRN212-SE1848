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
using MyStoreWpfApp_EntityFramework.Models;

namespace MyStoreWpfApp_EntityFramework
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MyStoreContext context = new MyStoreContext();

        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoriesIntoTreeView();
        }

        private void LoadCategoriesIntoTreeView()
        {
            // tạo Gốc cây:
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hàng Bình Dương";
            tvCategory.Items.Add(root);
            // truy vẫn toàn bộ danh mục
            var categories = context.Categories.ToList();
            // đưa danh mụ vào cây:
            foreach (var category in categories)
            {
                // tạo node danh mục:
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = category.CategoryName;
                cate_node.Tag = category;
                root.Items.Add(cate_node);
                // lọc sản phẩm theo danh mục
                var products = context.Products
                    .Where(p => p.CategoryId == category.CategoryId)
                    .ToList();
                // nạp product vào Node danh mục tương ứng:
                foreach (var product in products)
                {
                    //tạo node cho product:
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product; // gán đối tượng Product vào Tag
                    cate_node.Items.Add(product_node);
                }

            }
            root.ExpandSubtree();
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null) return;
            TreeViewItem item = e.NewValue as TreeViewItem;
            if (item == null)
                return;
            Category category = item.Tag as Category;
            if (category == null)
                return;
            LoadProductsIntoListView(category);
        }

        private void LoadProductsIntoListView(Category category)
        {
            // lọc sản phẩm theo danh mục
            var products = context.Products
                .Where(p => p.CategoryId == category.CategoryId)
                .ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;
            Product product = e.AddedItems[0] as Product;
            DisplayProductDetail(product);
        }
        void DisplayProductDetail(Product product)
        {
            if (product == null)
            {
                txtId.Text = "";
                txtName.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = "";
            }
            else
            {
                txtId.Text = product.ProductId + "";
                txtName.Text = product.ProductName;
                txtQuantity.Text = product.UnitsInStock + "";
                txtPrice.Text = product.UnitPrice + "";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            DisplayProductDetail(null);
            txtId.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // bước 1: tìm danh mục mà ta muốn lưu product vào:
                // bước 2: tạo đối tượng product muốn lưu
                // buớc 3: gán giá trị cho các thuộc tính của product và lưu
                //bước 4: thực hiện cập nhật lại giao diện

                // Bước 1: tìm danh mục mà ta muốn lưu product vào:
                TreeViewItem cate_note = tvCategory.SelectedItem as TreeViewItem;
                if (cate_note == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục ", "Lỗi lưu sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Category category = cate_note.Tag as Category;
                if (category == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục ", "Lỗi lưu sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // bước 2: tạo đối tượng product muốn lưu
                Product product = new Product();
                // buớc 3: gán giá trị cho các thuộc tính của product và lưu
                product.ProductName = txtName.Text;
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                product.CategoryId = category.CategoryId; // gán CategoryId cho product
                context.Products.Add(product);
                context.SaveChanges();

                //bước 4: thực hiện cập nhật lại giao diện
                // bước 4.1: Nạp lại treeview - tạo product node cate node:
                TreeViewItem product_node = new TreeViewItem();
                product_node.Header = product.ProductName;
                product_node.Tag = product; // gán đối tượng Product vào Tag
                cate_note.Items.Add(product_node);
                // buoc 4.2: Nạp lại listview:
                LoadProductsIntoListView(category);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi lưu sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //B1: tìm sản phẩm muốn sửa chữa
                //B2: tiến hành thay đổi giá trị các thuộc tính
                //B3: thực hiện lưu
                //B4: cập nhật lại giao diện treeview và listview
                // CHI TIẾT :
                // B1: tìm sản phẩm muốn sửa chữa
                int id = int.Parse(txtId.Text);
                Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần sửa chữa", "Lỗi sửa sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //B2: tiến hành thay đổi giá trị các thuộc tính
                product.ProductName = txtName.Text;
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                product.UnitPrice = decimal.Parse(txtPrice.Text);

                //B3: thực hiện lưu
                context.SaveChanges();
                //B4: cập nhật lại giao diện treeview và listview

                // B4.1 : Nạp lại 
                TreeViewItem cate_note = tvCategory.SelectedItem as TreeViewItem;
                if (cate_note != null)
                {
                    Category category = cate_note.Tag as Category;

                    if (category != null)
                    {
                        // xóa toàn bộ con cũ của cate_ note
                        cate_note.Items.Clear();
                        // nạp lại Product
                        // lọc sản phẩm theo danh mục
                        var products = context.Products
                            .Where(p => p.CategoryId == category.CategoryId)
                            .ToList();
                        // nạp product vào Node danh mục tương ứng:
                        foreach (var product_update in products)
                        {
                            //tạo node cho product:
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = product_update.ProductName;
                            product_node.Tag = product_update; // gán đối tượng Product vào Tag
                            cate_note.Items.Add(product_node);
                        }
                        // B4.2: Nạp lại listview:
                        LoadProductsIntoListView(category);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi cập nhật sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //B1: tìm sản phẩm muốn xóa
                //B2: hỏi xác nhận
                //B3: thực hiện xóa
                //B4: cập nhật lại giao diện treeview và listview
                // B1: tìm sản phẩm muốn xóa
                int id = int.Parse(txtId.Text);
                Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm nào để có mã ={id} xóa", "Lỗi xóa sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBoxResult rs = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm [{product.ProductName}] không?", "Xác nhận xóa sản phẩm", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rs == MessageBoxResult.No)
                {
                    return; // không xóa
                }
                context.Products.Remove(product);
                context.SaveChanges();
                // B4: cập nhật lại giao diện treeview và listview
                // B4.1 : Nạp lại
                TreeViewItem cate_note = tvCategory.SelectedItem as TreeViewItem;
                if (cate_note != null)
                {
                    Category category = cate_note.Tag as Category;
                    if (category != null)
                    {
                        // xóa toàn bộ con cũ của cate_ note
                        cate_note.Items.Clear();
                        // nạp lại Product
                        // lọc sản phẩm theo danh mục
                        var products = context.Products
                            .Where(p => p.CategoryId == category.CategoryId)
                            .ToList();
                        // nạp product vào Node danh mục tương ứng:
                        foreach (var product_update in products)
                        {
                            //tạo node cho product:
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = product_update.ProductName;
                            product_node.Tag = product_update; // gán đối tượng Product vào Tag
                            cate_note.Items.Add(product_node);
                        }
                        // B4.2: Nạp lại listview:
                        LoadProductsIntoListView(category);
                        // xóa chi tiết 
                        DisplayProductDetail(null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi xóa sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }
    }
}
