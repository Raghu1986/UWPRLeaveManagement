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
    public sealed partial class LeaveListPageNonAdmin : Page
    {
        public ObservableCollection<Leavetransaction> LeaveTransactions { get; set; }

        public LeaveListPageNonAdmin()
        {
            this.InitializeComponent();
            LeaveTransactions = new ObservableCollection<Leavetransaction>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await LeaveTransactionGetPostPut.GetLeaveTransactionAsnc(LeaveTransactions, "201112005","4");
        }
    }
}
