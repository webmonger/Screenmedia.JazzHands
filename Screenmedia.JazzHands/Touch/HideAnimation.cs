using System;
using System.Linq;
using UIKit;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Touch
{
	public class HideAnimation : Animation
	{

		protected UIView View;

		public HideAnimation (UIView view, int time) : base()
		{
			View = view;

		}

		public override void Animate(int time)
		{
			if (KeyFrames.Count <= 1) return;

			AnimationFrame animationFrame = (AnimationFrame) AnimationFrameForTime(time);
			View.Hidden = animationFrame.Hidden;
		}

		public override AnimationFrameBase FrameForTime (int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			AnimationFrame animationFrame = new AnimationFrame ();
			animationFrame.Hidden = (time == startKeyFrame.Time ? startKeyFrame : endKeyFrame).Hidden;

			return animationFrame;
		}
	}
}

