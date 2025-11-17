static class Badge
{
  public static string Print(int? id, string name, string? department)
  {
    var output = "";
    if (id is not null)
    {
      output = $"[{id}] - ";
    }

    return $"{output}{name} - {department?.ToUpper() ?? "OWNER"}";
  }
}
