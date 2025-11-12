STUDENTS = [
    "Alice",
    "Bob",
    "Charlie",
    "David",
    "Eve",
    "Fred",
    "Ginny",
    "Harriet",
    "Ileana",
    "Joseph",
    "Kincaid",
    "Larry"
]

PLANTS = {
    "G": "Grass",
    "C": "Clover",
    "R": "Radishes",
    "V": "Violets"
}

class Garden:
    def __init__(self, diagram, students=STUDENTS):
        self.diagram = diagram.split("\n")
        self.students = sorted(students)

    def plants(self, student):
        student_index = self.students.index(student) * 2
        return [PLANTS[p] for p in self.diagram[0][student_index:student_index+2] + self.diagram[1][student_index:student_index+2]]
