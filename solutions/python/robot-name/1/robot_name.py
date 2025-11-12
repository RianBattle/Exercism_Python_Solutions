import random
import string

class Robot:
    def __init__(self):
        self._set_name()
        self._set_name()

    def _set_name(self):
        letter1 = string.ascii_uppercase[random.randint(0, 25)]
        letter2 = string.ascii_uppercase[random.randint(0, 25)]
        self.name = letter1 + letter2 + str(random.randint(1, 9)) + str(random.randint(1, 9)) + str(random.randint(1, 9))

    def reset(self):
        self._set_name()
