def append(list1, list2):
    return list1 + list2


def concat(lists):
    result = []
    for l in lists:
        result += [x for x in l]
    return result


def filter(function, list):
    return [x for x in list if function(x)]


def length(list):
    count = 0
    for item in list:
        count += 1
    return count


def map(function, list):
    return [function(x) for x in list]


def foldl(function, list, initial):
    acc = initial
    for item in list:
        acc = function(acc, item)
    return acc


def foldr(function, list, initial):
    acc = initial
    for i in range(len(list) - 1, -1, -1):
        acc = function(acc, list[i])
    return acc


def reverse(list):
    return [list[i] for i in range(len(list) - 1, -1, -1)]
