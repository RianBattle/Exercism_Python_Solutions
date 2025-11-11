import string

def rotate(text, key):
    result = ""
    for char in text:
        if char.isalpha():
            char_index = string.ascii_lowercase.index(char.lower()) + key
            if char_index > 25:
                char_index -= 26
            result += string.ascii_lowercase[char_index] if char.islower() else string.ascii_lowercase[char_index].upper()
        else:
            result += char
    return result
