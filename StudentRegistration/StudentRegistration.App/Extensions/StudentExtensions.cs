using System;

namespace StudentRegistration.App.Extensions
{
    public static class StudentExtensions
    {
        public static int GetAge(this DateTime birthday)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (birthday.Year * 100 + birthday.Month) * 100 + birthday.Day;

            return (a - b) / 10000;
        }
    }
}