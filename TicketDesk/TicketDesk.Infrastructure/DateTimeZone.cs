using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FONTE: https://pt.stackoverflow.com/questions/46488/trocar-a-timezone-do-datetime-now

namespace TicketDesk.Infrastructure
{
    public static class DateTimeZone
    {
        private static TimeZoneInfo _timeZoneInfo;
        private static string _zoneId;

        public static DateTime Now
        {
            get
            {
                return TimeZoneInfo.ConvertTime(DateTime.Now, GetTimeZoneInfo());
            }
        }

        private static TimeZoneInfo GetTimeZoneInfo()
        {
            if (_timeZoneInfo == null)
                _timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(ZoneId);

            return _timeZoneInfo;
        }
        private static string ZoneId
        {
            get
            {
                if (string.IsNullOrEmpty(_zoneId))
                {
                    if (ConfigurationManager.AppSettings["TimeZoneInfo_ZoneId"] == null)
                        throw new Exception("Key TimeZoneInfo_ZoneId wasn't found in App or Web config.");

                    _zoneId = ConfigurationManager.AppSettings["TimeZoneInfo_ZoneId"].ToString();
                }

                return _zoneId;
            }
        }

    }

    public static class DateTimeOffsetZone
    {
        private static TimeZoneInfo _timeZoneInfo;
        private static string _zoneId;

        public static DateTimeOffset Now
        {
            get
            {
                return TimeZoneInfo.ConvertTime(DateTimeOffset.Now, GetTimeZoneInfo());
            }
        }

        private static TimeZoneInfo GetTimeZoneInfo()
        {
            if (_timeZoneInfo == null)
                _timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(ZoneId);

            return _timeZoneInfo;
        }
        private static string ZoneId
        {
            get
            {
                if (string.IsNullOrEmpty(_zoneId))
                {
                    if (ConfigurationManager.AppSettings["TimeZoneInfo_ZoneId"] == null)
                        throw new Exception("Key TimeZoneInfo_ZoneId wasn't found in App or Web config.");

                    _zoneId = ConfigurationManager.AppSettings["TimeZoneInfo_ZoneId"].ToString();
                }

                return _zoneId;
            }
        }

    }
}
