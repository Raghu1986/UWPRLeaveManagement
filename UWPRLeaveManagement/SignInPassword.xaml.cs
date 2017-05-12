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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPRLeaveManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignInPassword : Page
    {
        public ObservableCollection<EmployeeMaster> EmployeeCharacters { get; set; }
        public ObservableCollection<EmployeeMaster> EmployeeLoginCharacters { get; set; }
        public string EmpUserId;

        public SignInPassword()
        {
            this.InitializeComponent();
            EmployeeCharacters = new ObservableCollection<EmployeeMaster>();
            EmployeeLoginCharacters = new ObservableCollection<EmployeeMaster>();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var empId = (string)e.Parameter;
            await EmployeeSync.GetAllEmployeesAsnc(EmployeeCharacters, empId);
            if (EmployeeCharacters.Count > 0)
            {
                EmpIdTextBlock.Text = EmployeeCharacters[0].EmpId;
                EmpNameTextBlock.Text = EmployeeCharacters[0].EmpFirstName;
                string icon = String.Format("ms-appx:///Assets/EmpPhotos/{0}.png", EmployeeCharacters[0].EmpId);
                ImageBrush.ImageSource = new BitmapImage(new Uri(icon, UriKind.Absolute));
            }

        }

        private async void EmpIdNextButton_Click(object sender, RoutedEventArgs e)
        {
            EmpIdNextButton.IsEnabled = false;
            ProgressRingPassword.IsActive = true;
            ProgressRingPassword.Visibility = Visibility.Visible;

            await EmployeeSync.GetLoginEmployeesAsnc(EmployeeLoginCharacters, EmployeeCharacters[0].EmpId,EmppasswordBox.Password);

            if (EmployeeLoginCharacters.Count > 0)
            {
                var localObjectStorageHelper = new LocalObjectStorageHelper();
                // Read and Save with simple objects for login page
                string keySimpleObject = "47";
                localObjectStorageHelper.Save(keySimpleObject, EmployeeCharacters[0].EmpId);

                if (EmployeeLoginCharacters[0].EmpGroup==1 )
                {
                    Frame.Navigate(typeof(NonAdminPage));
                }
                else if (EmployeeLoginCharacters[0].EmpGroup == 2)
                {
                    Frame.Navigate(typeof(LeaveListPageAdmin));
                }

                //
            }
            else if (EmployeeLoginCharacters.Count == 0)
            {
                NotFindErrorTextBlock.Visibility = Visibility.Visible;
            }

            ProgressRingPassword.IsActive = false;
            ProgressRingPassword.Visibility = Visibility.Collapsed;
            EmpIdNextButton.IsEnabled = true;


        }
    }
}
