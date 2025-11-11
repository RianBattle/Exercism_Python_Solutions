import random

def roll_dice():
    rolls = []
    for i in range(4):
        rolls.append(random.randint(1, 6))
    return sorted(rolls)

class Character:
    def __init__(self):
        self.strength = sum(roll_dice()[1:])
        self.dexterity = sum(roll_dice()[1:])
        self.constitution = sum(roll_dice()[1:])
        self.intelligence = sum(roll_dice()[1:])
        self.wisdom = sum(roll_dice()[1:])
        self.charisma = sum(roll_dice()[1:])

        self.hitpoints = 10 + modifier(self.constitution)

    def ability(self):
        return self.constitution

def modifier(value):
    return (value - 10) // 2
