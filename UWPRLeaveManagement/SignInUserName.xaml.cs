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
    public sealed partial class SignInUserName : Page
    {
        public ObservableCollection<EmployeeMaster> EmployeeCharacters { get; set; }

        public SignInUserName()
        {
            this.InitializeComponent();
            EmployeeCharacters = new ObservableCollection<EmployeeMaster>();
        }

        private async  void EmpIdNextButton_Click(object sender, RoutedEventArgs e)
        {
            
            EmpIdNextButton.IsEnabled = false;
            ProgressRingUserName.IsActive = true;
            ProgressRingUserName.Visibility = Visibility.Visible;

            await EmployeeSync.GetAllEmployeesAsnc(EmployeeCharacters, EmpIdTextBox.Text);

            if (EmployeeCharacters.Count>0)
            {
                Frame.Navigate(typeof(SignInPassword), EmpIdTextBox.Text);
            }
            else if(EmployeeCharacters.Count == 0)
            {
                NotFindErrorTextBlock.Visibility = Visibility.Visible;
            }

            ProgressRingUserName.IsActive = false;
            ProgressRingUserName.Visibility = Visibility.Collapsed;
            EmpIdNextButton.IsEnabled = true;

        }

  

        private async void EmpIdTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Enter || e.Key == Windows.System.VirtualKey.Tab)
            {
                EmpIdNextButton.IsEnabled = false;
                ProgressRingUserName.IsActive = true;
                ProgressRingUserName.Visibility = Visibility.Visible;

                await EmployeeSync.GetAllEmployeesAsnc(EmployeeCharacters, EmpIdTextBox.Text);

                if (EmployeeCharacters.Count > 0)
                {
                    Frame.Navigate(typeof(SignInPassword), EmpIdTextBox.Text);
                }
                else if (EmployeeCharacters.Count == 0)
                {
                    NotFindErrorTextBlock.Visibility = Visibility.Visible;
                }

                ProgressRingUserName.IsActive = false;
                ProgressRingUserName.Visibility = Visibility.Collapsed;
                EmpIdNextButton.IsEnabled = true;
            }

        }
    }
}
