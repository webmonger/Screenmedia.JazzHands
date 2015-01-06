using System;
using Android.Views;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Droid
{
	public class ScaleAnimation: Animation
	{

		protected View View;

		public ScaleAnimation (View view) : base()
		{
			View = view;
		}

		public override void Animate(int time)
		{
			if (KeyFrames.Count <= 1) return;

			AnimationFrame animationFrame = AnimationFrameForTime(time) as AnimationFrame;
			float scale = animationFrame.Scale;
			//View.Transform = CGAffineTransform.MakeScale (scale, scale);
		}

		public override AnimationFrameBase FrameForTime(int time,
			AnimationFrameBase startKeyFrame,
			AnimationFrameBase endKeyFrame)
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

