numbers = {
    0: "Zero",
    1: "One",
    2: "Two",
    3: "Three",
    4: "Four",
    5: "Five",
    6: "Six",
    7: "Seven",
    8: "Eight",
    9: "Nine",
    10: "Ten"
}

def recite(start, take=1):
    result = []
    verses = 1
    for i in range(start, 0, -1):
        result.append(f"{numbers[i]} green bottle{'s' if i > 1 else ''} hanging on the wall,")
        result.append(f"{numbers[i]} green bottle{'s' if i > 1 else ''} hanging on the wall,")
        result.append("And if one green bottle should accidentally fall,")
        if i == 1:
            result.append("There'll be no green bottles hanging on the wall.")
        else:
            result.append(f"There'll be {numbers[i-1].lower()} green bottle{'s' if i-1 > 1 else ''} hanging on the wall.")

        if verses == take:
            break
        verses += 1
        result.append("")

    return result
