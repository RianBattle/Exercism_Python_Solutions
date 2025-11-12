class Matrix:
    def __init__(self, matrix_string):
        self.matrix = matrix_string.split("\n")
        for i in range(len(self.matrix)):
            self.matrix[i] = [int(x) for x in self.matrix[i].split(" ")]

    def row(self, index):
        if index > len(self.matrix):
            raise ValueError(f"index {index} out of matrix bounds")
        return self.matrix[index - 1]

    def column(self, index):
        if index > len(self.matrix[0]):
            raise ValueError(f"index {index} out of matrix bounds")
        return [row[index - 1] for row in self.matrix]
