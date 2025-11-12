class School:
    def __init__(self):
        self.students = {}
        self.students_added = []

    def add_student(self, name, grade):
        if name not in self.students:
            self.students[name] = grade
            self.students_added.append(True)
        else:
            self.students_added.append(False)

    def roster(self):
        print(self.students)
        return sorted([x for x in self.students], key=lambda x: str(self.students[x]) + x)

    def grade(self, grade_number):
        return sorted([x for x in self.students if self.students[x] == grade_number])

    def added(self):
        return [x for x in self.students_added]
