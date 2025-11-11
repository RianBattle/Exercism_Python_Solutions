def is_pangram(sentence):
    letters = []
    for letter in sentence:
        if letter.lower() not in letters and letter.isalpha():
            letters.append(letter.lower())
    return len(letters) == 26
