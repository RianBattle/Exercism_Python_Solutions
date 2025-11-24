public enum Direction {
  North,
  East,
  South,
  West
}

public class RobotSimulator {
  private int _x;
  private int _y;
  private Direction _direction;

  public RobotSimulator(Direction direction, int x, int y) {
    _x = x;
    _y = y;
    _direction = direction;
  }

  public Direction Direction {
    get => _direction;
  }

  public int X {
    get => _x;
  }

  public int Y {
    get => _y;
  }

  public void Move(string instructions) {
    foreach (var instruction in instructions) {
      switch (instruction) {
        case 'A':
          Move();
          break;
        case 'L':
          TurnLeft();
          break;
        case 'R':
          TurnRight();
          break;
      }
    }
  }

  private void TurnLeft() {
    var newDirection = (int)_direction - 1;
    if (newDirection < 0) {
      newDirection = (int)Direction.West;
    }

    _direction = (Direction)newDirection;
  }

  private void TurnRight() {
    var newDirection = (int)_direction + 1;
    if (newDirection >= 4) {
      newDirection = (int)Direction.North;
    }

    _direction = (Direction)newDirection;
  }

  private void Move() {
    switch (_direction) {
      case Direction.North:
        _y += 1;
        break;
      case Direction.East:
        _x += 1;
        break;
      case Direction.South:
        _y -= 1;
        break;
      case Direction.West:
        _x -= 1;
        break;
    }
  }
}