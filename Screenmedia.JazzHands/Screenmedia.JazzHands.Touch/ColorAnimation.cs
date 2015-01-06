using System;
using UIKit;
using System.Linq;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Touch
{
	public class ColorAnimation : Animation
	{

		protected UIView View;

		public ColorAnimation (UIView view) : base()
		{
			View = view;
		}

		public override void Animate(int time)
		{
			if (KeyFrames.Count() <= 1) return;

			AnimationFrame animationFrame = AnimationFrameForTime(time) as AnimationFrame;
			View.BackgroundColor = animationFrame.Color;
		
		}

		public override AnimationFrameBase FrameForTime (int time, AnimationFrameBase startKeyFrameBase, AnimationFrameBase endKeyFrameBase)
		{

			var startKeyFrame = startKeyFrameBase as AnimationFrame;
			var endKeyFrame = endKeyFrameBase as AnimationFrame;

			AnimationFrame animationFrame = new AnimationFrame ();
			float startRed = 0.0f, startBlue = 0.0f, startGreen = 0.0f, startAlpha = 0.0f;
			float endRed = 0.0f, endBlue = 0.0f, endGreen = 0.0f, endAlpha = 0.0f;

			if (GetRed (startRed, startGreen, startBlue, startAlpha, startKeyFrame.Color) &&
			    GetRed (endRed, endGreen, endBlue, endAlpha, endKeyFrame.Color)) {
				float red = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startRed, endRed, time);
				float green = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startGreen, endGreen, time);
				float blue = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startBlue, endBlue, time);
				float alpha = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startAlpha, endAlpha, time);
				animationFrame.Color = UIColor.FromRGBA (red, green, blue, alpha);
			}

			return animationFrame;
		}

		private bool GetRed(nfloat red, nfloat green, nfloat blue, nfloat alpha, UIColor color) {

			nfloat white;

			color.GetRGBA (out red, out green, out blue, out alpha);

			if (red != null && green != null && blue != null && alpha != null) {
				return true;
			} else if (color.GetWhite (out white, out alpha)) {
				// Redundant?
				red = white;
				green = white;
				blue = white;
				return true;
			}

			return false;
		}
	}
}

