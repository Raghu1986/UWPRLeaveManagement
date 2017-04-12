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

            

            this.InitializeComponent();

            HolidayDates = new ObservableCollection<HolidayMaster>();
           // DeparturetimeComboBox.SelectedIndex = 0;
           // ArrivaltimeComboBox.SelectedIndex = DeparturetimeComboBox.Items.Count - 1;

        }

        private double GetDepartWorkingHours(string intitHour)

        {
            double Workinghours = 0;
            double LeaveWhours = 0;
            double TotalWorkingWhour = 9;

            if (intitHour == "10:00")
            {
                Workinghours =  0;

            }
            else if (intitHour=="10:30")
            {
                Workinghours = 0.5;

            }
                else if(intitHour=="11:00")
            {
                Workinghours =  1;
            }
            else if (intitHour == "11:30")
            {
                Workinghours = 1.5;
            }
        
                else if(intitHour=="12:00")
            {
                Workinghours =  2;
            }
            else if (intitHour == "21:30")
            {
                Workinghours =  2.5;
            }
            else if (intitHour == "21:30")
            {
                Workinghours =  2.5;
            }
            else if (intitHour == "01:00")
            {
                Workinghours =  3.5;
            }
            else if (intitHour == "01:30")
            {
                Workinghours =  4;
            }
            else if (intitHour == "02:00")
            {
                Workinghours =  4;
            }
            else if (intitHour == "02:30")
            {
                Workinghours = 4.5;
            }
            else if (intitHour == "03:30")
            {
                Workinghours =  5;
            }
            else if (intitHour == "4:00")
            {
                Workinghours =  5.5;
            }
            else if (intitHour == "4:30")
            {
                Workinghours =  6;
            }
            else if (intitHour == "4:30")
            {
                Workinghours =  6.5;
            }
            else if (intitHour == "5:00")
            {
                Workinghours =  7;
            }
            else if (intitHour == "5:30")
            {
                Workinghours =  7.5;
            }
            else if (intitHour == "6:00")
            {
                Workinghours =  8;
            }
            else if (intitHour == "6:30")
            {
                Workinghours =  8.5;
            }
            else if (intitHour == "7:00")
            {
                Workinghours =  9;
            }
            else
            {
                Workinghours = 0;
            }

            LeaveWhours = TotalWorkingWhour - Workinghours;

            return Workinghours;
        }

        private double GetArrivalWorkingHours(string intitHour)

        {
            double Workinghours = 9;
            double LeaveWhours = 0;
            double TotalWorkingWhour = 9;

            if (intitHour == "10:00")
            {
                Workinghours = Workinghours- 0;

            }
            else if (intitHour == "10:30")
            {
                Workinghours = Workinghours- 0.5;

            }
            else if (intitHour == "11:00")
            {
                Workinghours = Workinghours- 1;
            }
            else if (intitHour == "11:30")
            {
                Workinghours = Workinghours- 1.5;
            }

            else if (intitHour == "12:00")
            {
                Workinghours = Workinghours- 2;
            }
            else if (intitHour == "21:30")
            {
                Workinghours = Workinghours- 2.5;
            }
            else if (intitHour == "21:30")
            {
                Workinghours = Workinghours- 2.5;
            }
            else if (intitHour == "01:00")
            {
                Workinghours = Workinghours- 3.5;
            }
            else if (intitHour == "01:30")
            {
                Workinghours = Workinghours- 4;
            }
            else if (intitHour == "02:00")
            {
                Workinghours = Workinghours- 4;
            }
            else if (intitHour == "02:30")
            {
                Workinghours = Workinghours- 4.5;
            }
            else if (intitHour == "03:30")
            {
                Workinghours = Workinghours- 5;
            }
            else if (intitHour == "4:00")
            {
                Workinghours = Workinghours- 5.5;
            }
            else if (intitHour == "4:30")
            {
                Workinghours = Workinghours- 6;
            }
            else if (intitHour == "4:30")
            {
                Workinghours = Workinghours- 6.5;
            }
            else if (intitHour == "5:00")
            {
                Workinghours = Workinghours- 7;
            }
            else if (intitHour == "5:30")
            {
                Workinghours = Workinghours- 7.5;
            }
            else if (intitHour == "6:00")
            {
                Workinghours = Workinghours- 8;
            }
            else if (intitHour == "6:30")
            {
                Workinghours = Workinghours- 8.5;
            }
            else if (intitHour == "7:00")
            {
                Workinghours = Workinghours- 9;
            }
            else
            {
                Workinghours = 0;
            }

            LeaveWhours = TotalWorkingWhour - Workinghours;

            return Workinghours;
        }

        private int GetNumberOfWorkingDays(DateTime start, DateTime stop, DateTime[] HolidayList)

        {

            int days = 0;

            while (start <= stop)

            {

                var HolidayCnt = HolidayList.Count();



                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)

                {

                    ++days;

                }



                while (HolidayCnt > 0)

                {

                    --HolidayCnt;

                    if (start.Date == HolidayList[HolidayCnt].Date)

                    {

                        --days;

                    }



                }



                start = start.AddDays(1);

            }

            return days;

        }



        private async void Page_Loaded(object sender, RoutedEventArgs e)

        {

            await HolidaySync.GetHolidayListAsnc(HolidayDates);

            DepartureDateCalendar.MinDate = DateTime.Now;

            ArrivalDateCalendar.MinDate = DateTime.Now;

        }









        private void DepartureDateCalendar_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)

        {

            ArrivalDateCalendar.Date = sender.Date.Value.AddDays(1).Date;

            ArrivalDateCalendar.MinDate = sender.Date.Value;

            ArrivalDateCalendar.MaxDate = sender.Date.Value.AddDays(30).Date;

        }



        private void ArrivalDateCalendar_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)

        {



            int HolidayCount = HolidayDates.Count;

            int HolidayArrayAddr = 0;

            DateTime[] HolidayDateList = new DateTime[HolidayCount];

            while (HolidayCount > 0)

            {

                --HolidayCount;

                HolidayDateList[HolidayArrayAddr] = Convert.ToDateTime(HolidayDates[HolidayCount].HDate.ToString());

                ++HolidayArrayAddr;



            }



            var cnt = GetNumberOfWorkingDays(Convert.ToDateTime(DepartureDateCalendar.Date.ToString()), Convert.ToDateTime(sender.Date.ToString()), HolidayDateList);

            Result.Text = cnt.ToString();

            //Result.Text = (ArrivalDateCalendar.Date.Value - DepartureDateCalendar.Date.Value).TotalDays.ToString();

        }

        private void DeparturetimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TimeResult == null) return;
            var SndrSel = (ComboBox)sender;
            var DepartureItem = (ComboBoxItem)SndrSel.SelectedItem;
            var intitHour = DepartureItem.Content.ToString();

            double DepartureDayLeaveHour = GetDepartWorkingHours(intitHour);
            TimeResult.Text = DepartureDayLeaveHour.ToString();
        }

        private void ArrivaltimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}