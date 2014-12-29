using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NukeGA
{
	public class TaskSpecification
	{
		public RectangleF Bound { get; set; }
		public int ExplositionsNumber { get; set; }
		public float KillingRadius { get; set; }
		public Bitmap OriginalField { get; set; }
	}
}
