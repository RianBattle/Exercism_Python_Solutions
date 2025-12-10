public static class Tournament {
  private const string Header = "Team                           | MP |  W |  D |  L |  P";

  public static void Tally(Stream inStream, Stream outStream) {
    var input = string.Empty;
    using (var reader = new StreamReader(inStream)) {
      input = reader.ReadToEnd();
    }

    var result = Header;
    if (!string.IsNullOrEmpty(input)) {
      var teams = ProcessGames(input);
      foreach (var team in teams.OrderByDescending(x => x.Score).ThenBy(x => x.Name)) {
        result += CreateTeamRecord(team);
      }
    }

    using (var writer = new StreamWriter(outStream)) {
      writer.Write(result);
    }
  }

  private static List<Team> ProcessGames(string input) {
    var teams = new List<Team>();
    foreach (var line in input.Split("\n")) {
      var data = line.Split(";");
      var team1Name = data[0];
      var team2Name = data[1];
      var gameResult = data[2];

      var team1 = GetTeam(teams, team1Name);
      var team2 = GetTeam(teams, team2Name);

      RecordGameResult(team1, team2, gameResult);
    }

    return teams;
  }

  private static Team GetTeam(List<Team> teams, string teamName) {
    var team = teams.Find(x => x.Name == teamName);
    if (team is null) {
      team = new Team(teamName);
      teams.Add(team);
    }

    return team;
  }

  private static void RecordGameResult(Team team1, Team team2, string gameResult) {
    switch (gameResult) {
      case "win":
        team1.Wins += 1;
        team2.Losses += 1;
        break;
      case "draw":
        team1.Draws += 1;
        team2.Draws += 1;
        break;
      case "loss":
        team1.Losses += 1;
        team2.Wins += 1;
        break;
    }
  }

  private static string CreateTeamRecord(Team team) {
    return $"\n{team.Name,-30} | {team.MatchesPlayed,2} | {team.Wins,2} | {team.Draws,2} | {team.Losses,2} | {team.Score,2}";
  }
}

public class Team {
  public string Name { get; set; }
  public int MatchesPlayed => Wins + Draws + Losses;
  public int Wins { get; set; }
  public int Draws { get; set; }
  public int Losses { get; set; }
  public int Score => (Wins * 3) + Draws;

  public Team(string name) {
    Name = name;
  }

  public override bool Equals(object? obj) => obj is Team other && Name == other.Name;
  public override int GetHashCode() => HashCode.Combine(Name);
}