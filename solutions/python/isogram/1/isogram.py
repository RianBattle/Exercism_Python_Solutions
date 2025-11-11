def is_isogram(string):
    chars = []
    for char in string.lower():
        if char not in chars:
            if char.isalpha():
                chars.append(char)
        else:
            return False
    return True    
