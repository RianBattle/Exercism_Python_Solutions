def square(number):
    if number <= 0 or number > 64:
        raise ValueError("square must be between 1 and 64")
    if number == 1:
        return 1
    result = 1
    for n in range(2, number + 1):
        result *= 2
    return result


def total():
    result = 0
    for n in range(1, 65):
        result += square(n)
    return result
