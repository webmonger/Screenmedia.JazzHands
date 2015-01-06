using System;
using System.Linq;
using Android.Views;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Droid
{
	public class HideAnimation : Animation
	{

		protected View View;

		public HideAnimation (View view) : base()
		{
			View = view;
		}

		public override void Animate(int time)
		{
			if (KeyFrames.Count <= 1) return;

			AnimationFrame animationFrame = AnimationFrameForTime(time) as AnimationFrame;
			View.Visibility = animationFrame.Visibility;

		}

		public override AnimationFrameBase FrameForTime(int time,
			AnimationFrameBase startKeyFrame,
			AnimationFrameBase endKeyFrame)
		{
			AnimationFrame animationFrame = new AnimationFrame ();
			animationFrame.Hidden = (time == startKeyFrame.Time ? startKeyFrame : endKeyFrame).Hidden;

			return animationFrame;
		}
	}
}

