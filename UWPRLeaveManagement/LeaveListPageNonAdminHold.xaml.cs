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
    public sealed partial class LeaveListPageNonAdminHold : Page
    {
        public ObservableCollection<Leavetransaction> LeaveTransactions { get; set; }

        

        public LeaveListPageNonAdminHold()
        {
            this.InitializeComponent();
            LeaveTransactions = new ObservableCollection<Leavetransaction>();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            string LeaveType = (string)e.Parameter;

            string empId = "";
            var localObjectStorageHelper = new LocalObjectStorageHelper();
            // Read and Save with simple objects
            string keySimpleObject = "47";
            if (localObjectStorageHelper.KeyExists(keySimpleObject))
            {
                empId = localObjectStorageHelper.Read<string>(keySimpleObject);
            }
            
            await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, empId, LeaveType);

        }

        private async void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

            var SelectedSender = (FrameworkElement)sender;
            var SelectedItem = (Leavetransaction)SelectedSender.DataContext;
            
            //Update the data working code
            string condition = SelectedItem._id.Oid.ToString();
            string empid = SelectedItem.EmpId.ToString();
            string setValue = String.Format("{{\"$set\":{{\"LeaveStatus\":\"{0}\"}}}}", "-1");
            await LeaveTransactionGetPostPut.LeaveTransactionPutAsync(condition, setValue);
            await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, empid, "1");

        }



    }
}
