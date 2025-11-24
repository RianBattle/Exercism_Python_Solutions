public enum YachtCategory {
  Ones = 1,
  Twos = 2,
  Threes = 3,
  Fours = 4,
  Fives = 5,
  Sixes = 6,
  FullHouse = 7,
  FourOfAKind = 8,
  LittleStraight = 9,
  BigStraight = 10,
  Choice = 11,
  Yacht = 12,
}

public static class YachtGame {
  public static int Score(int[] dice, YachtCategory category) {
    return category switch {
      YachtCategory.Ones => ScoreANumber(dice, 1),
      YachtCategory.Twos => ScoreANumber(dice, 2),
      YachtCategory.Threes => ScoreANumber(dice, 3),
      YachtCategory.Fours => ScoreANumber(dice, 4),
      YachtCategory.Fives => ScoreANumber(dice, 5),
      YachtCategory.Sixes => ScoreANumber(dice, 6),
      YachtCategory.FullHouse => ScoreFullHouse(dice),
      YachtCategory.FourOfAKind => ScoreFourOfAKind(dice),
      YachtCategory.LittleStraight => ScoreStraight(dice),
      YachtCategory.BigStraight => ScoreStraight(dice, 2, 6),
      YachtCategory.Choice => dice.Sum(),
      YachtCategory.Yacht when dice.Distinct().Count() == 1 => 50,
      _ => 0
    };
  }

  private static int ScoreANumber(int[] dice, int number) {
    return dice.Where(x => x == number).Sum();
  }

  private static int ScoreFullHouse(int[] dice) {
    var sortedDice = dice.Order();
    var firstNumberCount = dice.Count(x => x == sortedDice.First());
    var lastNumberCount = dice.Count(x => x == sortedDice.Last());

    if ((firstNumberCount == 2 && lastNumberCount == 3) || (firstNumberCount == 3 && lastNumberCount == 2)) {
      return dice.Sum();
    }
    return 0;
  }

  private static int ScoreFourOfAKind(int[] dice) {
    foreach (var diceValue in dice.Distinct()) {
      if (dice.Count(x => x == diceValue) >= 4) {
        return dice.Where(x => x == diceValue).Take(4).Sum();
      }
    }
    return 0;
  }

  private static int ScoreStraight(int[] dice, int min = 1, int max = 5) {
    return dice.Distinct().Count() == 5 && dice.Min() == min && dice.Max() == max ? 30 : 0;
  }
}

