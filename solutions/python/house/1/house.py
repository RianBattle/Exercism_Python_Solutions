VERSES = [
    ("house that Jack built.", "lay in"),
    ("malt", "ate"),
    ("rat", "killed"),
    ("cat", "worried"),
    ("dog", "tossed"),
    ("cow with the crumpled horn", "milked"),
    ("maiden all forlorn", "kissed"),
    ("man all tattered and torn", "married"),
    ("priest all shaven and shorn", "woke"),
    ("rooster that crowed in the morn", "kept"),
    ("farmer sowing his corn", "belonged to"),
    ("horse and the hound and the horn", ""),
]

def verse(number):
    subject = VERSES[number - 1][0]
    result = [f"This is the {subject}"]
    for subject, action in reversed(VERSES[:number - 1]):
        result.append(f"that {action} the {subject}")
    return " ".join(result)

def recite(start_verse, end_verse):
    return [verse(n) for n in range(start_verse, end_verse + 1)]
