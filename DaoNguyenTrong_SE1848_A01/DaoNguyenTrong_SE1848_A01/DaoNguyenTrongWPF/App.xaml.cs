using System.Configuration;
using System.Data;
using System.Windows;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Nếu bạn dùng DI hoặc splash screen thì cấu hình ở đây

        // Ví dụ: Xử lý lỗi toàn cục
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Ví dụ: Đăng ký DI, logging, global exception...
            // AppDomain.CurrentDomain.UnhandledException += (s, ex) => { ... };
        }

        // Nếu muốn xử lý khi tắt app
        // protected override void OnExit(ExitEventArgs e)
        // {
        //     base.OnExit(e);
        //     // Cleanup...
        // }
    }
}


