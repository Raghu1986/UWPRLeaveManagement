using Microsoft.Toolkit.Uwp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPRLeaveManagement.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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

    public sealed partial class LeaveListPageAdmin : Page
    {
        public ObservableCollection<EmployeeMaster> EmployeeCharacters { get; set; }
        public ObservableCollection<Leavetransaction> LeaveTransactions { get; set; }

        public LeaveListPageAdmin()
        {
            this.InitializeComponent();
            EmployeeCharacters = new ObservableCollection<EmployeeMaster>();
            LeaveTransactions = new ObservableCollection<Leavetransaction>();
        }

        private void ButtonHamburgerMain_Click(object sender, RoutedEventArgs e)
        {
            EmpListSplitView.IsPaneOpen = !EmpListSplitView.IsPaneOpen;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ProgressRingFormLoad.IsActive = true;
            ProgressRingFormLoad.Visibility = Visibility.Visible;

            await EmployeeSync.GetAllEmployeesAsnc(EmployeeCharacters, "All");
            await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, "All", "1");

            ProgressRingFormLoad.IsActive = false;
            ProgressRingFormLoad.Visibility = Visibility.Collapsed;

        }

        

        private async void EmployessListview_ItemClick(object sender, ItemClickEventArgs e)
        {
            var SelectedEmployee=(EmployeeMaster)e.ClickedItem;
            await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, SelectedEmployee.EmpId.ToString(), "1");
            
        }

        private async void AllEmployeeListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, "All", "1");
            
        }
        

        private async void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            
           
            try
            {
                
                var parent = (sender as Button).Parent;
                ProgressRing AcceptProgressRing = parent.GetChildrenOfType<ProgressRing>().First(x => x.Name == "AcceptProgressRing");
                AcceptProgressRing.IsActive = true;
                AcceptProgressRing.Visibility = Visibility.Visible;
                (sender as Button).IsEnabled = false;

                var SelectedSender = (FrameworkElement)sender;
                var SelectedItem = (Leavetransaction)SelectedSender.DataContext;
                

                //Update the data working code
                string condition = SelectedItem._id.Oid.ToString();
                string empid = SelectedItem.EmpId.ToString();
                string setValue = String.Format("{{\"$set\":{{\"LeaveStatus\":\"{0}\"}}}}", "2");
                await LeaveTransactionGetPostPut.LeaveTransactionPutAsync(condition, setValue);
                

                var messageDialog = new MessageDialog("Accepted");
                await messageDialog.ShowAsync();

                AcceptProgressRing.IsActive = false;
                AcceptProgressRing.Visibility = Visibility.Collapsed;
                (sender as Button).IsEnabled = true;

                await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, empid, "1");
            }
            catch
            {
                var messageDialog = new MessageDialog("not accepted !Error ");
                await messageDialog.ShowAsync();
                

                var parent = (sender as Button).Parent;
                ProgressRing AcceptProgressRing = parent.GetChildrenOfType<ProgressRing>().First(x => x.Name == "AcceptProgressRing");
                AcceptProgressRing.IsActive = false;
                AcceptProgressRing.Visibility = Visibility.Collapsed;
                (sender as Button).IsEnabled = true;

              

            }
            

        }

        private async void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var parent = (sender as Button).Parent;
                ProgressRing AcceptProgressRing = parent.GetChildrenOfType<ProgressRing>().First(x => x.Name == "RejectProgressRing");
                AcceptProgressRing.IsActive = true;
                AcceptProgressRing.Visibility = Visibility.Visible;
                (sender as Button).IsEnabled = false;

                var SelectedSender = (FrameworkElement)sender;
                var SelectedItem = (Leavetransaction)SelectedSender.DataContext;

                //Update the data working code
                string condition = SelectedItem._id.Oid.ToString();
                string empid = SelectedItem.EmpId.ToString();
                string setValue = String.Format("{{\"$set\":{{\"LeaveStatus\":\"{0}\"}}}}", "3");
                await LeaveTransactionGetPostPut.LeaveTransactionPutAsync(condition, setValue);

                var messageDialog = new MessageDialog("Rejected");
                await messageDialog.ShowAsync();

                AcceptProgressRing.IsActive = false;
                AcceptProgressRing.Visibility = Visibility.Collapsed;
                (sender as Button).IsEnabled = true;

                await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, empid, "1");

            }
            catch
            {
                var messageDialog = new MessageDialog("not rejected !Error ");
                await messageDialog.ShowAsync();

                var parent = (sender as Button).Parent;
                ProgressRing AcceptProgressRing = parent.GetChildrenOfType<ProgressRing>().First(x => x.Name == "RejectProgressRing");
                AcceptProgressRing.IsActive = false;
                AcceptProgressRing.Visibility = Visibility.Collapsed;
                (sender as Button).IsEnabled = true;
            }
            

        }

        private void LogoffButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        
    }
}
