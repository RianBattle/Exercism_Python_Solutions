import string

def encode(plain_text):
    result = ""
    group_count = 0
    cipher = list(string.ascii_lowercase)
    for i in range(len(plain_text)):
        if plain_text[i] in [" ", ",", "."]:
            continue
        if plain_text[i].isdigit():
            result += plain_text[i]
        elif plain_text[i].lower() in cipher:
            result += cipher[26 - cipher.index(plain_text[i].lower()) - 1]
            
        group_count += 1
        if group_count == 5:
            result += " "
            group_count = 0
        print("result:", result, "group_count:", group_count, "current character:", plain_text[i])
    return result if result[-1] != " " else result[:-1]

def decode(ciphered_text):
    result = ""
    cipher = list(string.ascii_lowercase)
    cipher.reverse()
    for i in range(len(ciphered_text)):
        if ciphered_text[i] == " ":
            continue
        elif ciphered_text[i] not in cipher:
            result += ciphered_text[i]
        else:
            result += cipher[26 - cipher.index(ciphered_text[i]) - 1]
    return result
