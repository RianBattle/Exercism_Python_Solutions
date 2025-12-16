public static class Sieve {
  public static int[] Primes(int limit) {
    var output = Enumerable.Range(2, limit - 1).ToList();
    var currentIndex = 0;
    while (currentIndex < output.Count) {
      var currentPrime = output[currentIndex];
      output = output.Where(n => n == currentPrime || n % currentPrime != 0).ToList();
      currentIndex++;
    }

    return output.ToArray();
  }
}
