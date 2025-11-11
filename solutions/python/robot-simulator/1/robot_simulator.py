# Globals for the directions
# Change the values as you see fit
EAST = 1
NORTH = 2
WEST = 3
SOUTH = 4


class Robot:
    def __init__(self, direction=NORTH, x_pos=0, y_pos=0):
        self.direction = direction
        self.coordinates = (x_pos, y_pos)

    def turn_left(self):
        self.direction += 1
        if self.direction == 5:
            self.direction = 1

    def turn_right(self):
        self.direction -= 1
        if self.direction == 0:
            self.direction = 4

    def move(self, instructions):
        for instruction in instructions:
            if instruction == "R":
                self.turn_right()
            elif instruction == "L":
                self.turn_left()
            else:
                x, y = self.coordinates
                if self.direction == NORTH:
                    y += 1
                elif self.direction == EAST:
                    x += 1
                elif self.direction == SOUTH:
                    y -= 1
                elif self.direction == WEST:
                    x -= 1
                self.coordinates = x, y
