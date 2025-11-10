def is_armstrong_number(number):
    result = 0
    for digit in str(number):
        result += int(digit) ** len(str(number))
    return result == number
