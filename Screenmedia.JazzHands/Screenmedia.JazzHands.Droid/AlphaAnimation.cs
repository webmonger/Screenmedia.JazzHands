using System;
using System.Linq;
using Android.Views;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Droid
{
	public class AlphaAnimation : Animation
	{

		protected View View;

		public AlphaAnimation(View view) : base()
		{
			View = view;
		}

		public override void Animate(int time)
		{
			if (KeyFrames.Count() <= 1) return;

			AnimationFrame animationFrame = AnimationFrameForTime(time) as AnimationFrame;
			View.Alpha = animationFrame.Alpha;
		}

		public override AnimationFrameBase FrameForTime(int time,
			AnimationFrameBase startKeyFrame,
			AnimationFrameBase endKeyFrame)
		{



			AnimationFrame animationFrame = new AnimationFrame ();
			animationFrame.Alpha = TweenValueForStartTime (startKeyFrame.Time,
				endKeyFrame.Time,
				startKeyFrame.Alpha,
				endKeyFrame.Alpha,
				time);

			return animationFrame;
		}
	}
}

