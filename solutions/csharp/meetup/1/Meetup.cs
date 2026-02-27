public enum Schedule {
  Teenth,
  First,
  Second,
  Third,
  Fourth,
  Last
}

public class Meetup {
  private int _month;
  private int _year;

  public Meetup(int month, int year) {
    _month = month;
    _year = year;
  }

  public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule) {
    return schedule switch {
      Schedule.Teenth => GetTeenth(dayOfWeek),
      Schedule.First => GetNthDay(dayOfWeek, 1),
      Schedule.Second => GetNthDay(dayOfWeek, 2),
      Schedule.Third => GetNthDay(dayOfWeek, 3),
      Schedule.Fourth => GetNthDay(dayOfWeek, 4),
      Schedule.Last => GetLastDay(dayOfWeek),
      _ => throw new ArgumentException()
    };
  }

  private DateTime GetTeenth(DayOfWeek dayOfWeek) {
    for (int day = 13; day <= 19; day++) {
      DateTime date = new DateTime(_year, _month, day);
      if (date.DayOfWeek == dayOfWeek) {
        return date;
      }
    }

    throw new ArgumentException("No teenth day found for the specified day of week.");
  }

  private DateTime GetNthDay(DayOfWeek dayOfWeek, int n) {
    var daysInMonth = DateTime.DaysInMonth(_year, _month);
    var count = 0;

    for (var i = 1; i < daysInMonth; i++) {
      var date = new DateTime(_year, _month, i);
      if (date.DayOfWeek == dayOfWeek) {
        count++;
        if (count == n) {
          return date;
        }
      }
    }

    throw new ArgumentException();
  }

  private DateTime GetLastDay(DayOfWeek dayOfWeek) {
    var daysInMonth = DateTime.DaysInMonth(_year, _month);
    for (var i = daysInMonth; i >= daysInMonth - 7; i--) {
      var date = new DateTime(_year, _month, i);
      if (date.DayOfWeek == dayOfWeek) {
        return date;
      }
    }

    throw new ArgumentException();
  }
}