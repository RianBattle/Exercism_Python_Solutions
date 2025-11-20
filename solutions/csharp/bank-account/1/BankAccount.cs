public class BankAccount {
  private decimal _balance;

  public bool IsOpen { get; private set; } = false;
  public decimal Balance {
    get {
      if (!IsOpen) {
        throw new InvalidOperationException("Account is closed.");
      }
      return _balance;
    }
  }

  public void Open() {
    if (IsOpen) {
      throw new InvalidOperationException("Account is already opened.");
    }

    _balance = 0;
    IsOpen = true;
  }

  public void Close() {
    if (!IsOpen) {
      throw new InvalidOperationException();
    }
    IsOpen = false;
  }

  public void Deposit(decimal change) {
    if (change < 0 || !IsOpen) {
      throw new InvalidOperationException();
    }

    _balance += change;
  }

  public void Withdraw(decimal change) {
    if (change < 0 || _balance - change < 0 || !IsOpen) {
      throw new InvalidOperationException();
    }

    _balance -= change;
  }
}
