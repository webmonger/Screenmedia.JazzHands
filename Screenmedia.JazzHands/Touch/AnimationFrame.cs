using System;
using UIKit;
using System.Drawing;
using Screenmedia.JazzHands.Touch;

namespace Screenmedia.JazzHands.Touch
{
	public class AnimationFrame : Screenmedia.JazzHands.Core.AnimationFrame
	{
		public RectangleF Frame = new RectangleF();
		public UIColor Color;
		public Transform3D Transform = new Transform3D();
	
	}
}

