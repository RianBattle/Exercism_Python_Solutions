def get_factors(number):
    factors = []
    for num in range(1, number // 2 + 1):
        if number % num == 0:
            factors.append(num)
    return factors

def classify(number):
    """ A perfect number equals the sum of its positive divisors.

    :param number: int a positive integer
    :return: str the classification of the input integer
    """
    if number < 1:
        raise ValueError("Classification is only possible for positive integers.")
    
    factors = get_factors(number)
    sum = 0
    for factor in factors:
        sum += factor

    if number < sum:
        return "abundant"
    elif number > sum:
        return "deficient"
    return "perfect"
