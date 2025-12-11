public class CustomSet {
  private HashSet<int> _elements = new();

  public IReadOnlyList<int> Elements => _elements.ToList().AsReadOnly();

  public CustomSet(params int[] values) {
    _elements = [.. values.Distinct()];
  }

  public CustomSet Add(int value) {
    if (!_elements.Contains(value)) {
      _elements.Add(value);
      _elements = _elements.OrderBy(x => x).ToHashSet();
    }

    return this;
  }

  public bool Empty() {
    return !_elements.Any();
  }

  public bool Contains(int value) {
    return _elements.Contains(value);
  }

  public bool Subset(CustomSet right) {
    return _elements.All(right.Contains);
  }

  public bool Disjoint(CustomSet right) {
    return !_elements.Any(right.Contains);
  }

  public CustomSet Intersection(CustomSet right) {
    return new(_elements.Intersect(right.Elements).ToArray());
  }

  public CustomSet Difference(CustomSet right) {
    return new(_elements.Except(right.Elements).ToArray());
  }

  public CustomSet Union(CustomSet right) {
    return new(_elements.Union(right.Elements).ToArray());
  }

  public override bool Equals(object? obj) {
    if (obj is not CustomSet otherSet) {
      return false;
    }

    return _elements.SetEquals(otherSet._elements);
  }
}