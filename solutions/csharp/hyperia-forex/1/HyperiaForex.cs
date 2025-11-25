public struct CurrencyAmount {
  private decimal amount;
  private string currency;

  public CurrencyAmount(decimal amount, string currency) {
    this.amount = amount;
    this.currency = currency;
  }

  public override bool Equals(object? obj) {
    if (obj is CurrencyAmount other) {
      return this == other;
    }
    throw new ArgumentException();
  }

  public static bool operator ==(CurrencyAmount c1, CurrencyAmount c2) {
    if (c1.currency != c2.currency) {
      throw new ArgumentException();
    }
    return c1.amount == c2.amount && c1.currency == c2.currency;
  }

  public static bool operator !=(CurrencyAmount c1, CurrencyAmount c2) {
    return !(c1 == c2);
  }

  public static bool operator >(CurrencyAmount c1, CurrencyAmount c2) {
    if (c1.currency != c2.currency) {
      throw new ArgumentException();
    }
    return c1.amount > c2.amount;
  }

  public static bool operator <(CurrencyAmount c1, CurrencyAmount c2) {
    if (c1.currency != c2.currency) {
      throw new ArgumentException();
    }
    return c1.amount < c2.amount;
  }

  public static CurrencyAmount operator +(CurrencyAmount c1, CurrencyAmount c2) {
    if (c1.currency != c2.currency) {
      throw new ArgumentException();
    }
    return new CurrencyAmount(c1.amount + c2.amount, c1.currency);
  }

  public static CurrencyAmount operator -(CurrencyAmount c1, CurrencyAmount c2) {
    if (c1.currency != c2.currency) {
      throw new ArgumentException();
    }
    return new CurrencyAmount(c1.amount - c2.amount, c1.currency);
  }

  public static CurrencyAmount operator *(CurrencyAmount c1, CurrencyAmount c2) {
    if (c1.currency != c2.currency) {
      throw new ArgumentException();
    }
    return new CurrencyAmount(c1.amount * c2.amount, c1.currency);
  }

  public static CurrencyAmount operator /(CurrencyAmount c1, CurrencyAmount c2) {
    if (c1.currency != c2.currency) {
      throw new ArgumentException();
    }
    return new CurrencyAmount(c1.amount / c2.amount, c1.currency);
  }

  public static implicit operator double(CurrencyAmount c) => (double)c.amount;
  public static implicit operator decimal(CurrencyAmount c) => c.amount;
}
