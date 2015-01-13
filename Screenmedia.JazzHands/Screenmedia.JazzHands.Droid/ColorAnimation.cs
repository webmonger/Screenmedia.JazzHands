using System;
using Android.Views;
using System.Linq;
using Android.Graphics;
using Screenmedia.JazzHands.Core;


namespace Screenmedia.JazzHands.Droid
{
	public class ColorAnimation : Animation
	{

		protected View View;

		public ColorAnimation (View view) : base()
		{
			View = view;
		}

		public override void Animate(int time)
		{
			if (KeyFrames.Count() <= 1) return;

			AnimationFrame animationFrame = AnimationFrameForTime(time) as AnimationFrame;
			View.SetBackgroundColor (animationFrame.Color);
		}

		public override AnimationFrameBase FrameForTime(int time, AnimationFrameBase startKeyFrameBase,AnimationFrameBase endKeyFrameBase)
		{

			var startKeyFrame = startKeyFrameBase as AnimationFrame;
			var endKeyFrame = endKeyFrameBase as AnimationFrame;

			AnimationFrame animationFrame = new AnimationFrame ();
			int startRed = 0, startBlue = 0, startGreen = 0, startAlpha = 0;
			int endRed = 0, endBlue = 0, endGreen = 0, endAlpha = 0;

			if(GetRGBA ( out startRed, out startGreen,out startBlue,out startAlpha, startKeyFrame.Color) && 
				GetRGBA (out endRed,out endGreen,out endBlue,out endAlpha, endKeyFrame.Color))
			{

				int red = (int)(TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startRed, endRed, time));
				int green = (int)(TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time,startGreen, endGreen, time));
				int blue = (int)(TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startBlue, endBlue, time));
				int alpha = (int)(TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startAlpha, endAlpha, time) );

				animationFrame.Color = Color.Argb(alpha,red,green,blue);

			}

			return animationFrame;
		}

		private bool GetRGBA( out int red, out int green, out int blue, out int alpha, Color color)
		{
			red = ((color >> 16) & 0xFF) ;
			green = ((color >> 8) & 0xFF) ;
			blue = ((color >> 0) & 0xFF) ;
			alpha = ((color >> 32) & 0xFF) ;

			if (red != null && green != null && blue != null && alpha != null)
				return true;

			return false;
		}
	}
}

