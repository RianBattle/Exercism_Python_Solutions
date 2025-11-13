def prime(number):
    if number < 1:
        raise ValueError("there is no zeroth prime")
    primes = [2]
    n = 2
    while len(primes) < number:
        n += 1
        if all(n % p > 0 for p in primes):
            primes.append(n)
    return primes[-1]
