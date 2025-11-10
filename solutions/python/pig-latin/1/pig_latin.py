VOWELS = ["a", "e", "i", "o", "u"]

def starts_with_consonants(text):
    return text[0] not in VOWELS

def has_consonants_followed_by(text, characters):
    if characters not in text:
        return False
    ch_index = text.index(characters)
    if ch_index < 0:
        return False
    for i in range(ch_index):
        if text[i] in VOWELS:
            return False
    return True

def translate(text):
    result = ""
    for word in text.split(" "):
        if word[0] in VOWELS or word.startswith("xr") or word.startswith("yt"):
            result += word + "ay "
            continue
    
        if starts_with_consonants(word):
            if has_consonants_followed_by(word, "qu"):
                qu_index = word.index("qu")
                part_to_move = word[:qu_index+2]
                rest_of_word = word[qu_index+2:]
                result += rest_of_word + part_to_move + "ay "
            elif word[0] != "y" and has_consonants_followed_by(word, "y"):
                y_index = word.index("y")
                part_to_move = word[:y_index]
                rest_of_word = word[y_index:]
                result += rest_of_word + part_to_move + "ay "
            else:
                new_word = ""
                for i in range(len(word)):
                    if word[i] in VOWELS:
                        new_word = word[i:] + word[:i]
                        break
                result += new_word + "ay "
                
    return result[:-1]
