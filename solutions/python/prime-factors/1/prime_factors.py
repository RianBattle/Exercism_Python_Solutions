def factors(value):
    result = []
    factor = 2
    while value != 1:
        if value // factor == value / factor:
            value //= factor
            result.append(factor)
        else:
            factor += 1
    return result
