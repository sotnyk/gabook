using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NukeGA
{
	public class Explosion
	{
		public float X { set; get; }
		public float Y { set; get; }

		public Explosion Clone()
		{
			Explosion copy = new Explosion()
			{
				X = this.X,
				Y = this.Y,
			};
			return copy;
		}

		static Random rnd = new Random();

		public static Explosion GenerateRandom(TaskSpecification spec)
		{
			return new Explosion()
			{
				X = (float)(rnd.NextDouble() * spec.Bound.Width + spec.Bound.Left),
				Y = (float)(rnd.NextDouble() * spec.Bound.Height + spec.Bound.Top),
			};
		}
	}
}
