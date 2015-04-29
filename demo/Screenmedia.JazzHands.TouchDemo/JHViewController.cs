using System;
using Screenmedia.JazzHands.Touch;
using UIKit;
using System.Drawing;
using System.Collections.Generic;
using Foundation;
using Screenmedia.JazzHands.Core;
using CoreGraphics;

namespace Screenmedia.JazzHands.TouchDemo
{
	public class JHViewController : AnimatedScrollViewController, IAnimatedScrollViewController
	{
		private const int NumberOfPages = 4;

		public UIImageView Wordmark { get; set;}
		public UIImageView Unicorn { get; set;}
		public UILabel LastLabel { get; set;}
		public UILabel FirstLabel { get; set;}


		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ScrollView.ContentSize = new CGSize (NumberOfPages * (float) View.Frame.Width, (float) View.Frame.Height);

			ScrollView.PagingEnabled = true;
			ScrollView.ShowsHorizontalScrollIndicator = false;

			// Perform any additional setup after loading the view, typically from a nib.
			PlaceViews();
			ConfigureAnimation();
		}

		private void PlaceViews ()
		{
			// put a unicorn in the middle of page two, hidden
			Unicorn = new UIImageView(UIImage.FromBundle("404_unicorn"));
			Unicorn.Center = View.Center;
			Unicorn.Alpha = 0.0f;
			var rect = Unicorn.Frame;
			rect.Offset (new CGPoint ( (float) View.Frame.Width, -100));
			Unicorn.Frame = rect;
			ScrollView.AddSubview(Unicorn);


			// put a logo on top of it
			Wordmark = new UIImageView(UIImage.FromBundle("IFTTT"));
			Wordmark.Center = View.Center;
			var rect2 = Wordmark.Frame;
			rect2.Offset (new CGPoint ( (float) View.Frame.Width, -100));
			Wordmark.Frame = rect2;
			ScrollView.AddSubview(Wordmark);

			FirstLabel = AddLabel ("Introducing Jazz Hands", false);
			ScrollView.AddSubview(FirstLabel);
			UILabel secondPageText = AddLabel ("Brought to you by IFTTT", true, 2, 180);
			ScrollView.AddSubview(secondPageText);
			UILabel thirdPageText = AddLabel ("Simple keyframe animations", true, 3, -100);
			ScrollView.AddSubview(thirdPageText);
			UILabel fourthPageText = AddLabel ("Optimized for scrolling intros", true, 4, 0);
			ScrollView.AddSubview(fourthPageText);

			LastLabel = fourthPageText;
		}


		int TimeForPage(float page)
		{
			return (int)(View.Frame.Size.Width * (page - 1));
		}

		private UILabel AddLabel(string text, bool IsOffset, int page = 0, float y = 0)
		{
			var l = new UILabel();
			l.Text = text;
			l.SizeToFit();
			l.Center = View.Center;
			if (IsOffset) 
			{
				var rect = l.Frame;
				rect.Offset (new CGPoint (TimeForPage (page), y));
				l.Frame = rect;
			}
			return l;
		}

		private void ConfigureAnimation()
		{
			Single dy = 240;
			// apply a 3D zoom animation to the first label
			Transform3DAnimation labelTransform = new Transform3DAnimation(FirstLabel, 0.3f);
			Transform3D tt1 = new Transform3D() {M34 = 0.03f};
			Transform3D tt2 = new Transform3D() {M34 = 0.3f};
			tt2.Rotate = new Transform3DRotate {Angle = Convert.ToSingle(Math.PI), X = 1, Y = 0, Z = 0};
			tt2.Translate = new Transform3DTranslate() {Tx = 320, Ty = 150, Tz = -50};
			tt2.Scale = new Transform3DScale(){ Sx = 1.0f,Sy = 1.0f,Sz = 1.0f };
			labelTransform.AddKeyFrame(new AnimationFrame()
				{
					Time= TimeForPage(0),
					Alpha = 1.0f
				});
			labelTransform.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(1),
					Transform = tt1
				});
			labelTransform.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(1.5f),
					Transform = tt2
				});
			//	        labelTransform.AddKeyFrame(new AnimationKeyFrame()
			//	        {
			//	            Time = TimeForPage(1.5f) + 1,
			//	            Alpha = 0.0f
			//	        });
			Animator.AddAnimation(labelTransform);

			// let's animate the wordmark
			var wordmarkFrameAnimation = new FrameAnimation(Wordmark);
			Animator.AddAnimation(wordmarkFrameAnimation);

			var newAnimaitons = new List<AnimationFrameBase> ();

			var temp1 = Wordmark.Frame;
			temp1.Offset (new CGPoint (200, 0));

			newAnimaitons.Add (new AnimationFrame () {
				Time = TimeForPage (1),
				Frame = temp1
			});

			newAnimaitons.Add (new AnimationFrame() {Time = TimeForPage(2), Frame = Wordmark.Frame});


			var temp2 = Wordmark.Frame;
			temp2.Offset (new CGPoint ((float) View.Frame.Width, dy));

			newAnimaitons.Add (new AnimationFrame () {
				Time = TimeForPage (3),
				Frame = temp2
			});

			var temp3 = Wordmark.Frame;
			temp3.Offset (new CGPoint (0, dy));

			newAnimaitons.Add (new AnimationFrame () {
				Time = TimeForPage (4),
				Frame = temp3
			});

			wordmarkFrameAnimation.AddKeyFrames(newAnimaitons);

			//Rotate a full circle from page 2 to 3
			var wordmarkRotationAnimation = new AngleAnimation (Wordmark);
			Animator.AddAnimation (wordmarkRotationAnimation);
			wordmarkRotationAnimation.AddKeyFrames(
				new List<AnimationFrameBase>()
				{
					new AnimationFrame()
					{
						Time = TimeForPage(2),
						Angle = 0.0f
					},
					new AnimationFrame()
					{
						Time = TimeForPage(3),
						Angle = Convert.ToSingle(2*Math.PI)
					}
				} );

			// now, we animate the unicorn
			FrameAnimation unicornFrameAnimation = new FrameAnimation(Unicorn);
			Animator.AddAnimation (unicornFrameAnimation);

			float ds = 50f;

			// move down and to the right, and shrink between pages 2 and 3
			unicornFrameAnimation.AddKeyFrame (new AnimationFrame {
				Time = TimeForPage (2),
				Frame = Unicorn.Frame
			});

			Unicorn.Frame = CGRect.Inflate(Unicorn.Frame, -ds, -ds);


			var uTemp1 = Unicorn.Frame;
			uTemp1.Offset (TimeForPage (2), dy);
			Unicorn.Frame = uTemp1;

			var animKeyFrame = new AnimationFrame
			{
				Time = TimeForPage(3),
				Frame = Unicorn.Frame
			};
			unicornFrameAnimation.AddKeyFrame(animKeyFrame);

			// fade the unicorn in on page 2 and out on page 4
			AlphaAnimation unicornAlphaAnimation = new AlphaAnimation(Unicorn);
			Animator.AddAnimation(unicornAlphaAnimation);

			unicornAlphaAnimation.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(1),
					Alpha = 0.0f
				});
			unicornAlphaAnimation.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(2),
					Alpha = 1.0f
				});
			unicornAlphaAnimation.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(3),
					Alpha = 1.0f
				});
			unicornAlphaAnimation.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(4),
					Alpha = 0.0f
				});

			// Fade out the label by dragging on the last page
			AlphaAnimation labelAlphaAnimation = new AlphaAnimation(this.LastLabel);

			labelAlphaAnimation.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(4),
					Alpha = 1.0f
				});
			labelAlphaAnimation.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(4.35f),
					Alpha = 0.0f
				});
			Animator.AddAnimation(labelAlphaAnimation);

		}

		#region IAnimatedScrollViewController implementation

		public NSObject WeakDelegate { get; set; }

		public void AnimatedScrollViewControllerDidScrollToEnd (AnimatedScrollViewController animatedScrollViewController)
		{
			System.Console.WriteLine(@"Scrolled to end of scrollview!");
		}

		public void AnimatedScrollViewControllerDidEndDraggingAtEnd (AnimatedScrollViewController animatedScrollViewController)
		{
			System.Console.WriteLine(@"Scrolled to end of scrollview!");
		}

		#endregion
	}
}

