//using System;
//using System.Linq;
//using MonoTouch.Foundation;
//using MonoTouch.UIKit;
//using System.Collections.Generic;
//
//namespace Screenmedia.IFTTT.JazzHands
//{
//	public class Animation : NSObject
//	{
//		protected UIView View;
//		protected List<AnimationKeyFrame> KeyFrames;
//
//		private List<AnimationFrame> _timeline; // AnimationFrames
//		private int _startTime; // in case timeline starts before t=0
//
////		public Animation ()
////		{
////            InitAnimation();
////		}
//
//        public Animation(UIView view) : base()
//        {
//            View = view;
//            InitAnimation();
//        }
//        private void InitAnimation()
//        {
//            KeyFrames = new List<AnimationKeyFrame>();
//            _timeline = new List<AnimationFrame>();
//            _startTime = 0;
//        }
//
//	    public void AddKeyFrames(List<AnimationKeyFrame> keyFrames){
//			foreach (AnimationKeyFrame keyFrame in keyFrames) {
//				AddKeyFrame(keyFrame);
//			}
//		}
//
//		public void AddKeyFrame(AnimationKeyFrame keyFrame){
//			if (KeyFrames.Count() == 0) {
//				KeyFrames.Add(keyFrame);
//				return;
//			}
//
//			// because folks might add keyframes out of order, we have to sort here
//			if (keyFrame.Time > ((AnimationKeyFrame)KeyFrames.Last()).Time) {
//				KeyFrames.Add(keyFrame);
//			} else {
//				for (int i = 0; i < KeyFrames.Count(); i++) {
//					if (keyFrame.Time < ((AnimationKeyFrame)KeyFrames[i]).Time) {
//						KeyFrames.Add(keyFrame);// TODO atIndex:i;
//						break;
//					}
//				}
//			}
//
//			_timeline = new List<AnimationFrame> ();
//			for (int i = 0; i < KeyFrames.Count() - 1; i++) {
//				AnimationKeyFrame currentKeyFrame = KeyFrames[i];
//				AnimationKeyFrame nextKeyFrame = KeyFrames[i+1];
//
//				for (int j = currentKeyFrame.Time + (i == 0 ? 0 : 1); j <= nextKeyFrame.Time; j++) {
//					_timeline.Add (FrameForTime (j, currentKeyFrame, nextKeyFrame));
//				}
//			}
//			_startTime = ((AnimationKeyFrame)KeyFrames [0]).Time;
//		}
//
//		public virtual AnimationFrame FrameForTime (int time,
//			AnimationKeyFrame startKeyFrame,
//			AnimationKeyFrame endKeyFrame)
//		{
//			System.Console.WriteLine("Hey pal! You need to use a subclass of IFTTTAnimation.");
//			return startKeyFrame;
//		}
//
//        public AnimationFrame AnimationFrameForTime(int time)
//        {
//			if (time < _startTime) {
//				return _timeline[0];
//			}
//
//			if (time - _startTime < _timeline.Count()) {
//				return _timeline[time - _startTime];
//			}
//
//			return _timeline.Last();
//		}
//
//		public virtual void Animate(int time)
//		{
//			Console.WriteLine(@"Hey pal! You need to use a subclass of IFTTTAnimation.");
//		}
//
//		protected Single TweenValueForStartTime(int startTime,
//				int endTime,
//				Single startValue,
//				Single endValue,
//				Single time){
//			Single dt = (endTime - startTime);
//			Single timePassed = (time - startTime);
//			Single dv = (endValue - startValue);
//			Single vv = dv / dt;
//			return (timePassed * vv) + startValue;
//		}
//	}
//}
//
