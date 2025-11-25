using System.Reflection.Metadata.Ecma335;

public static class SwiftScheduling {
  public static DateTime DeliveryDate(DateTime meetingStart, string description) {
    return description switch {
      "NOW" => meetingStart.AddHours(2),
      "ASAP" when meetingStart.Hour < 13 => new DateTime(meetingStart.Year, meetingStart.Month, meetingStart.Day, 17, 0, 0),
      "ASAP" => new DateTime(meetingStart.Year, meetingStart.Month, meetingStart.Day, 13, 0, 0).AddDays(1),
      "EOW" when meetingStart.DayOfWeek >= DayOfWeek.Monday && meetingStart.DayOfWeek <= DayOfWeek.Wednesday => new DateTime(meetingStart.Year, meetingStart.Month, meetingStart.Day, 17, 0, 0).AddDays(DayOfWeek.Friday - meetingStart.DayOfWeek),
      "EOW" => new DateTime(meetingStart.Year, meetingStart.Month, meetingStart.Day, 20, 0, 0).AddDays((int)meetingStart.DayOfWeek * -1).AddDays(7),
      _ when description.EndsWith("M") => GetMonthDeliveryDate(meetingStart, description),
      _ when description.StartsWith("Q") => GetQuarterDeliveryDate(meetingStart, description),
      _ => default
    };
  }

  private static DateTime GetMonthDeliveryDate(DateTime meetingStart, string description) {
    var monthNumber = int.Parse(description[..(description.Length - 1)]);
    return new DateTime(meetingStart.Month < monthNumber ? meetingStart.Year : meetingStart.Year + 1, monthNumber, 1, 8, 0, 0).BypassWeekend();
  }

  private static DateTime GetQuarterDeliveryDate(DateTime meetingStart, string description) {
    var quarterNumber = int.Parse(description[1..]);
    var currentQuarter = ((meetingStart.Month + 1) / 3) + 1;
    var year = meetingStart.Year + (currentQuarter > quarterNumber ? 1 : 0);
    return new DateTime(year, quarterNumber * 3, DateTime.DaysInMonth(year, quarterNumber * 3), 8, 0, 0).BypassWeekend(forward: false);
  }

  private static DateTime BypassWeekend(this DateTime meetingDate, bool forward = true) {
    while (meetingDate.DayOfWeek == DayOfWeek.Saturday || meetingDate.DayOfWeek == DayOfWeek.Sunday) {
      meetingDate = meetingDate.AddDays(forward ? 1 : -1);
    }
    return meetingDate;
  }
}
