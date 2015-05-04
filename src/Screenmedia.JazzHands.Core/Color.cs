using System;

namespace Screenmedia.JazzHands.Core
{
	public class Color
	{
	
		public int Red { get; set; }
		public int Green { get; set; }
		public int Blue { get; set; }
		public int Alpha { get; set; }


		public Color (int red, int green, int blue, int alpha)
		{
	
			Red = red;
			Green = green;
			Blue = blue;
			Alpha = alpha;

		}
	}
}

