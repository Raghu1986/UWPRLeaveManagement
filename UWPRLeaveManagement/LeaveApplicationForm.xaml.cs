using Microsoft.Toolkit.Uwp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

    public sealed partial class LeaveApplicationForm : Page

    {

        public ObservableCollection<HolidayMaster> HolidayDates { get; set; }
        public ObservableCollection<EmployeeMaster> EmployeeCharacters { get; set; }
        public string LeavePeriod;


        public LeaveApplicationForm()

        {

            

            this.InitializeComponent();

            HolidayDates = new ObservableCollection<HolidayMaster>();
            EmployeeCharacters = new ObservableCollection<EmployeeMaster>();

            //ArrivaltimeComboBox.SelectedIndex = ArrivaltimeComboBox.Items.Count - 1;
            // DeparturetimeComboBox.SelectedIndex = 0;

        }

        private double GetDepartWorkingHours(string intitHour)

        {
            double Workinghours = 0;
            double LeaveWhours = 0;
            double TotalWorkingWhour = 9;

            if (intitHour == "10:00 AM")
            {
                Workinghours =  0;

            }
            else if (intitHour== "10:30 AM")
            {
                Workinghours = 0.5;

            }
                else if(intitHour== "11:00 AM")
            {
                Workinghours =  1;
            }
            else if (intitHour == "11:30 AM")
            {
                Workinghours = 1.5;
            }
        
                else if(intitHour=="12:00")
            {
                Workinghours =  2;
            }
            else if (intitHour == "12:30 PM")
            {
                Workinghours =  2.5;
            }
            
            else if (intitHour == "01:00 PM")
            {
                Workinghours =  3.5;
            }
            else if (intitHour == "01:30 PM")
            {
                Workinghours =  4;
            }
            else if (intitHour == "02:00 PM")
            {
                Workinghours =  4;
            }
            else if (intitHour == "02:30 PM")
            {
                Workinghours = 4.5;
            }
            else if (intitHour == "03:30 PM")
            {
                Workinghours =  5;
            }
            else if (intitHour == "04:00 PM")
            {
                Workinghours =  5.5;
            }
            else if (intitHour == "04:30 PM")
            {
                Workinghours =  6;
            }
            else if (intitHour == "04:30 PM")
            {
                Workinghours =  6.5;
            }
            else if (intitHour == "05:00 PM")
            {
                Workinghours =  7;
            }
            else if (intitHour == "05:30 PM")
            {
                Workinghours =  7.5;
            }
            else if (intitHour == "06:00 PM")
            {
                Workinghours =  8;
            }
            else if (intitHour == "06:30 PM")
            {
                Workinghours =  8.5;
            }
            else if (intitHour == "07:00 PM")
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

            if (intitHour == "10:00 AM")
            {
                Workinghours = Workinghours- 0;

            }
            else if (intitHour == "10:30 AM")
            {
                Workinghours = Workinghours- 0.5;

            }
            else if (intitHour == "11:00 AM")
            {
                Workinghours = Workinghours- 1;
            }
            else if (intitHour == "11:30 AM")
            {
                Workinghours = Workinghours- 1.5;
            }

            else if (intitHour == "12:00 PM")
            {
                Workinghours = Workinghours- 2;
            }
            else if (intitHour == "12:30 PM")
            {
                Workinghours = Workinghours- 2.5;
            }
            
            else if (intitHour == "01:00 PM")
            {
                Workinghours = Workinghours- 3.5;
            }
            else if (intitHour == "01:30 PM")
            {
                Workinghours = Workinghours- 4;
            }
            else if (intitHour == "02:00 PM")
            {
                Workinghours = Workinghours- 4;
            }
            else if (intitHour == "02:30 PM")
            {
                Workinghours = Workinghours- 4.5;
            }
            else if (intitHour == "03:30 PM")
            {
                Workinghours = Workinghours- 5;
            }
            else if (intitHour == "04:00 PM")
            {
                Workinghours = Workinghours- 5.5;
            }
            else if (intitHour == "04:30 PM")
            {
                Workinghours = Workinghours- 6;
            }
            else if (intitHour == "04:30 PM")
            {
                Workinghours = Workinghours- 6.5;
            }
            else if (intitHour == "05:00 PM")
            {
                Workinghours = Workinghours- 7;
            }
            else if (intitHour == "05:30 PM")
            {
                Workinghours = Workinghours- 7.5;
            }
            else if (intitHour == "06:00 PM")
            {
                Workinghours = Workinghours- 8;
            }
            else if (intitHour == "06:30 PM")
            {
                Workinghours = Workinghours- 8.5;
            }
            else if (intitHour == "07:00 PM")
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

        private int GetNumberOfWorkingDaysExceptHolidays(DateTime start, DateTime stop)

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

            int days = 0;

            while (start <= stop)

            {

                var HolidayCnt = HolidayDateList.Count();



                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)

                {

                    ++days;

                }



                while (HolidayCnt > 0)

                {

                    --HolidayCnt;

                    if (start.Date == HolidayDateList[HolidayCnt].Date)

                    {

                        --days;

                    }



                }



                start = start.AddDays(1);

            }

            return days;

        }

        private double GetNumberOfLeaveDays(string intitDepartureHour,string intitArrivalHour)
        {
            double Leavedays = 0;

            //var intitArrivalHour = ArrivaltimeComboBox.SelectionBoxItem.ToString();
            //var intitDepartureHour = DeparturetimeComboBox.SelectedItem.ToString();

            double DepartureDayWorkingHour = GetDepartWorkingHours(intitDepartureHour);
            double ArrivalDayWorkingHour = GetArrivalWorkingHours(intitArrivalHour);

            double TotalWorkingHour = DepartureDayWorkingHour + ArrivalDayWorkingHour;

            double cnt = GetNumberOfWorkingDaysExceptHolidays(Convert.ToDateTime(DepartureDateCalendar.Date.ToString()), Convert.ToDateTime(ArrivalDateCalendar.Date.ToString()));

            if (TotalWorkingHour >= 4 && TotalWorkingHour < 8)
            {

                Leavedays = cnt - 0.5;

                

            }
            else if (TotalWorkingHour >= 8 && TotalWorkingHour < 12)
            {

                Leavedays = cnt - 1;

            }

            else if (TotalWorkingHour >= 12 && TotalWorkingHour < 14)
            {

                Leavedays = cnt - 1.5;

            }

            else if (TotalWorkingHour >= 14)
            {

                Leavedays = cnt - 2;

            }

            else if (TotalWorkingHour >= 8)
            {

                Leavedays = cnt - 1;

            }

            else
            {
                Leavedays = cnt;
            }



            return Leavedays;
            
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)

        {
            ProgressRingFormLoad.IsActive = true;
            ProgressRingFormLoad.Visibility = Visibility.Visible;

            await HolidaySync.GetHolidayListAsnc(HolidayDates);

            //TimeResult.Text = await LeaveTransactionPost.LeaveDataPostAsync
            //    (
            //    "201112005", "Rakshith",
            //    "C", "Software Engineer",
            //    "Madhusudan", "DOT NET",
            //    "25-04-2017", "10:00 AM",
            //    "30-04-2017", "02:30 PM",
            //    "19-04-2017", "12:04 PM",
            //    "3 and half days", "Health",
            //    "I am not feeling well so shall i take leave on thease days", "Madhusudan",
            //    "20-04-2017", "11:00 AM",
            //    "1"
            //    );

          

            DepartureDateCalendar.MinDate = DateTime.Now;

            ArrivalDateCalendar.MinDate = DateTime.Now;

            DepartureDateCalendar.Date = DateTime.Now;

            ProgressRingFormLoad.IsActive = false;
            ProgressRingFormLoad.Visibility = Visibility.Collapsed;

        }

        


        private void DepartureDateCalendar_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)

        {
            
            if (DepartureDateCalendar.Date == null)
            {
                DepartureDateCalendar.Date = DateTime.Now;
                ArrivalDateCalendar.Date = sender.Date.Value.AddHours(24);
            }
            ArrivalDateCalendar.Date = sender.Date.Value.AddHours(24); // .Date.Value.AddDays(1).Date;

            ArrivalDateCalendar.MinDate = sender.Date.Value;

            ArrivalDateCalendar.MaxDate = sender.Date.Value.AddDays(30).Date;

            string intitDepartureHour = DeparturetimeComboBox.SelectionBoxItem.ToString();
            string intitArrivalHour = ArrivaltimeComboBox.SelectionBoxItem.ToString();

            LeavePeriod = Days.GetNumbertoDays(GetNumberOfLeaveDays(intitDepartureHour, intitArrivalHour).ToString());

            Result.Text = "LEAVE PERIOD: " + LeavePeriod + " DAYS";
        }



        private void ArrivalDateCalendar_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)

        {
            
            if (ArrivalDateCalendar.Date == null)
            {
                //DepartureDateCalendar.Date = DateTime.Now;
                ArrivalDateCalendar.Date = DepartureDateCalendar.Date.Value.AddHours(24);
                
            }

            string intitDepartureHour = DeparturetimeComboBox.SelectionBoxItem.ToString();
            string intitArrivalHour = ArrivaltimeComboBox.SelectionBoxItem.ToString();

            
            LeavePeriod = Days.GetNumbertoDays(GetNumberOfLeaveDays(intitDepartureHour, intitArrivalHour).ToString());
            Result.Text = "Leave Period: " + LeavePeriod + " Days";

        }

        private void DeparturetimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            try
            {
                var SndrSel = (ComboBox)sender;
                var DepartureItem = (ComboBoxItem)SndrSel.SelectedItem;
                string intitDepartureHour = DepartureItem.Content.ToString();


                string intitArrivalHour = ArrivaltimeComboBox.SelectionBoxItem.ToString();

                LeavePeriod = Days.GetNumbertoDays(GetNumberOfLeaveDays(intitDepartureHour, intitArrivalHour).ToString());

                Result.Text = "Leave Period: " + LeavePeriod + " Days";
            }
            catch
            {

            }
            
        }

        private void ArrivaltimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            try
            {
                
            var SndrSel = (ComboBox)sender;
            var ArrivalItem = (ComboBoxItem)SndrSel.SelectedItem;
            string intitArrivalHour = ArrivalItem.Content.ToString();
            string intitDepartureHour = DeparturetimeComboBox.SelectionBoxItem.ToString();

        

                LeavePeriod = Days.GetNumbertoDays(GetNumberOfLeaveDays(intitDepartureHour, intitArrivalHour).ToString());
                Result.Text = "Leave Period: " + LeavePeriod + " Days" ;
            }
            catch
            {

            }

        }

        private async void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            
            ApplyButton.IsEnabled = false;
            ProgressRingApply.IsActive = true;
            ProgressRingApply.Visibility = Visibility.Visible;
                

            string Empid = "";
            var localObjectStorageHelper = new LocalObjectStorageHelper();
            // Read and Save with simple objects
            string keySimpleObject = "47";
            if (localObjectStorageHelper.KeyExists(keySimpleObject))
            {
                Empid = localObjectStorageHelper.Read<string>(keySimpleObject);
            }
            await EmployeeSync.GetAllEmployeesAsnc(EmployeeCharacters, Empid);


           // not used //string condition = String.Format("{{\"_id\":\"{0}\"}}", "58fdd151c2ef16688202ffa8");

            //Update the data working code
            //string condition = "58fde913bd966f74dc8f846d";
            //string setValue = String.Format("{{\"$set\":{{\"LeaveStatus\":\"{0}\"}}}}", "4");
            //await LeaveTransactionPost.LeaveTransactionPutAsync(condition, setValue);

            string EmpFirstName="";
            string EmpLastName="";
            string EmpDesignation="";
            string EmpReportingTo="";
            string EmpTeam="";
            string intitDeparturedate="";
            string intitDepartureHour = "";
            string intitArrivaldate = "";
            string intitArrivalHour = "";
            string AppliedDate = "";
            string AppliedTime = "";
            string LeavePeriodF = "";
            string LeaveType = "";
            string Description = "";
            string ApprovedBy = "";
            string ApprovedDate = "";
            string ApprovedTime = "";
            string LeaveStatus = "";
            string TransPkey = "";
            string EmpPath = "";


                EmpFirstName = EmployeeCharacters[0].EmpFirstName;
                EmpLastName = EmployeeCharacters[0].EmpLastName;
                EmpDesignation = EmployeeCharacters[0].EmpDesignation;
                EmpReportingTo = EmployeeCharacters[0].EmpReportingTo;
                EmpTeam = EmployeeCharacters[0].EmpTeam;
                EmpPath = EmployeeCharacters[0].EmpPath;



                intitDeparturedate = DateTimeToDateIndian.GetDateFromDateTime(DepartureDateCalendar.Date.Value.ToString("G"));
                intitDepartureHour = DeparturetimeComboBox.SelectionBoxItem.ToString();
                intitArrivaldate = DateTimeToDateIndian.GetDateFromDateTime(ArrivalDateCalendar.Date.Value.ToString("G"));
                intitArrivalHour = ArrivaltimeComboBox.SelectionBoxItem.ToString();
                AppliedDate= DateTimeToDateIndian.GetDateFromDateTime(DateTime.Now.ToString("G"));
                AppliedTime = DateTime.Now.ToString("hh:mm tt");
                LeavePeriodF = GetNumberOfLeaveDays(intitDepartureHour, intitArrivalHour).ToString();
                LeaveType = LeaveTypeComboBox.SelectionBoxItem.ToString();
                Description = DescriptionTextBox.Text.ToString();
                LeaveStatus = "1";

                TransPkey = RandomNumGen.GenerateRandomNumber().ToString() + Empid;


            if (Convert.ToDouble(LeavePeriodF)>0.5)
            {
                if (await LeaveTransactionGetPostPut.LeaveDataPostAsync
                (
                TransPkey, Empid,
                EmpFirstName, EmpLastName,
                EmpDesignation, EmpReportingTo,
                EmpTeam, EmpPath,
                intitDeparturedate,intitDepartureHour,
                intitArrivaldate,intitArrivalHour,
                AppliedDate,AppliedTime,
                LeavePeriodF,LeaveType,
                Description,ApprovedBy,
                ApprovedDate,ApprovedTime,
                LeaveStatus
                )=="OK")
                {
                    var messageDialog = new MessageDialog("Applied sucessfully");
                    await messageDialog.ShowAsync();
                    DepartureDateCalendar.Date = DateTime.Now;
                    ArrivalDateCalendar.Date = DateTime.Now.AddHours(24);
                    DescriptionTextBox.Text = "";
                    LeaveTypeComboBox.SelectedIndex = 0;

                }
                else
                {
                    var messageDialog = new MessageDialog("Not applied");
                    await messageDialog.ShowAsync();
                }

            }
            else
            {
                Result.Text = "Your leave period less than half day,Please take oral approve";
            }

            ProgressRingApply.IsActive = false;
            ProgressRingApply.Visibility = Visibility.Collapsed;
            ApplyButton.IsEnabled = true;

        }
    }

}