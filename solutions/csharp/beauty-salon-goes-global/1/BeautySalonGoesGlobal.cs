using System.Globalization;

public enum Location {
  NewYork,
  London,
  Paris
}

public enum AlertLevel {
  Early,
  Standard,
  Late
}

public static class Appointment {
  public static DateTime ShowLocalTime(DateTime dtUtc) {
    return dtUtc.ToLocalTime();
  }

  public static DateTime Schedule(string appointmentDateDescription, Location location) {
    return TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), TimeZoneInfo.FindSystemTimeZoneById(location == Location.NewYork ? "Eastern Standard Time" : (location == Location.London ? "GMT Standard Time" : "W. Europe Standard Time")));
  }

  public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) {
    switch (alertLevel) {
      case AlertLevel.Early:
        return appointment.AddDays(-1);
      case AlertLevel.Standard:
        return appointment.AddHours(-1).AddMinutes(-45);
      case AlertLevel.Late:
        return appointment.AddMinutes(-30);
    }
    return default;
  }

  public static bool HasDaylightSavingChanged(DateTime dt, Location location) {
    var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(location == Location.NewYork ? "Eastern Standard Time" : (location == Location.London ? "GMT Standard Time" : "W. Europe Standard Time"));
    var sevenDaysEarlier = dt.AddDays(-7);
    return timeZoneInfo.IsDaylightSavingTime(dt) != timeZoneInfo.IsDaylightSavingTime(sevenDaysEarlier);
  }

  public static DateTime NormalizeDateTime(string dtStr, Location location) {
    var cultureInfo = CultureInfo.GetCultureInfo(location == Location.NewYork ? "en-US" : (location == Location.London ? "en-GB" : "fr-FR"));
    var isSuccess = DateTime.TryParse(dtStr, cultureInfo, DateTimeStyles.None, out var dateTime);
    return isSuccess ? dateTime : new(1, 1, 1);
  }
}
