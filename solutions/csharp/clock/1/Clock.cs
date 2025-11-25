public class Clock {
    private int _time;

    public Clock(int hours, int minutes) {
        _time = (60 * hours + minutes) % (24 * 60);
        while (_time < 0) {
            _time += 24 * 60;
        }
    }

    public Clock Add(int minutesToAdd) {
        return new Clock(0, _time + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract) {
        return new Clock(0, _time - minutesToSubtract);
    }

    public override bool Equals(System.Object obj) {
		var c = obj as Clock;
		if (c == null)
			return false;
		return c.ToString() == ToString();
	}
	
	public override int GetHashCode() {
		return this.ToString ().GetHashCode ();
	}

    public override string ToString() => $"{_time / 60:D2}:{_time % 60:D2}";
}
