def has_letters(words):
    for c in words:
        if c.isalpha():
            return True
    return False

def response(hey_bob):
    if hey_bob.strip() == "":
        return "Fine. Be that way!"

    if has_letters(hey_bob):
        if hey_bob == hey_bob.upper():
            return "Calm down, I know what I'm doing!" if hey_bob.strip().endswith("?") else "Whoa, chill out!"
    if hey_bob.strip().endswith("?"):
        return "Sure."
    
    return "Whatever."
