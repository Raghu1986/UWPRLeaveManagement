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
    public sealed partial class PasswordResetAdmin : Page
    {
        public ObservableCollection<EmployeeMaster> EmployeeCharacters { get; set; }
        public string OidPasswordreset;

        public PasswordResetAdmin()
        {
            this.InitializeComponent();
            EmployeeCharacters = new ObservableCollection<EmployeeMaster>();
        }
        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            OidPasswordreset = (string)e.Parameter;

        }

        private async void passwordResetButton_Click(object sender, RoutedEventArgs e)
        {
            
                if(string.IsNullOrEmpty(passwordResetBox.Password)||string.IsNullOrWhiteSpace(passwordResetBox.Password))
                {
                    var messageDialog = new MessageDialog("Type password before you click on change");
                    await messageDialog.ShowAsync();
                }
                else if(string.IsNullOrEmpty(OidPasswordreset) || string.IsNullOrWhiteSpace(OidPasswordreset))
                {
                    var messageDialog = new MessageDialog("Reselect employee");
                    await messageDialog.ShowAsync();
                }
                else
                {
                try
                {
                    ProgressRingPasswordReset.IsActive = true;
                    ProgressRingPasswordReset.Visibility = Visibility.Visible;

                    
                    string newPassword = "";
                    
                    newPassword = passwordResetBox.Password;


                    string condition = OidPasswordreset;
                    string setValue = String.Format("{{\"$set\":{{\"Password\":\"{0}\"}}}}", newPassword);
                    await EmployeeSync.EmpPasswordPutAsync(condition, setValue);

                    var messageDialog = new MessageDialog("Password changed");
                    await messageDialog.ShowAsync();

                    ProgressRingPasswordReset.Visibility = Visibility.Collapsed;
                    ProgressRingPasswordReset.IsActive = false;
                    passwordResetBox.Password = "";

                }
                catch
                {
                    var messageDialog = new MessageDialog("Password not changed  !Error ");
                    await messageDialog.ShowAsync();

                    ProgressRingPasswordReset.Visibility = Visibility.Collapsed;
                    ProgressRingPasswordReset.IsActive = false;
                }
            }
            
        }
    }
}
