using System;
using System.Collections.Generic;
using System.Linq;

namespace BFsharp.Formula
{
    public class DateCallProvider : CallProviderBase
    {
        protected override IEnumerable<Method> GetMethods(Type type)
        {
            if (type!= null) return Enumerable.Empty<Method>();

            return from p in typeof (DateCallProvider).GetProperties()
                   select (Method) p;
        }

        public static DateTime Yesterday { get { return Today.AddDays(-1); } }
        public static DateTime Today
        {
            get
            {
                DateTime time = DateTime.Now;
                return new DateTime(time.Year, time.Month, time.Day);
            }
        }
        public static DateTime Tomorrow { get { return Today.AddDays(-1); } }
        public static DateTime Now { get { return DateTime.Now; } }

        public static TimeSpan Day { get { return TimeSpan.FromDays(1); } }
        public static TimeSpan Hour { get { return TimeSpan.FromHours(1); } }
    }
}