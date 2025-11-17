
public enum StopwatchState
{
  Ready,
  Running,
  Stopped
}

public class SplitSecondStopwatch(TimeProvider time)
{
  private TimeProvider _time = time;
  private List<TimeSpan> _previousLaps = new();
  private DateTimeOffset? _lapStart;
  private TimeSpan? _elapsed;

  public StopwatchState State { get; private set; }
  public TimeSpan CurrentLap =>
    State switch
    {
      StopwatchState.Ready => TimeSpan.Zero,
      StopwatchState.Running => (_time.GetUtcNow() - _lapStart.GetValueOrDefault()) + _elapsed.GetValueOrDefault(),
      StopwatchState.Stopped => _elapsed.GetValueOrDefault()
    };
  public TimeSpan Total => _previousLaps.Aggregate(TimeSpan.Zero, (acc, ts) => acc + ts.Duration()) + CurrentLap;
  public IReadOnlyCollection<TimeSpan> PreviousLaps => _previousLaps.AsReadOnly();

  public void Start()
  {
    switch (State)
    {
      case StopwatchState.Ready:
        _elapsed = new TimeSpan();
        break;
      case StopwatchState.Running:
        throw new InvalidOperationException();
    }

    _lapStart = _time.GetUtcNow();
    State = StopwatchState.Running;
  }

  public void Stop()
  {
    if (State != StopwatchState.Running)
    {
      throw new InvalidOperationException();
    }

    _elapsed = _time.GetUtcNow() - _lapStart.GetValueOrDefault();
    _lapStart = null;
    State = StopwatchState.Stopped;
  }

  public void Reset()
  {
    if (State != StopwatchState.Stopped)
    {
      throw new InvalidOperationException();
    }

    _lapStart = null;
    _elapsed = null;
    _previousLaps.Clear();
    State = StopwatchState.Ready;
  }

  public void Lap()
  {
    if (State != StopwatchState.Running)
    {
      throw new InvalidOperationException();
    }
    _previousLaps.Add(CurrentLap);
    _lapStart = _time.GetUtcNow();
    _elapsed = new TimeSpan();
  }
}
