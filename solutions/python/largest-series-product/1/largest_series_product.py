def largest_product(series, size):
    """
    series: a sequence of adjacent digits contained within the input
    size: how many digits each series is
    """
    if size > len(series):
        raise ValueError("span must not exceed string length")
    if size < 0:
        raise ValueError("span must not be negative")
    if any(not c.isdigit() for c in series):
        raise ValueError("digits input must only contain digits")
    
    sub_series = [series[i:i+size] for i in range(len(series)) if i + size <= len(series)]
    products = []
    for s in sub_series:
        digits = [int(c) for c in s]
        product = digits[0]
        for i in range(1, len(digits)):
            product *= digits[i]
        products.append(product)
    return max(products)