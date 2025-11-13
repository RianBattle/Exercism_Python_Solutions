def abbreviate(words):
    result = ""
    for word in words.split(" "):
        for subword in word.split("-"):
            for char in subword:
                if char.isalpha():
                    result += char.upper()
                    break
    return result
