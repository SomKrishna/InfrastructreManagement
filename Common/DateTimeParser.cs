using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfrastructureManagement.Common
{
    public static class DateTimeParser
    {
        public static DateTime ParseDateTime(string date)
        {
            DateTime dateTime;
            if (DateTime.TryParse(date, out dateTime))
            {
                return dateTime;
            }
            return DateTime.UtcNow;
        }

        public static string ConvertDateTimeToText(Microsoft.OData.Edm.Date? date)
        {
            if (date.HasValue && date != DateTime.MinValue)
            {
                var convertedDateTime = Convert.ToDateTime(date.Value);
                return convertedDateTime.ToString("yyyy'-'MM'-'dd");
            }
            return string.Empty;
        }

    }
}