using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NukeGA
{
	public class Individual
	{
		public List<Explosion> Explosions = new List<Explosion>();

		public double Fitness = Double.MaxValue;

		public static Individual GenerateRandom(TaskSpecification spec)
		{
			var result = new Individual();
			for (int i = 0; i < spec.ExplositionsNumber; ++i)
				result.Explosions.Add(Explosion.GenerateRandom(spec));
			return result;
		}

		public void CalcFitness(TaskSpecification spec)
		{
			using (Bitmap current = GenerateBitmap(spec))
			{
				Fitness = BitmapUtils.CalcBlackPoints(current);
			}
		}

		private double Sqr(int p)
		{
			return p * p;
		}

		public Bitmap GenerateBitmap(TaskSpecification spec)
		{
			Bitmap result;
			lock (spec.OriginalField)
			{
				result = new Bitmap(spec.OriginalField);
			}
			using (Graphics g = Graphics.FromImage(result))
			{
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
				using (Brush brush = new SolidBrush(Color.Tomato))
				{
					foreach (Explosion explosion in Explosions)
					{
						g.FillEllipse(brush, 
							explosion.X - spec.KillingRadius, explosion.Y - spec.KillingRadius,
							spec.KillingRadius * 2, spec.KillingRadius * 2);
					}
				}
			}
			return result;
		}

		public Individual Clone()
		{
			var result = new Individual();
			foreach (Explosion stroke in Explosions)
				result.Explosions.Add(stroke.Clone());
			return result;
		}

		public void SpatialCrossoverWith(Individual parent2, TaskSpecification spec)
		{
			float x0 = (float)(rnd.NextDouble() * spec.Bound.Width + spec.Bound.Width);
			float y0 = (float)(rnd.NextDouble() * spec.Bound.Height + spec.Bound.Height);
			float radius = (float)(rnd.NextDouble() * Math.Max(spec.Bound.Width, spec.Bound.Height));

			List<Explosion> newGenome = new List<Explosion>();
			bool[] used1 = new bool[spec.ExplositionsNumber];
			bool[] used2 = new bool[spec.ExplositionsNumber];
			bool[] deleted = new bool[spec.ExplositionsNumber * 2];
			// Добавляем точки из первого решения
			for (int i = 0; i < spec.ExplositionsNumber; ++i)
			{
				Explosion sp = this.Explosions[i];
				if (radius > Math.Abs(sp.X - x0) + Math.Abs(sp.Y - y0))
				{
					newGenome.Add(sp.Clone());
					used1[i] = true;
				}
			}
			// Добавляем точки из второго решения
			for (int i = 0; i < spec.ExplositionsNumber; ++i)
			{
				Explosion sp = parent2.Explosions[i];
				if (radius <= Math.Abs(sp.X - x0) + Math.Abs(sp.Y - y0))
				{
					newGenome.Add(sp.Clone());
					used2[i] = true;
				}
			}

			// Приводим количество точек нового решения к необходимому
			if (newGenome.Count > spec.ExplositionsNumber)
			{
				// Удаляем лишние точки
				int num = newGenome.Count - spec.ExplositionsNumber;
				for (int i = 0; i < num; ++i)
				{
					int delNum;
					do
					{
						delNum = rnd.Next(newGenome.Count);
					} while (deleted[delNum]);
					deleted[delNum] = true;
				}
                List<Explosion> tmpGenome = new List<Explosion>(spec.ExplositionsNumber);
                for (int i = 0; i < newGenome.Count; ++i)
                    if (!deleted[i])
                        tmpGenome.Add(newGenome[i]);
                newGenome = tmpGenome;
			}
			else if (newGenome.Count < spec.ExplositionsNumber)
			{
				// Добавляем недостающие из первого решения
				while (newGenome.Count < spec.ExplositionsNumber)
				{
					int addNum;
					do
					{
						addNum = rnd.Next(spec.ExplositionsNumber);
					} while (used1[addNum]);
					used1[addNum] = true;
					newGenome.Add(this.Explosions[addNum]);
				}
			}

			// Копируем полученное решение в геном первого родителя
			Explosions = newGenome;
		}

		static Random rnd = new Random();

		public void Mutate(TaskSpecification spec)
		{
			Explosions[rnd.Next(Explosions.Count)] = Explosion.GenerateRandom(spec);
		}

        public void Stepping(TaskSpecification spec)
        {
            int indexOfChange = rnd.Next(Explosions.Count);
            float shiftX = (float)((rnd.NextDouble() - 0.5) * spec.KillingRadius * 0.25);
            float shiftY = (float)((rnd.NextDouble() - 0.5) * spec.KillingRadius * 0.25);
            Explosion explosition = Explosions[indexOfChange];
            explosition.X = Limit(explosition.X + shiftX, spec.Bound.Left, spec.Bound.Right);
            explosition.Y = Limit(explosition.Y + shiftY, spec.Bound.Top, spec.Bound.Bottom);
        }

        private float Limit(float x, float min, float max)
        {
            if (x < min)
                return min;
            if (x > max)
                return max;
            return x;
        }
	}
}
