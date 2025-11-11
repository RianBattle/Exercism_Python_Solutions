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

tolerances = {
    "grey": "0.05%",
    "violet": "0.1%",
    "blue": "0.25%",
    "green": "0.5%",
    "brown": "1%",
    "red": "2%",
    "gold": "5%",
    "silver": "10%"
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

def resistor_label(colors):
    if len(colors) == 1:
        return bands[colors[0]] + " ohms"
    
    value = int("".join([bands[colors[i]] for i in range(len(colors) - 2)]))
    if len(colors) >= 3:
        value *= 10 ** int(bands[colors[len(colors) - 2]])

    print("value:", value)
    prefix = ""
    if value == 0:
        return "0 ohms"
    elif value >= 1000000000:
        prefix = "giga"
        value /= (10 ** 9)
    elif value >= 1000000:
        prefix = "mega"
        value /= (10 ** 6)
    elif value >= 1000:
        prefix = "kilo"
        value /= (10 ** 3)

    result = f"{value} {prefix}ohms"
    if len(colors) >= 4:
        result += " ±" + tolerances[colors[len(colors) - 1]]
    if ".0 " in result:
        result = result.replace(".0 ", " ")
    return result