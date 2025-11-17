public class Matrix
{
  private readonly int[][] _data;
  public Matrix(string input)
  {
    _data = input.Split("\n")
      .Select(line => line.Split(" ")
                                .Select(int.Parse)
                                .ToArray())
      .ToArray();
  }

  public int[] Row(int row)
  {
    return _data[row - 1];
  }

  public int[] Column(int col)
  {
    var result = new List<int>();
    for (var rowNumber = 0; rowNumber < _data.Length; rowNumber++)
    {
      result.Add(_data[rowNumber][col - 1]);
    }
    return result.ToArray();
  }
}