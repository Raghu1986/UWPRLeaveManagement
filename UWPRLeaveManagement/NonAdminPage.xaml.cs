using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPRLeaveManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NonAdminPage : Page
    {
        public NonAdminPage()
        {
            this.InitializeComponent();
            NonAdminFrame.Navigate(typeof(LeaveApplicationForm));
        }

        private void LeaveBookButton_Click(object sender, RoutedEventArgs e)
        {
            NonAdminFrame.Navigate(typeof(LeaveApplicationForm));
        }


        private void LeaveApprovedButton_Click(object sender, RoutedEventArgs e)
        {
           // NonAdminFrame.Navigate(typeof(LeaveListPageNonAdminApproved), "2");
        }


        private void LeaveRejectecdButton_Click(object sender, RoutedEventArgs e)
        {
           // NonAdminFrame.Navigate(typeof(LeaveListPageNonAdminRejected), "3");
        }

        private void LeaveHoldButton_Click(object sender, RoutedEventArgs e)
        {
            NonAdminFrame.Navigate(typeof(LeaveListPageNonAdminHold), "1");
        }
    }
}
