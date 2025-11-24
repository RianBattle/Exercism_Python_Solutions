public class GradeSchool {
    private Dictionary<int, List<string>> _students = new Dictionary<int, List<string>>();
    
    public bool Add(string student, int grade) {
        if (_students.Any(x => x.Value.Contains(student))) {
          return false;
        }
    
        if (_students.ContainsKey(grade)) {
          _students[grade].Add(student);
        }
        else {
          _students[grade] = [student];
        }
        return true;
    }

    public IEnumerable<string> Roster() {
        var result = new List<string>();
        foreach (var grade in _students.Keys.OrderBy(x => x)) {
            result.AddRange(_students[grade].OrderBy(x => x));
        }
        return result;
    }

    public IEnumerable<string> Grade(int grade) {
        if (_students.ContainsKey(grade)) {
            return _students[grade].OrderBy(x => x);
        }
        return Enumerable.Empty<string>();
    }
}