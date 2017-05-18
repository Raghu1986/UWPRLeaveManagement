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
            if(EmpListSplitView.IsPaneOpen)
            {
                AutoSugBoxEmps.Visibility = Visibility.Visible;
            }
            else
            {
                AutoSugBoxEmps.Visibility = Visibility.Collapsed;
            }
            
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
                string setValue = String.Format("{{\"$set\":{{\"LeaveStatus\":\"{0}\",\"ApprovedBy\":\"{1}\",\"ApprovedDate\":\"{2}\",\"ApprovedTime\":\"{3}\"}}}}", "2", empid, DateTimeToDateIndian.GetDateFromDateTime(DateTime.Now.ToString("G")), DateTime.Now.ToString("hh:mm tt"));


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

        private async void AutoSugBoxEmps_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (String.IsNullOrEmpty(sender.Text))
            {
                await EmployeeSync.GetAllEmployeesAsnc(EmployeeCharacters, "All");
                await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, "All", "1");
            }
            else
            {
                String after = sender.Text.Substring(0, 1).ToUpper() + sender.Text.Substring(1);
                var autoSuggestbox = (AutoSuggestBox)sender;
                var Suggestions = EmployeeCharacters.Where(p => p.EmpFirstName.StartsWith(after)).Select(p=>p.EmpFirstName).ToList();
                autoSuggestbox.ItemsSource = Suggestions;
            }
            
        }

        private async void AutoSugBoxEmps_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            ProgressRingAutosuggestionLoad.IsActive = true;
            ProgressRingAutosuggestionLoad.Visibility = Visibility.Visible;
            string ChooseItem=args.SelectedItem.ToString();
            if (String.IsNullOrEmpty(ChooseItem))
            {
                await EmployeeSync.GetAllEmployeesAsnc(EmployeeCharacters, "All");
                await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, "All", "1");
            }
            else
            { 
                await EmployeeSync.GetAutosuggestEmployeesAsnc(EmployeeCharacters, ChooseItem);
                await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, EmployeeCharacters[0].EmpId, "1");
            }

            ProgressRingAutosuggestionLoad.IsActive = false;
            ProgressRingAutosuggestionLoad.Visibility = Visibility.Collapsed;
        }

        private async void AutoSugBoxEmps_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            ProgressRingAutosuggestionLoad.IsActive = true;
            ProgressRingAutosuggestionLoad.Visibility = Visibility.Visible;
            string QueryItem = args.QueryText.ToString();
            if (String.IsNullOrEmpty(QueryItem))
            {
                await EmployeeSync.GetAllEmployeesAsnc(EmployeeCharacters, "All");
                await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, "All", "1");
            }
            else
            { 
                await EmployeeSync.GetAutosuggestEmployeesAsnc(EmployeeCharacters, QueryItem);
                await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, EmployeeCharacters[0].EmpId, "1");
            }
            ProgressRingAutosuggestionLoad.IsActive = false;
            ProgressRingAutosuggestionLoad.Visibility = Visibility.Collapsed;
        }

        private async void AutoSugBoxEmps_Unloaded(object sender, RoutedEventArgs e)
        {
            ProgressRingAutosuggestionLoad.IsActive = true;
            ProgressRingAutosuggestionLoad.Visibility = Visibility.Visible;

            await EmployeeSync.GetAllEmployeesAsnc(EmployeeCharacters, "All");
            await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, "All", "1");

            ProgressRingAutosuggestionLoad.IsActive = false;
            ProgressRingAutosuggestionLoad.Visibility = Visibility.Collapsed;
        }
    }
}
