using System;
using System.Drawing;
using Foundation;
using UIKit;
using System.Linq;
using CoreGraphics;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Touch
{
    public class FrameAnimation : Animation
    {
        

		protected UIView View;

		public FrameAnimation(UIView view) : base()
        {
			View = view;
        }

		public override void Animate(int time)
        {
            if (KeyFrames.Count() <= 1)
                return;

			AnimationFrame animationFrame = AnimationFrameForTime(time) as AnimationFrame;

            // Store the current transform
            CGAffineTransform tempTransform = View.Transform;

            // Reset rotation to 0 to avoid warping
            View.Transform = CGAffineTransform.MakeRotation(0);
            View.Frame = animationFrame.Frame;

            // Return to original transform
            View.Transform = tempTransform;
        }

		public override AnimationFrameBase FrameForTime (int time, AnimationFrameBase startKeyFrameBase, AnimationFrameBase endKeyFrameBase)
		{
            
			var startKeyFrame = startKeyFrameBase as AnimationFrame;
			var endKeyFrame = endKeyFrameBase as AnimationFrame;

			int startTime = startKeyFrame.Time;
            int endTime = endKeyFrame.Time;
			CGRect startLocation = startKeyFrame.Frame;
			CGRect endLocation = endKeyFrame.Frame;

			CGRect frame = View.Frame;
            frame.Location =
                new PointF(
					TweenValueForStartTime(startTime, endTime, (Single) startLocation.GetMinX(), (Single) endLocation.GetMinX(), time),
					TweenValueForStartTime(startTime, endTime, (Single) startLocation.GetMinY(), (Single) endLocation.GetMinY(), time));
            frame.Size =
				new SizeF(TweenValueForStartTime(startTime, endTime, (Single) startLocation.Width, (Single) endLocation.Width, time),
					TweenValueForStartTime(startTime, endTime, (Single) startLocation.Height, (Single) endLocation.Height, time));

            AnimationFrame animationFrame = new AnimationFrame();
			animationFrame.Frame = frame;

            return animationFrame;
        }
    }
}

