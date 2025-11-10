dict = {
    "[": "]",
    "{": "}",
    "(": ")"
}
def is_paired(input_string):
    pairs = []
    for letter in input_string:
        if letter in dict:
            pairs.append(letter)
            if input_string.count(letter) != input_string.count(dict[letter]):
                return False
        elif letter in dict.values() and len(pairs) > 0:
            last_item = pairs[-1]
            if last_item in dict and dict[last_item] == letter:
                pairs.pop()
            else:
                return False
    return len(pairs) == 0
