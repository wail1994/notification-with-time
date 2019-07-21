using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V4.App;
using Android.Content;
using Java.Util;
using System;
using System.Runtime.Remoting.Contexts;
using Context = System.Runtime.Remoting.Contexts.Context;
using Java.Lang;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button d;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            d = FindViewById<Button>(Resource.Id.button1);
            d.Click += delegate
            {

                //set the current time and date for this calendar
                Java.Util.Calendar calendar = Java.Util.Calendar.Instance;
              
                calendar.Set(CalendarField.Hour, 5);
                calendar.Set(CalendarField.Minute, 21);

                var alarmIntent = new Intent(this, typeof(NotificationPublisher));
                AlarmManager alarmManager = (AlarmManager)GetSystemService(AlarmService);
                var pending = PendingIntent.GetBroadcast(this, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
               alarmManager = GetSystemService(AlarmService).JavaCast<AlarmManager>();
                alarmManager.SetRepeating(AlarmType.Rtc, calendar.TimeInMillis,
        AlarmManager.IntervalHour, pending);

                Toast.MakeText(this, "Alarm set In: " + d + " seconds", ToastLength.Short).Show();
            };

        }
        long GetDateTimeMS()
        {
            Java.Util.Calendar calendar = Java.Util.Calendar.Instance;
            calendar.TimeInMillis = Java.Lang.JavaSystem.CurrentTimeMillis();
            calendar.Set(CalendarField.Hour, 4);
            calendar.Set(CalendarField.Minute, 16);
            return calendar.TimeInMillis;
        }

        public void TimeSelectOnClick(object sender, EventArgs eventArgs)
        {
            TimePickerFragment frag = TimePickerFragment.NewInstance(
                delegate (DateTime time)
                {
                    int d = time.Hour;

                    long m = time.Minute;
                });

            frag.Show(FragmentManager, TimePickerFragment.TAG);
        }

        public void f() {





        } 









    }






}