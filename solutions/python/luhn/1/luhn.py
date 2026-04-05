class Luhn:
    def __init__(self, card_num):
        self.card_num = card_num

    def valid(self):
        if any(not x.isdigit() for x in self.card_num.replace(" ", "")):
            return False
        if len(self.card_num.replace(" ", "")) <= 1:
            return False
            
        cleaned_card_num = [int(x) for x in self.card_num.replace(" ", "")]
        for num in range(len(cleaned_card_num) - 2, -1, -2):
            cleaned_card_num[num] = cleaned_card_num[num] * 2 - (9 if cleaned_card_num[num] * 2 > 9 else 0)
        return sum(cleaned_card_num) % 10 == 0
