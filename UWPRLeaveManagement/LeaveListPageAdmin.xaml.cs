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

        private async void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            ProgressRingFormLoad.IsActive = true;
            ProgressRingFormLoad.Visibility = Visibility.Visible;
            try
            {
                var SelectedSender = (FrameworkElement)sender;
                var SelectedItem = (Leavetransaction)SelectedSender.DataContext;


                //Update the data working code
                string condition = SelectedItem._id.Oid.ToString();
                string empid = SelectedItem.EmpId.ToString();
                string setValue = String.Format("{{\"$set\":{{\"LeaveStatus\":\"{0}\"}}}}", "2");
                await LeaveTransactionGetPostPut.LeaveTransactionPutAsync(condition, setValue);
                await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, empid, "1");

                var messageDialog = new MessageDialog("Accepted");
                await messageDialog.ShowAsync();

                ProgressRingFormLoad.IsActive = false;
                ProgressRingFormLoad.Visibility = Visibility.Collapsed;
            }
            catch
            {
                var messageDialog = new MessageDialog("not accepted !Error ");
                await messageDialog.ShowAsync();

                ProgressRingFormLoad.IsActive = false;
                ProgressRingFormLoad.Visibility = Visibility.Collapsed;
            }
            

        }

        private async void ButtonReject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProgressRingFormLoad.IsActive = true;
                ProgressRingFormLoad.Visibility = Visibility.Visible;

                var SelectedSender = (FrameworkElement)sender;
                var SelectedItem = (Leavetransaction)SelectedSender.DataContext;

                //Update the data working code
                string condition = SelectedItem._id.Oid.ToString();
                string empid = SelectedItem.EmpId.ToString();
                string setValue = String.Format("{{\"$set\":{{\"LeaveStatus\":\"{0}\"}}}}", "3");
                await LeaveTransactionGetPostPut.LeaveTransactionPutAsync(condition, setValue);
                await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, empid, "1");

                var messageDialog = new MessageDialog("Rejected");
                await messageDialog.ShowAsync();

                ProgressRingFormLoad.IsActive = false;
                ProgressRingFormLoad.Visibility = Visibility.Collapsed;
            }
            catch
            {
                var messageDialog = new MessageDialog("not rejected !Error ");
                await messageDialog.ShowAsync();

                ProgressRingFormLoad.IsActive = false;
                ProgressRingFormLoad.Visibility = Visibility.Collapsed;
            }
            

        }
    }
}
