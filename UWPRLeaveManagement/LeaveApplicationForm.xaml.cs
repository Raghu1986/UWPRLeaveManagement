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
    public sealed partial class LeaveApplicationForm : Page
    {
        public ObservableCollection<HolidayMaster> HolidayDates { get; set; }

        public LeaveApplicationForm()
        {
            HolidayDates = new ObservableCollection<HolidayMaster>();
            this.InitializeComponent();
        }

        private static int GetNumberOfWorkingDays(DateTime start, DateTime stop)
        {
            int days = 0;
            while (start <= stop)
            {
                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                {
                    ++days;
                }
                start = start.AddDays(1);
            }
            return days;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StartDateCalendar.MinDate = DateTime.Now;
            EndDateCalendar.MinDate = DateTime.Now;
        }



       
        private void StartDateCalendar_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            EndDateCalendar.Date = sender.Date.Value.AddDays(1).Date; 
            EndDateCalendar.MinDate = sender.Date.Value;
            EndDateCalendar.MaxDate = sender.Date.Value.AddDays(30).Date;
        }

        private async void EndDateCalendar_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {

            await HolidaySync.GetHolidayListAsnc(HolidayDates);

            var cnt = GetNumberOfWorkingDays(Convert.ToDateTime(StartDateCalendar.Date.ToString()), Convert.ToDateTime(sender.Date.ToString()));
            Result.Text = cnt.ToString();
            //Result.Text = (EndDateCalendar.Date.Value - StartDateCalendar.Date.Value).TotalDays.ToString();
        }
    }
}
