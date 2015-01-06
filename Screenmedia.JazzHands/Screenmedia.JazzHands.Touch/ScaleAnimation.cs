using System;
using UIKit;
using System.Linq;
using CoreGraphics;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Touch
{
	public class ScaleAnimation : Animation
	{

		protected UIView View;

		public ScaleAnimation (UIView view) : base()
		{
			View = view;
		}

		public override void Animate(int time)
		{
			if (KeyFrames.Count <= 1) return;

			AnimationFrame animationFrame = (AnimationFrame) AnimationFrameForTime(time);
			float scale = animationFrame.Scale;
			View.Transform = CGAffineTransform.MakeScale (scale, scale);
		}

		public override AnimationFrameBase FrameForTime (int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			AnimationFrame animationFrame = new AnimationFrame ();
			animationFrame.Scale = TweenValueForStartTime (startKeyFrame.Time,
				endKeyFrame.Time,
				startKeyFrame.Scale,
				endKeyFrame.Scale,
				time);

			return animationFrame;
		}
	}
}

