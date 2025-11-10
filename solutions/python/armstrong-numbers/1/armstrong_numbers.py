def is_armstrong_number(number):
    result = 0
    for index, digit in enumerate(str(number)):
        result += int(digit) ** len(str(number))
    return result == number
