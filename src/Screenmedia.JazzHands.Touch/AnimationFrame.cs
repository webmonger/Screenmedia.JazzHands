using System;
using UIKit;
using System.Drawing;
using Screenmedia.JazzHands.Touch;
using Screenmedia.JazzHands.Core;
using CoreGraphics;

namespace Screenmedia.JazzHands.Touch
{
	public class AnimationFrame : AnimationFrameBase
	{
		public UIColor Color;
		public CGRect Frame;
		public Transform3D Transform = new Transform3D();


	}
}

