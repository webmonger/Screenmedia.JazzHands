using System;
using UIKit;
using System.Linq;
using CoreGraphics;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Touch
{
	public class AngleAnimation : Animation
	{

		protected UIView View;


		public AngleAnimation (UIView view) : base()
		{
			View = view;
		}


		public override void Animate(int time)
		{
			if (KeyFrames.Count() <= 1) return;

			var animationFrame = AnimationFrameForTime(time);
			View.Transform = CGAffineTransform.MakeRotation(animationFrame.Angle);
		}

		public override AnimationFrameBase FrameForTime (int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			AnimationFrame animationFrame = new AnimationFrame ();
			animationFrame.Angle = TweenValueForStartTime (startKeyFrame.Time,
				endKeyFrame.Time,
				startKeyFrame.Angle,
				endKeyFrame.Angle,
				time);

			return animationFrame;
		}
	}
}

