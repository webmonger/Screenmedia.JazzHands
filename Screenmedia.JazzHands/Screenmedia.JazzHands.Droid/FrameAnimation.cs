using System;
using Android.Views;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Droid
{
	public class FrameAnimation : Animation
	{

		protected View View;

		public FrameAnimation(View view) : base()
		{
			View = view;
		}

		public override void Animate(int time)
		{
			if (KeyFrames.Count() <= 1)
				return;

			AnimationFrame animationFrame = AnimationFrameForTime(time) as AnimationFrame;

			// Store the current transform
//			Point tempTransform = new Point(View.X, View.Y);

			// Reset rotation to 0 to avoid warping
			//View.Transform = CGAffineTransform.MakeRotation(0);
//			View.Rotation = 0;

			View.SetX(Convert.ToSingle(animationFrame.Frame.X));
			View.SetY(Convert.ToSingle (animationFrame.Frame.Y));
//			AnimView.LayoutParameters = new ViewGroup.LayoutParams(Convert.ToInt32(animationFrame.Frame.Width), Convert.ToInt32(animationFrame.Frame.Height));

			Console.WriteLine (string.Format ("View: {0} X: {1} Y {2}", View.ToString (), View.GetX (), View.GetY ()));

			// Return to original transform
//			View.X = tempTransform.X;
//			View.Y = tempTransform.Y;
		}

		public override AnimationFrameBase FrameForTime(int time,
			AnimationFrameBase startKeyFrameBase,
			AnimationFrameBase endKeyFrameBase)
		{

			var startKeyFrame = startKeyFrameBase as AnimationFrame;
			var endKeyFrame = endKeyFrameBase as AnimationFrame;

			int startTime = startKeyFrame.Time;
			int endTime = endKeyFrame.Time;
			RectangleF startLocation = startKeyFrame.Frame;
			RectangleF endLocation = endKeyFrame.Frame;

			RectangleF frame = new RectangleF(Convert.ToSingle(View.GetX()), Convert.ToSingle(View.GetY()), Convert.ToSingle(View.Width), Convert.ToSingle(View.Height));
			frame.Location =
				new PointF(
					TweenValueForStartTime(startTime, endTime, startLocation.X, endLocation.X, time),
					TweenValueForStartTime(startTime, endTime, startLocation.Y, endLocation.Y, time));
			frame.Size =
				new SizeF(TweenValueForStartTime(startTime, endTime, startLocation.Width, endLocation.Width, time),
					TweenValueForStartTime(startTime, endTime, startLocation.Height, endLocation.Height, time));

			AnimationFrame animationFrame = new AnimationFrame();
			animationFrame.Frame = frame;

			return animationFrame;
		}
	}
}

