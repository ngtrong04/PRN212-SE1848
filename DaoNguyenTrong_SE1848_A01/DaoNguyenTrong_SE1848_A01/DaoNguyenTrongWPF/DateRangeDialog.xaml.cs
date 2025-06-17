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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for DateRangeDialog.xaml
    /// </summary>
    public partial class DateRangeDialog : Window
    {
        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public DateRangeDialog()
        {
            InitializeComponent();
            dpFrom.SelectedDate = DateTime.Today.AddDays(-7); // mặc định 7 ngày gần nhất
            dpTo.SelectedDate = DateTime.Today;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (dpFrom.SelectedDate == null || dpTo.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ TỪ NGÀY và ĐẾN NGÀY.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (dpFrom.SelectedDate > dpTo.SelectedDate)
            {
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng Đến ngày.", "Sai khoảng thời gian", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            FromDate = dpFrom.SelectedDate.Value;
            ToDate = dpTo.SelectedDate.Value;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
