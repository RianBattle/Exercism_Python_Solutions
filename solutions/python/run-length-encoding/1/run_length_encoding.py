def decode(string):
    if not string:
        return string

    result = ""
    letter_count = ""
    for letter in string:
        if letter.isdigit():
            letter_count += letter
        else:
            if letter_count:
                result += int(letter_count) * letter
            else:
                result += letter
            letter_count = ""
    return result


def encode(string):
    result = ""
    letter_count = 0
    prev_letter = ""
    for letter in string:
        if prev_letter != "" and prev_letter != letter:
            result += (str(letter_count) if letter_count > 1 else "") + prev_letter
            letter_count = 0
        letter_count += 1
        prev_letter = letter
    result += (str(letter_count) if letter_count > 1 else "") + prev_letter
    return result
