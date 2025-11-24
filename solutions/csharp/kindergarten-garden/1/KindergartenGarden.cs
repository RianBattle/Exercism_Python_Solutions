public enum Plant {
  Violets,
  Radishes,
  Clover,
  Grass
}

public enum Student {
  Alice,
  Bob,
  Charlie,
  David,
  Eve,
  Fred,
  Ginny,
  Harriet,
  Ileana,
  Joseph,
  Kincaid,
  Larry
}

public class KindergartenGarden {
  private readonly Dictionary<char, Plant> _plants = new() {
    {'V', Plant.Violets},
    {'R', Plant.Radishes},
    {'C', Plant.Clover},
    {'G', Plant.Grass}
  };

  private readonly Dictionary<Student, List<Plant>> _diagram = new() {
    {Student.Alice, new()},
    {Student.Bob, new()},
    {Student.Charlie, new()},
    {Student.David, new()},
    {Student.Eve, new()},
    {Student.Fred, new()},
    {Student.Ginny, new()},
    {Student.Harriet, new()},
    {Student.Ileana, new()},
    {Student.Joseph, new()},
    {Student.Kincaid, new()},
    {Student.Larry, new()}
  };

  public KindergartenGarden(string diagram) {
    var lines = diagram.Split("\n");
    var studentIndex = 0;
    for (var i = 0; i < lines[0].Count() - 1; i += 2) {
      _diagram[(Student)studentIndex].Add(_plants[lines[0][i]]);
      _diagram[(Student)studentIndex].Add(_plants[lines[0][i + 1]]);
      _diagram[(Student)studentIndex].Add(_plants[lines[1][i]]);
      _diagram[(Student)studentIndex].Add(_plants[lines[1][i + 1]]);
      studentIndex++;
    }
  }

  public IEnumerable<Plant> Plants(string student) {
    return _diagram[Enum.Parse<Student>(student)].ToArray();
  }
}