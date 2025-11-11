def is_valid(isbn):
    isbn = isbn.replace("-", "")
    if len(isbn) != 10:
        return False
    sum = 0
    for i in range(len(isbn)):
        if not isbn[i].isdigit() and isbn[i] != "X" or (isbn[i] == "X" and i != len(isbn) - 1):
            return False
        digit = int(isbn[i]) if isbn[i] != "X" else 10
        sum += (digit * (10 - i))
    return sum % 11 == 0
