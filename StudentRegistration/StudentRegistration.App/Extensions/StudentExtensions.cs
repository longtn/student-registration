using System;

namespace StudentRegistration.App.Extensions
{
    public static class StudentExtensions
    {
        public static int GetAge(this DateTime birthday)
        {
            var today = DateTime.Today;

            var now = (today.Year * 100 + today.Month) * 100 + today.Day;
            var dob = (birthday.Year * 100 + birthday.Month) * 100 + birthday.Day;

            return (now - dob) / 10000;
        }
    }
}