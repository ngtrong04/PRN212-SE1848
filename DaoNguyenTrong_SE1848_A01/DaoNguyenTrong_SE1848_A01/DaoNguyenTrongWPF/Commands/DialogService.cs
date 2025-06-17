using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DaoNguyenTrongWPF.Commands
{
    public class DialogService
    {
        /// <summary>
        /// Hiển thị một dialog (Window) và trả về kết quả DialogResult.
        /// </summary>
        /// <param name="dialog">Window cần hiển thị.</param>
        /// <returns>True nếu OK, False nếu Cancel hoặc đóng.</returns>
        public bool? ShowDialog(Window dialog)
        {
            return dialog?.ShowDialog();
        }

        /// <summary>
        /// Hiển thị một thông báo MessageBox.
        /// </summary>
        public void ShowMessage(string message, string title = "Thông báo", MessageBoxButton buttons = MessageBoxButton.OK, MessageBoxImage icon = MessageBoxImage.Information)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        /// <summary>
        /// Hiển thị một hộp thoại xác nhận Yes/No.
        /// </summary>
        public bool ShowConfirmation(string message, string title = "Xác nhận")
        {
            return MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }
    }
}
