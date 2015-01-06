using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Screenmedia.JazzHands.Core
{

	public class Animation
	{
		//protected View AnimView;
		protected List<AnimationFrameBase> KeyFrames;

		private List<AnimationFrameBase> _timeline;
		// AnimationFrames
		private int _startTime;
		// in case timeline starts before t=0

		//public Animation (View view)
		public Animation()
		{
			//AnimView = view;
			InitAnimation ();
		}

		private void InitAnimation ()
		{
			KeyFrames = new List<AnimationFrameBase> ();
			_timeline = new List<AnimationFrameBase> ();
			_startTime = 0;
		}

		public void AddKeyFrames (List<AnimationFrameBase> keyFrames)
		{
			foreach (AnimationFrameBase keyFrame in keyFrames) {
				AddKeyFrame (keyFrame);
			}
		}

		public void AddKeyFrame (AnimationFrameBase keyFrame)
		{

			Debug.WriteLine (string.Format ("Add KeyFrame Time: {0}", keyFrame.Time));
				
			if (KeyFrames.Count () == 0) {
				KeyFrames.Add (keyFrame);
				return;
			}

			// because folks might add keyframes out of order, we have to sort here
			if (keyFrame.Time > ((AnimationFrameBase)KeyFrames.Last ()).Time) {
				KeyFrames.Add (keyFrame);
			} else {
				for (int i = 0; i < KeyFrames.Count (); i++) {
					if (keyFrame.Time < ((AnimationFrameBase)KeyFrames [i]).Time) {
						KeyFrames.Add (keyFrame);// TODO atIndex:i;
						break;
					}
				}
			}

			_timeline = new List<AnimationFrameBase> ();
			for (int i = 0; i < KeyFrames.Count () - 1; i++) {
				AnimationFrameBase currentKeyFrame = KeyFrames [i];
				AnimationFrameBase nextKeyFrame = KeyFrames [i + 1];

				for (int j = currentKeyFrame.Time + (i == 0 ? 0 : 1); j <= nextKeyFrame.Time; j++) {
					_timeline.Add (FrameForTime (j, currentKeyFrame, nextKeyFrame));
				}
			}
			_startTime = ((AnimationFrameBase)KeyFrames [0]).Time;
		}

		public virtual AnimationFrameBase FrameForTime (int time,
			AnimationFrameBase startKeyFrame,
			AnimationFrameBase endKeyFrame)
		{
			Debug.WriteLine ("Hey pal! You need to use a subclass of IFTTTAnimation.");
			return startKeyFrame;
		}

		public AnimationFrameBase AnimationFrameForTime (int time)
		{
			if (time < _startTime) {
				return _timeline [0];
			}

			if (time - _startTime < _timeline.Count ()) {
				return _timeline [time - _startTime];
			}

			return _timeline.Last ();
		}

		public virtual void Animate (int time)
		{
			Debug.WriteLine (@"Hey pal! You need to use a subclass of IFTTTAnimation.");
		}

		protected Single TweenValueForStartTime (int startTime,
		                                         int endTime,
		                                         Single startValue,
		                                         Single endValue,
		                                         Single time)
		{
			Single dt = (endTime - startTime);
			Single timePassed = (time - startTime);
			Single dv = (endValue - startValue);
			Single vv = dv / dt;
			return (timePassed * vv) + startValue;
		}

	}


}