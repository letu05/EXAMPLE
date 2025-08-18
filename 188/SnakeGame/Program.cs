using System;
using System.Collections.Generic;

namespace ConsoleSnakeGame
{
	internal enum Direction
	{
		Up,
		Down,
		Left,
		Right
	}

	internal sealed class SnakeGame
	{
		private readonly int _playfieldWidth;
		private readonly int _playfieldHeight;
		private readonly LinkedList<(int x, int y)> _snake;
		private readonly HashSet<(int x, int y)> _snakeSet;
		private readonly Random _random;
		private Direction _direction;
		private (int x, int y) _food;
		private bool _gameOver;
		private int _speedMs;

		public SnakeGame(int width = 40, int height = 20, int initialSpeedMs = 120)
		{
			_playfieldWidth = Math.Max(20, width);
			_playfieldHeight = Math.Max(10, height);
			_speedMs = Math.Clamp(initialSpeedMs, 60, 300);
			_snake = new LinkedList<(int x, int y)>();
			_snakeSet = new HashSet<(int x, int y)>();
			_random = new Random();
			_direction = Direction.Right;
			_gameOver = false;

			Initialize();
		}

		private void Initialize()
		{
			Console.CursorVisible = false;
			Console.Clear();
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			// Draw border
			DrawBorder();

			// Spawn snake in the center
			var startX = _playfieldWidth / 2;
			var startY = _playfieldHeight / 2;
			for (int i = 0; i < 4; i++)
			{
				var segment = (startX - i, startY);
				_snake.AddLast(segment);
				_snakeSet.Add(segment);
			}

			// Draw initial snake
			foreach (var (x, y) in _snake)
			{
				DrawCell(x, y, 'O');
			}

			SpawnFood();
		}

		private void DrawBorder()
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			for (int x = 0; x <= _playfieldWidth + 1; x++)
			{
				WriteAt(x, 0, '#');
				WriteAt(x, _playfieldHeight + 1, '#');
			}
			for (int y = 0; y <= _playfieldHeight + 1; y++)
			{
				WriteAt(0, y, '#');
				WriteAt(_playfieldWidth + 1, y, '#');
			}
			Console.ResetColor();
		}

		private void WriteAt(int x, int y, char ch)
		{
			Console.SetCursorPosition(x, y);
			Console.Write(ch);
		}

		private void DrawCell(int x, int y, char ch)
		{
			Console.SetCursorPosition(x + 1, y + 1);
			Console.Write(ch);
		}

		private void SpawnFood()
		{
			(int x, int y) p;
			do
			{
				p = (_random.Next(0, _playfieldWidth), _random.Next(0, _playfieldHeight));
			} while (_snakeSet.Contains(p));
			_food = p;
			Console.ForegroundColor = ConsoleColor.Red;
			DrawCell(_food.x, _food.y, '*');
			Console.ResetColor();
		}

		private static Direction Opposite(Direction d) => d switch
		{
			Direction.Up => Direction.Down,
			Direction.Down => Direction.Up,
			Direction.Left => Direction.Right,
			Direction.Right => Direction.Left,
			_ => Direction.Right
		};

		private (int x, int y) NextHead((int x, int y) currentHead)
		{
			return _direction switch
			{
				Direction.Up => (currentHead.x, currentHead.y - 1),
				Direction.Down => (currentHead.x, currentHead.y + 1),
				Direction.Left => (currentHead.x - 1, currentHead.y),
				Direction.Right => (currentHead.x + 1, currentHead.y),
				_ => currentHead
			};
		}

		private bool IsWall((int x, int y) p)
		{
			return p.x < 0 || p.x >= _playfieldWidth || p.y < 0 || p.y >= _playfieldHeight;
		}

		private void HandleInput()
		{
			if (!Console.KeyAvailable) return;
			var key = Console.ReadKey(intercept: true).Key;
			var prev = _direction;
			switch (key)
			{
				case ConsoleKey.UpArrow:
					_direction = Direction.Up;
					break;
				case ConsoleKey.DownArrow:
					_direction = Direction.Down;
					break;
				case ConsoleKey.LeftArrow:
					_direction = Direction.Left;
					break;
				case ConsoleKey.RightArrow:
					_direction = Direction.Right;
					break;
				case ConsoleKey.Q:
					_gameOver = true;
					break;
				case ConsoleKey.P:
					Pause();
					break;
			}

			if (_direction == Opposite(prev))
			{
				// Prevent 180° turn directly
				_direction = prev;
			}
		}

		private void Pause()
		{
			Console.SetCursorPosition(0, _playfieldHeight + 3);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("Paused. Press any key to continue...");
			Console.ResetColor();
			Console.ReadKey(true);
			Console.SetCursorPosition(0, _playfieldHeight + 3);
			Console.Write(new string(' ', Console.BufferWidth));
		}

		public void Run()
		{
			PrintHelp();
			while (!_gameOver)
			{
				var loopStart = DateTime.UtcNow;
				HandleInput();

				var head = _snake.First!.Value;
				var next = NextHead(head);

				if (IsWall(next) || (_snakeSet.Contains(next) && next != _snake.Last!.Value))
				{
					_gameOver = true;
					break;
				}

				var ateFood = next == _food;
				_snake.AddFirst(next);
				_snakeSet.Add(next);
				Console.ForegroundColor = ConsoleColor.Green;
				DrawCell(next.x, next.y, 'O');
				Console.ResetColor();

				if (ateFood)
				{
					SpawnFood();
					_speedMs = Math.Max(60, _speedMs - 2);
				}
				else
				{
					var tail = _snake.Last!.Value;
					_snake.RemoveLast();
					_snakeSet.Remove(tail);
					DrawCell(tail.x, tail.y, ' ');
				}

				var elapsed = (int)(DateTime.UtcNow - loopStart).TotalMilliseconds;
				var delay = Math.Max(0, _speedMs - elapsed);
				System.Threading.Thread.Sleep(delay);
			}

			GameOver();
		}

		private void PrintHelp()
		{
			Console.SetCursorPosition(0, _playfieldHeight + 2);
			Console.Write("Controls: Arrow Keys = Move, P = Pause, Q = Quit");
		}

		private void GameOver()
		{
			Console.SetCursorPosition(0, _playfieldHeight + 3);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Game Over! Press R to restart or any other key to exit.");
			Console.ResetColor();
			var key = Console.ReadKey(true).Key;
			if (key == ConsoleKey.R)
			{
				// Reset state and run again
				_snake.Clear();
				_snakeSet.Clear();
				_direction = Direction.Right;
				_gameOver = false;
				_speedMs = Math.Clamp(_speedMs, 60, 300);
				Console.Clear();
				Initialize();
				Run();
			}
		}
	}

	internal static class Program
	{
		private static void Main()
		{
			// Ensure buffer and window can contain the playfield with border + info lines
			int width = 40;
			int height = 20;
			int requiredWidth = width + 2;
			int requiredHeight = height + 5;

			if (Console.BufferWidth < requiredWidth)
			{
				try { Console.BufferWidth = requiredWidth; } catch { }
			}
			if (Console.WindowWidth < requiredWidth)
			{
				try { Console.WindowWidth = requiredWidth; } catch { }
			}
			if (Console.BufferHeight < requiredHeight)
			{
				try { Console.BufferHeight = requiredHeight; } catch { }
			}
			if (Console.WindowHeight < requiredHeight)
			{
				try { Console.WindowHeight = requiredHeight; } catch { }
			}

			var game = new SnakeGame(width, height, initialSpeedMs: 120);
			game.Run();
		}
	}
}

using System;
using System.Collections.Generic;

namespace ConsoleSnakeGame
{
	internal enum Direction
	{
		Up,
		Down,
		Left,
		Right
	}

	internal sealed class SnakeGame
	{
		private readonly int _playfieldWidth;
		private readonly int _playfieldHeight;
		private readonly LinkedList<(int x, int y)> _snake;
		private readonly HashSet<(int x, int y)> _snakeSet;
		private readonly Random _random;
		private Direction _direction;
		private (int x, int y) _food;
		private bool _gameOver;
		private int _speedMs;

		public SnakeGame(int width = 40, int height = 20, int initialSpeedMs = 120)
		{
			_playfieldWidth = Math.Max(20, width);
			_playfieldHeight = Math.Max(10, height);
			_speedMs = Math.Clamp(initialSpeedMs, 60, 300);
			_snake = new LinkedList<(int x, int y)>();
			_snakeSet = new HashSet<(int x, int y)>();
			_random = new Random();
			_direction = Direction.Right;
			_gameOver = false;

			Initialize();
		}

		private void Initialize()
		{
			Console.CursorVisible = false;
			Console.Clear();
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			// Draw border
			DrawBorder();

			// Spawn snake in the center
			var startX = _playfieldWidth / 2;
			var startY = _playfieldHeight / 2;
			for (int i = 0; i < 4; i++)
			{
				var segment = (startX - i, startY);
				_snake.AddLast(segment);
				_snakeSet.Add(segment);
			}

			// Draw initial snake
			foreach (var (x, y) in _snake)
			{
				DrawCell(x, y, 'O');
			}

			SpawnFood();
		}

		private void DrawBorder()
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			for (int x = 0; x <= _playfieldWidth + 1; x++)
			{
				WriteAt(x, 0, '#');
				WriteAt(x, _playfieldHeight + 1, '#');
			}
			for (int y = 0; y <= _playfieldHeight + 1; y++)
			{
				WriteAt(0, y, '#');
				WriteAt(_playfieldWidth + 1, y, '#');
			}
			Console.ResetColor();
		}

		private void WriteAt(int x, int y, char ch)
		{
			Console.SetCursorPosition(x, y);
			Console.Write(ch);
		}

		private void DrawCell(int x, int y, char ch)
		{
			Console.SetCursorPosition(x + 1, y + 1);
			Console.Write(ch);
		}

		private void SpawnFood()
		{
			(int x, int y) p;
			do
			{
				p = (_random.Next(0, _playfieldWidth), _random.Next(0, _playfieldHeight));
			} while (_snakeSet.Contains(p));
			_food = p;
			Console.ForegroundColor = ConsoleColor.Red;
			DrawCell(_food.x, _food.y, '*');
			Console.ResetColor();
		}

		private static Direction Opposite(Direction d) => d switch
		{
			Direction.Up => Direction.Down,
			Direction.Down => Direction.Up,
			Direction.Left => Direction.Right,
			Direction.Right => Direction.Left,
			_ => Direction.Right
		};

		private (int x, int y) NextHead((int x, int y) currentHead)
		{
			return _direction switch
			{
				Direction.Up => (currentHead.x, currentHead.y - 1),
				Direction.Down => (currentHead.x, currentHead.y + 1),
				Direction.Left => (currentHead.x - 1, currentHead.y),
				Direction.Right => (currentHead.x + 1, currentHead.y),
				_ => currentHead
			};
		}

		private bool IsWall((int x, int y) p)
		{
			return p.x < 0 || p.x >= _playfieldWidth || p.y < 0 || p.y >= _playfieldHeight;
		}

		private void HandleInput()
		{
			if (!Console.KeyAvailable) return;
			var key = Console.ReadKey(intercept: true).Key;
			var prev = _direction;
			switch (key)
			{
				case ConsoleKey.UpArrow:
					_direction = Direction.Up;
					break;
				case ConsoleKey.DownArrow:
					_direction = Direction.Down;
					break;
				case ConsoleKey.LeftArrow:
					_direction = Direction.Left;
					break;
				case ConsoleKey.RightArrow:
					_direction = Direction.Right;
					break;
				case ConsoleKey.Q:
					_gameOver = true;
					break;
				case ConsoleKey.P:
					Pause();
					break;
			}

			if (_direction == Opposite(prev))
			{
				// Prevent 180° turn directly
				_direction = prev;
			}
		}

		private void Pause()
		{
			Console.SetCursorPosition(0, _playfieldHeight + 3);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("Paused. Press any key to continue...");
			Console.ResetColor();
			Console.ReadKey(true);
			Console.SetCursorPosition(0, _playfieldHeight + 3);
			Console.Write(new string(' ', Console.BufferWidth));
		}

		public void Run()
		{
			PrintHelp();
			while (!_gameOver)
			{
				var loopStart = DateTime.UtcNow;
				HandleInput();

				var head = _snake.First!.Value;
				var next = NextHead(head);

				if (IsWall(next) || (_snakeSet.Contains(next) && next != _snake.Last!.Value))
				{
					_gameOver = true;
					break;
				}

				var ateFood = next == _food;
				_snake.AddFirst(next);
				_snakeSet.Add(next);
				Console.ForegroundColor = ConsoleColor.Green;
				DrawCell(next.x, next.y, 'O');
				Console.ResetColor();

				if (ateFood)
				{
					SpawnFood();
					_speedMs = Math.Max(60, _speedMs - 2);
				}
				else
				{
					var tail = _snake.Last!.Value;
					_snake.RemoveLast();
					_snakeSet.Remove(tail);
					DrawCell(tail.x, tail.y, ' ');
				}

				var elapsed = (int)(DateTime.UtcNow - loopStart).TotalMilliseconds;
				var delay = Math.Max(0, _speedMs - elapsed);
				System.Threading.Thread.Sleep(delay);
			}

			GameOver();
		}

		private void PrintHelp()
		{
			Console.SetCursorPosition(0, _playfieldHeight + 2);
			Console.Write("Controls: Arrow Keys = Move, P = Pause, Q = Quit");
		}

		private void GameOver()
		{
			Console.SetCursorPosition(0, _playfieldHeight + 3);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Game Over! Press R to restart or any other key to exit.");
			Console.ResetColor();
			var key = Console.ReadKey(true).Key;
			if (key == ConsoleKey.R)
			{
				// Reset state and run again
				_snake.Clear();
				_snakeSet.Clear();
				_direction = Direction.Right;
				_gameOver = false;
				_speedMs = Math.Clamp(_speedMs, 60, 300);
				Console.Clear();
				Initialize();
				Run();
			}
		}
	}

	internal static class Program
	{
		private static void Main()
		{
			// Ensure buffer and window can contain the playfield with border + info lines
			int width = 40;
			int height = 20;
			int requiredWidth = width + 2;
			int requiredHeight = height + 5;

			if (Console.BufferWidth < requiredWidth)
			{
				try { Console.BufferWidth = requiredWidth; } catch { }
			}
			if (Console.WindowWidth < requiredWidth)
			{
				try { Console.WindowWidth = requiredWidth; } catch { }
			}
			if (Console.BufferHeight < requiredHeight)
			{
				try { Console.BufferHeight = requiredHeight; } catch { }
			}
			if (Console.WindowHeight < requiredHeight)
			{
				try { Console.WindowHeight = requiredHeight; } catch { }
			}

			var game = new SnakeGame(width, height, initialSpeedMs: 120);
			game.Run();
		}
	}
}


