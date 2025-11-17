using System.Numerics;
using System.Security.Cryptography;

public static class DiffieHellman
{
  private static readonly Random _random = new Random();
  public static BigInteger PrivateKey(BigInteger primeP)
  {
    return _random.NextInt64(1, (long)primeP + 1);
  }

  public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey)
  {
    return BigInteger.Pow(primeG, (int)privateKey) % primeP;
  }

  public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey)
  {
    return BigInteger.Pow(publicKey, (int)privateKey) % primeP;
  }
}