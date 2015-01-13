using System;
using Android.Views;
using System.Collections.Generic;
using System.Drawing;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Droid
{
	public class AnimationFrame : AnimationFrameBase
	{
		public RectangleF Frame = new RectangleF();
		public ViewStates Visibility;
		public Android.Graphics.Color Color;

	}
}