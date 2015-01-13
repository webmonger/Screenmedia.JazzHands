using System;
using System.Linq;
using UIKit;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Touch
{
	public class AlphaAnimation : Animation
	{
	    
		protected UIView View;

		public AlphaAnimation(UIView view) : base ()
	    {
			View = view;
	    }

	    public override void Animate(int time)
		{
			if (KeyFrames.Count() <= 1) return;

			var animationFrame = AnimationFrameForTime(time);
			View.Alpha = animationFrame.Alpha;
		}


		public override AnimationFrameBase FrameForTime (int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			var animationFrame = new AnimationFrame ();
			animationFrame.Alpha = TweenValueForStartTime (startKeyFrame.Time,
				endKeyFrame.Time,
				startKeyFrame.Alpha,
				endKeyFrame.Alpha,
				time);

			return animationFrame;
		}


	}
}

