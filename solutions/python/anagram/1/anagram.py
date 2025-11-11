def get_letters_for_word(word):
    return sorted([x.lower() for x in word])

def find_anagrams(word, candidates):
    letters_in_word = get_letters_for_word(word)
    return [candidate for candidate in candidates if word.lower() != candidate.lower() and get_letters_for_word(candidate) == letters_in_word]
