﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaiTapCoBanSo2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void chkToanBo_Checked(object sender, RoutedEventArgs e)
        {
            chkCongNghe.IsChecked = true;
            chkDuLich.IsChecked = true;
            chkDaBong.IsChecked = true;
            chkXemPhim.IsChecked = true;

        }

        private void chkToanBo_Unchecked(object sender, RoutedEventArgs e)
        {
            chkCongNghe.IsChecked = false;
            chkDuLich.IsChecked = false;
            chkDaBong.IsChecked = false;
            chkXemPhim.IsChecked = false;
        }

        private void chkSub_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (chkCongNghe.IsChecked == true &&
                chkDuLich.IsChecked == true &&
                chkDaBong.IsChecked == true &&
                chkXemPhim.IsChecked == true)
            {
                chkToanBo.IsChecked = true; // checked toàn bộ
            }
            else if (chkCongNghe.IsChecked == false &&
                     chkDuLich.IsChecked == false &&
                     chkDaBong.IsChecked == false &&
                     chkXemPhim.IsChecked == false)
            {
                chkToanBo.IsChecked = false; // unchecked toàn bộ
            }
        }

        
    }
}