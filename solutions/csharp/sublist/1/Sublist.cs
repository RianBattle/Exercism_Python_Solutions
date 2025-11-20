public enum SublistType {
  Equal,
  Unequal,
  Superlist,
  Sublist
}

public static class Sublist {
  public static SublistType Classify<T>(List<T> list1, List<T> list2)
      where T : IComparable {
    if (list1.SequenceEqual(list2)) {
      return SublistType.Equal;
    }
    else if (CheckForSuperlist(list1, list2)) {
      return SublistType.Superlist;
    }
    else if (CheckForSuperlist(list2, list1)) {
      return SublistType.Sublist;
    }

    return SublistType.Unequal;
  }

  private static bool CheckForSuperlist<T>(List<T> list1, List<T> list2) {
    if (list1.Count < list2.Count) {
      return false;
    }
    return list1.Count > list2.Count && Enumerable.Range(0, list1.Count - list2.Count + 1)
                        .Any(i => list1.Skip(i).Take(list2.Count).SequenceEqual(list2));
  }
}