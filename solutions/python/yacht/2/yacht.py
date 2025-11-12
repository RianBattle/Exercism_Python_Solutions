# Score categories.
# Change the values as you see fit.
YACHT = 0
ONES = 1
TWOS = 2
THREES = 3
FOURS = 4
FIVES = 5
SIXES = 6
FULL_HOUSE = 7
FOUR_OF_A_KIND = 8
LITTLE_STRAIGHT = 9
BIG_STRAIGHT = 10
CHOICE = 11


def score(dice, category):
    match category:
        case 0:
            return 50 if dice.count(dice[0]) == 5 else 0
        case 1 | 2 | 3 | 4 | 5 | 6:
            return sum([x for x in dice if x == category])
        case 7:
            dice.sort()
            if (dice.count(dice[0]) == 2 and dice.count(dice[-1]) == 3) or (dice.count(dice[0]) == 3 and dice.count(dice[-1]) == 2):
                return sum(dice)
            return 0
        case 8:
            score = 0
            dice_added = 0
            for die in dice:
                if dice.count(die) >= 4 and dice_added < 4:
                    score += die
                    dice_added += 1
            return score
        case 9:
            return 30 if sorted(dice) == [i for i in range(1, 6)] else 0
        case 10:
            return 30 if sorted(dice) == [i for i in range(2, 7)] else 0
        case 11:
            return sum(dice)
