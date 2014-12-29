using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SalesAnt
{
	public class AntOptimizer
	{
		class Town
		{
			public double X { set; get; }
			public double Y { set; get; }
		}

		class RouletteSector
		{
			public double Start = 0;
			public int Town = -1;
		}

		Town[] _towns = null;
		Random _rnd = new Random();
		double[,] _distanses = null;
		double[,] _scents = null;
		double GetScent(int town1, int town2)
		{
			return _scents[Math.Min(town1, town2), Math.Max(town1, town2)];
		}
		void AddScent(int town1, int town2, double scent)
		{
			_scents[Math.Min(town1, town2), Math.Max(town1, town2)] += scent;
		}

		public Ant BestWay = null;
		public double BestWayLength = Double.MaxValue;
		public int StepCount = 0;

		public AntOptimizer(int townNumber)
		{
			// Проверяем параметры.
			if (townNumber < 3)
				throw new ArgumentOutOfRangeException("townNumber", townNumber, 
					"'townNumber' should be more then 2");
			// Инициализируем города случайными координатами.
			_towns = new Town[townNumber];
			for (int t = 0; t < townNumber; ++t)
			{
				_towns[t] = new Town()
				{
					X = _rnd.NextDouble(),
					Y = _rnd.NextDouble()
				};
			}
			// Заполняем таблицу расстояний между городами.
			_distanses = new double[townNumber,townNumber];
			for (int t1 = 0; t1 < townNumber; ++t1)
			{
				Town town1 = _towns[t1];
				for (int t2 = 0; t2 < townNumber; ++t2)
				{
					Town town2 = _towns[t2];
					_distanses[t1, t2] = Math.Sqrt(Sqr(town1.X - town2.X) + Sqr(town1.Y - town2.Y));
				}
			}
			// Инициализируем таблицу запахов. 
			_scents = new double[townNumber, townNumber];
			for (int i = 0; i < townNumber; ++i)
				for (int j = i + 1; j < townNumber; ++j)
					_scents[i, j] = 1.0;
		}

		public void Step(double alpha, double beta, double q)
		{
			StepCount++;
			int townNumber = _towns.Length;
			// По очереди пускаем муравьев. Проверяем, какой маршрут наилучший.
			for (int a = 0; a < townNumber; ++a)
			{
				Ant ant = new Ant(this, a);
				double wayLength = ant.Move(alpha, beta, q);
				if (wayLength < BestWayLength)
				{
					BestWay = ant;
					BestWayLength = wayLength;
				}
			}
			// Испаряем ферромоны
			for (int i = 0; i < townNumber; ++i)
				for (int j = i + 1; j < townNumber; ++j)
					_scents[i, j] = _scents[i, j] * 0.9;
		}

		private double Sqr(double p)
		{
			return p * p;
		}

		public Bitmap DrawMap(int width, int height)
		{
			int townNumber = _towns.Length;
			Bitmap res = new Bitmap(width, height);

			using (Graphics g = Graphics.FromImage(res))
			{
				g.Clear(Color.White);
				using (Pen towns = new Pen(Color.Red, 2))
				{
					for (int i = 0; i < townNumber; ++i)
						g.DrawEllipse(towns,
							width * (float)_towns[i].X - 2,
							height * (float)_towns[i].Y - 2,
							5, 5);
				}
				if (BestWay!=null)
				using (Pen bestWay = new Pen(Color.Black, 1))
				{
					for(int i=1; i<BestWay.Path.Count; ++i)
						g.DrawLine(bestWay,
							width * (float)_towns[BestWay.Path[i]].X,
							height * (float)_towns[BestWay.Path[i]].Y,
							width * (float)_towns[BestWay.Path[i-1]].X,
							height * (float)_towns[BestWay.Path[i-1]].Y
							);
				}
			}
			return res;
		}

		public class Ant
		{
			private AntOptimizer _owner;
			private int _townNumber = -1;
			private int _startTown;
			private Dictionary<int, int> _pathHash = new Dictionary<int, int>();

			public List<int> Path = new List<int>();

			public Ant(AntOptimizer owner, int startTown)
			{
				_owner = owner;
				_startTown = startTown;
				_townNumber = _owner._towns.Length;
			}

			public double Move(double alpha, double beta, double q)
			{
				double pathLength = 0;

				Path.Add(_startTown);
				_pathHash.Add(_startTown, _startTown);
				int currentTown = _startTown;

				for (int i = 1; i < _townNumber; ++i)
				{
					currentTown = FindNextTown(currentTown, alpha, beta);
					Path.Add(currentTown);
					_pathHash.Add(currentTown, currentTown);
				}

				Path.Add(_startTown);
				for (int i = 0; i < _townNumber; ++i)
					pathLength += _owner._distanses[Path[i], Path[i + 1]];

				for (int i = 0; i < _townNumber; ++i)
					_owner.AddScent(Path[i], Path[i + 1], q / pathLength);

				return pathLength;
			}

			private int FindNextTown(int currentTown, double alpha, double beta)
			{
				// Заполняем "рулетку" с неравными секторами
				List<RouletteSector> rouletteSectors = new List<RouletteSector>();
				double sum = 0;
				for (int i = 0; i < _townNumber; ++i)
				{
					if (!_pathHash.ContainsKey(i))
					{
						rouletteSectors.Add(
							new RouletteSector()
							{
								Start = sum,
								Town = i,
							});
						sum += Math.Pow(_owner.GetScent(currentTown, i), alpha) /
							Math.Pow(_owner._distanses[currentTown, i], beta);
					}
				}
				// Выбираем на "рулетке" случайный сектор бинарным поиском
				double val = _owner._rnd.NextDouble() * sum;
				int a = 0; int b = rouletteSectors.Count;
				while (b - a > 1)
				{
					int c = (a + b) / 2;
					if (rouletteSectors[c].Start < val)
						a = c;
					else
						b = c;
				}
				return rouletteSectors[a].Town;
			}
		}
	}
}
