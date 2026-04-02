bands = {
    "black": "0",
    "brown": "1",
    "red": "2",
    "orange": "3",
    "yellow": "4",
    "green": "5",
    "blue": "6",
    "violet": "7",
    "grey": "8",
    "white": "9"
}

def label(colors):
    value = int("".join([bands[colors[i]] for i in range(2)]))
    value *= 10 ** int(bands[colors[2]])
    
    prefix = ""
    if value == 0:
        return "0 ohms"
    elif value % 1000000000 == 0:
        prefix = "giga"
        value /= (10 ** 9)
    elif value % 1000000 == 0:
        prefix = "mega"
        value /= (10 ** 6)
    elif value % 1000 == 0:
        prefix = "kilo"
        value /= (10 ** 3)
        
    return f"{int(value)} {prefix}ohms"
