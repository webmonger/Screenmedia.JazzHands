using System;
using Android.Views;
using System.Linq;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Droid
{
	public class AngleAnimation: Animation
	{

		protected View View;

		public AngleAnimation (View view) : base()
		{
			View = view;
		}

		public override void Animate(int time)
		{
			if (KeyFrames.Count() <= 1) return;

			AnimationFrame animationFrame = AnimationFrameForTime(time) as AnimationFrame;
			View.Rotation=animationFrame.Angle;
		}

		public override AnimationFrameBase FrameForTime(int time,
			AnimationFrameBase startKeyFrameBase,
			AnimationFrameBase endKeyFrameBase)
		{

			var startKeyFrame = startKeyFrameBase as AnimationFrame;
			var endKeyFrame = endKeyFrameBase as AnimationFrame;

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

