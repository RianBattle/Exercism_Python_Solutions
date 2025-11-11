# new_dict = {key_expression: value_expression for item in iterable if condition}
def transform(legacy_data):
    result = {}
    for value in legacy_data:
        for char in legacy_data[value]:
            result[char.lower()] = value
    return result
