ALLERGENS = {
    "eggs": 1,
    "peanuts": 2,
    "shellfish": 4,
    "strawberries": 8,
    "tomatoes": 16,
    "chocolate": 32,
    "pollen": 64,
    "cats": 128
}

class Allergies:
    def __init__(self, score):
        self.score = score

    def allergic_to(self, item):
        return bool(self.score & ALLERGENS[item.lower()])

    @property
    def lst(self):
        return [x for x in ALLERGENS if self.allergic_to(x)]
