def square_root(number):
    if number == 1:
        return 1
    for f in range(1, (number // 2 + 1)):
        if f**2 == number:
            return f
    return 0
