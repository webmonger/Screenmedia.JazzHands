using System;


namespace Screenmedia.JazzHands.Core
{
	public abstract class AnimationFrameBase
	{

		public bool Hidden { get; set; }
		public Single Alpha { get; set; }
		public Single Angle { get; set; }
		public Single Scale { get; set; }
		public int Time { get; set; }

	}
}

