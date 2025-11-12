def sum_of_multiples(limit, multiples):
    factors = []
    for item in multiples:
        if item >= limit or item <= 0:
            continue
        factors += [i for i in range(item, limit) if i % item == 0]
    return sum(set(factors))
