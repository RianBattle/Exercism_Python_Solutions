public static class RealNumberExtension {
  public static double Expreal(this int realNumber, RationalNumber r) {
    return Math.Pow(realNumber, (double)r.Numerator / r.Denominator);
  }
}

public struct RationalNumber {
  public int Numerator { get; }
  public int Denominator { get; }

  public RationalNumber(int numerator, int denominator) {
    Numerator = numerator;
    Denominator = denominator;
  }

  public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) {
    var numerator = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
    var denominator = numerator != 0 ? r1.Denominator * r2.Denominator : 1;
    return new RationalNumber(numerator, denominator);
  }

  public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) {
    var numerator = r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator;
    var denominator = numerator != 0 ? r1.Denominator * r2.Denominator : 1;
    return new RationalNumber(numerator, denominator).Reduce();
  }

  public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) {
    var numerator = r1.Numerator * r2.Numerator;
    var denominator = numerator != 0 ? r1.Denominator * r2.Denominator : 1;
    return new RationalNumber(numerator, denominator).Reduce();
  }

  public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) {
    return new RationalNumber(r1.Numerator * r2.Denominator, r2.Numerator * r1.Denominator).Reduce();
  }

  public RationalNumber Abs() {
    return new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator)).Reduce();
  }

  public RationalNumber Reduce() {
    if (Denominator == 0) {
      return this;
    }
    else if (Numerator == 0) {
      return new RationalNumber(0, 1);
    }
    else if (Denominator < 0) {
      return new RationalNumber(Numerator * -1, Denominator * -1).Reduce();
    }

    var gcd = FindGreatestCommonDenominator(Numerator, Denominator);
    var numerator = Numerator / gcd;
    var denominator = Denominator / gcd;
    return new RationalNumber(numerator, denominator);
  }

  private int FindGreatestCommonDenominator(int a, int b) {
    a = Math.Abs(a);
    b = Math.Abs(b);
    return b == 0 ? a : FindGreatestCommonDenominator(b, a % b);
  }

  public RationalNumber Exprational(int power) {
    if (power >= 0) {
      return new RationalNumber((int)Math.Pow(Numerator, power), (int)Math.Pow(Denominator, power)).Reduce();
    }
    return new RationalNumber((int)Math.Pow(Denominator, Math.Abs(power)), (int)Math.Pow(Numerator, Math.Abs(power))).Reduce();
  }

  public override string ToString() => $"{Numerator}/{Denominator}";
}