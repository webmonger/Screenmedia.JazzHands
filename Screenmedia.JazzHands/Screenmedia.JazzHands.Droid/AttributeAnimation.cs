using System;
using Android.Views;
using System.Linq;
using System.Drawing;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Droid
{
	public class AttributeAnimation: Animation
	{

		protected View View;

		public AttributeAnimation (View view) : base()
		{
			View = view;
		}
		public override void Animate(int time)
		{
			if (KeyFrames.Count() <= 1) return;

			AnimationFrame animationFrame = AnimationFrameForTime(time) as AnimationFrame;
			//AnimView.Rotation=animationFrame.Angle;
		}

//		public override AnimationFrame FrameForTime(int time,
//			AnimationKeyFrame startKeyFrame,
//			AnimationKeyFrame endKeyFrame)
//		{
//			int startTime = startKeyFrame.Time;
//			int endTime = endKeyFrame.Time;
////			RectangleF startLocation = startKeyFrame.Scale;
////			RectangleF endLocation = endKeyFrame.Scale;
//
////			RectangleF frame = new RectangleF(Convert.ToSingle(AnimView.GetX()), Convert.ToSingle(AnimView.GetY()), Convert.ToSingle(AnimView.Width), Convert.ToSingle(AnimView.Height));
////			frame.Location =
////				new PointF(
////					TweenValueForStartTime(startTime, endTime, startLocation.Width, endLocation.Width, time),
////					TweenValueForStartTime(startTime, endTime, startLocation.Height, endLocation.Height, time));
////			frame.Size =
////				new SizeF(TweenValueForStartTime(startTime, endTime, startLocation.Width, endLocation.Width, time),
////					TweenValueForStartTime(startTime, endTime, startLocation.Height, endLocation.Height, time));
////
////			AnimationFrame animationFrame = new AnimationFrame();
////			animationFrame.Frame = frame;
//
//			return animationFrame;
//		}
	}
}

