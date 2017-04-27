﻿using Microsoft.Toolkit.Uwp;
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
            await EmployeeSync.GetAllEmployeesAsnc(EmployeeCharacters, "All");
            await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, "All", "");

            var localObjectStorageHelper = new LocalObjectStorageHelper();
            // Read and Save with simple objects for login page
            string keySimpleObject = "47";
            localObjectStorageHelper.Save(keySimpleObject, "201112005");


        }

        

        private async void EmployessListview_ItemClick(object sender, ItemClickEventArgs e)
        {
            var SelectedEmployee=(EmployeeMaster)e.ClickedItem;
            await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, SelectedEmployee.EmpId.ToString(), "1");
            
        }

        private async void AllEmployeeListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, "All", "");
        }
    }
}
