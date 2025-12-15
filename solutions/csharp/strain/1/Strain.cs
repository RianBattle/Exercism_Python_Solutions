public static class Strain {
  public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate) {
    if (!collection.Any()) {
      return collection;
    }

    return collection.Where(predicate);
  }

  public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate) {
    if (!collection.Any()) {
      return collection;
    }

    return collection.Where(item => !predicate(item));
  }
}