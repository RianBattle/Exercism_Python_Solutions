public struct ComplexNumber {
  private static readonly double ImaginaryUnit = Math.Sqrt(-1);
  private readonly double _real;
  private readonly double _imaginary;

  public ComplexNumber(double real, double imaginary) {
    _real = real;
    _imaginary = imaginary;
  }

  public double Real() {
    return _real;
  }

  public double Imaginary() {
    return _imaginary;
  }

  public ComplexNumber Mul(ComplexNumber other) {
    return new ComplexNumber(Real() * other.Real() - Imaginary() * other.Imaginary(),
      Imaginary() * other.Real() + Real() * other.Imaginary());
  }

  public ComplexNumber Mul(double real) {
    return this.Mul(new ComplexNumber(real, 0));
  }

  public ComplexNumber Add(ComplexNumber other) {
    return new ComplexNumber(this.Real() + other.Real(),
      this.Imaginary() + other.Imaginary());
  }

  public ComplexNumber Add(double real) {
    return this.Add(new ComplexNumber(real, 0));
  }

  public ComplexNumber Sub(ComplexNumber other) {
    return new ComplexNumber(Real() - other.Real(),
      Imaginary() - other.Imaginary());
  }

  public ComplexNumber Div(ComplexNumber other) {
    var real = (Real() * other.Real() + Imaginary() * other.Imaginary()) / (Math.Pow(other.Real(), 2) + Math.Pow(other.Imaginary(), 2)); ;
    var imaginary = (Imaginary() * other.Real() - Real() * other.Imaginary()) / (Math.Pow(other.Real(), 2) + Math.Pow(other.Imaginary(), 2));
    return new ComplexNumber(real, imaginary);
  }

  public ComplexNumber Div(double real) {
    return this.Div(new ComplexNumber(real, 0));
  }

  public double Abs() {
    return Math.Sqrt(Math.Pow(Real(), 2) + Math.Pow(Imaginary(), 2));
  }

  public ComplexNumber Conjugate() {
    return new ComplexNumber(Real(), Imaginary() * -1);
  }

  public ComplexNumber Exp() {
    double real = Math.Exp(this.Real());
    ComplexNumber imaginary = new ComplexNumber(Math.Cos(Imaginary()), Math.Sin(Imaginary()));
    return new ComplexNumber(imaginary.Real() * real, imaginary.Imaginary() * real);
  }
}