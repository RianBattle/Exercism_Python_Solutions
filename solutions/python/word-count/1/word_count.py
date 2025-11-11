def clean_text(text):
    punctuation = "!@#$%^&*()-_=+:.,"
    for p in punctuation:
        text = text.replace(p, " ")
    if text.startswith("'"):
        text = text[1:]
    if text.endswith("'"):
        text = text[:-1]
    return text.replace("\n", " ")

def count_words(sentence):
    result = {}
    for word in clean_text(sentence).split():
        cleaned_word = clean_text(word).lower()
        if cleaned_word in result:
            result[cleaned_word] += 1
        else:
            result[cleaned_word] = 1
    return result
