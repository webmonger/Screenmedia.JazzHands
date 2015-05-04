using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Drawing;
using System.Collections.Generic;
using Screenmedia.JazzHands.Core;

namespace Screenmedia.JazzHands.Droid.Demo
{
	[Activity (Label = "Screenmedia.JazzHands.Droid.Demo", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity//, GestureDetector.IOnGestureListener	
	{
		GestureDetector gestureDetector;

		int count = 1;
		int _totalPages = 4;
		Single dy = 240;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it

			Button button1 = FindViewById<Button>(Resource.Id.MyButton1);
			Button button2 = FindViewById<Button>(Resource.Id.MyButton2);

			Button button3 = FindViewById<Button>(Resource.Id.MyButton3);
			Button button4 = FindViewById<Button>(Resource.Id.MyButton4);

			button1.Click += delegate { button1.Text = string.Format("{0} clicks!", count++); };
			button2.Click += delegate { button2.Text = string.Format("{0} clicks!", count++); };
			button3.Click += delegate { button3.Text = string.Format("{0} clicks!", count++); };
			button4.Click += delegate { button4.Text = string.Format("{0} clicks!", count++); };

			button1.SetBackgroundColor(Android.Graphics.Color.Blue);
			button2.SetBackgroundColor(Android.Graphics.Color.Red);
			button3.SetBackgroundColor(Android.Graphics.Color.Green);
			button4.SetBackgroundColor(Android.Graphics.Color.SlateGray);

			JazzHandsHorizontalScrollView scrollView = FindViewById<JazzHandsHorizontalScrollView> (Resource.Id.ScrollView);

			scrollView.Pages = _totalPages;
			scrollView.Views.Add (button1);
			scrollView.Views.Add (button2);
			scrollView.Views.Add (button3);
			scrollView.Views.Add (button4);

			scrollView.PageScroll (FocusSearchDirection.Left);
			scrollView.FillViewport = true;

			Console.WriteLine ("Setup Alpha Anim");
			AlphaAnimation button1AlphaAnim = new AlphaAnimation(button1);
			scrollView.Animator.AddAnimation(button1AlphaAnim);

			button1AlphaAnim.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(1),
					Alpha = 0.0f
				});
			button1AlphaAnim.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(2),
					Alpha = 1.0f
				});

			AlphaAnimation button2AlphaAnim = new AlphaAnimation(button2);
			scrollView.Animator.AddAnimation(button2AlphaAnim);

			button2AlphaAnim.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(1),
					Alpha = 0.0f
				});
			button2AlphaAnim.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(2),
					Alpha = 1.0f
				});


			Console.WriteLine ("Setup Alpha Anim End");

			Console.WriteLine ("Setup Frame Anim");

			var button1FrameAnimation = new FrameAnimation(button1);
			scrollView.Animator.AddAnimation(button1FrameAnimation);

			var newAnimaitons = new List<AnimationFrameBase> ();

			var temp1 = new RectangleF (button1.GetX(), button1.GetY(), button1.Width, button1.Height);
			temp1.Offset (new PointF (0, 0));

			newAnimaitons.Add (new AnimationFrame () {
				Time = TimeForPage (1),
				Frame = temp1
			});

			var temp2 = new RectangleF (button1.GetX(), button1.GetY(), button1.Width, button1.Height);
			temp2.Offset (new PointF (Resources.DisplayMetrics.WidthPixels, dy));

			newAnimaitons.Add (new AnimationFrame () {
				Time = TimeForPage (2),
				Frame = temp2
			});

			var temp3 = new RectangleF (button1.GetX(), button1.GetY(), button1.Width, button1.Height);
			temp3.Offset (new PointF (Resources.DisplayMetrics.WidthPixels/2, 0));

			newAnimaitons.Add (new AnimationFrame () {
				Time = TimeForPage (3),
				Frame = temp3
			});

			button1FrameAnimation.AddKeyFrames(newAnimaitons);

			// button3

			var button3FrameAnimation = new FrameAnimation(button3);
			scrollView.Animator.AddAnimation(button3FrameAnimation);

			var newAnimaitonsbutton3 = new List<AnimationFrameBase> ();
			//
			//			var temp4 = new RectangleF (button3.GetX(), button3.GetY(), button3.Width, button3.Height);
			//			temp4.Offset (new PointF (button3.GetX(), button3.GetY()));
			//
			//			newAnimaitonsbutton3.Add (new AnimationKeyFrame () {
			//				Time = TimeForPage (1),
			//				Frame = temp4
			//			});
			//
			//			var temp5 = new RectangleF (button3.GetX(), button3.GetY(), button3.Width, button3.Height);
			//			temp5.Offset (new PointF (button3.GetX(),button3.GetY()));
			//
			//			newAnimaitonsbutton3.Add (new AnimationKeyFrame () {
			//				Time = TimeForPage (2),
			//				Frame = temp5
			//			});
			//
			//			var temp6 = new RectangleF (button3.GetX(), button3.GetY(), button3.Width, button3.Height);
			//			temp6.Offset (new PointF (button3.GetX(), button3.GetY()));
			//
			//			newAnimaitonsbutton3.Add (new AnimationKeyFrame () {
			//				Time = TimeForPage (3),
			//				Frame = temp6
			//			});

			var temp7 = new RectangleF (button3.GetX(), button3.GetY(), button3.Width, button3.Height);
			temp7.Offset (new PointF (button3.GetX(),button3.GetY()-200));

			newAnimaitonsbutton3.Add (new AnimationFrame () {
				Time = TimeForPage (4),
				Frame = temp7
			});


			button3FrameAnimation.AddKeyFrames(newAnimaitonsbutton3);

			Console.WriteLine ("Setup Frame Anim End");

			//ToDo: Hide Animation

			HideAnimation button3HideAnimation = new HideAnimation(button3);
			scrollView.Animator.AddAnimation(button3HideAnimation);

			button3HideAnimation.AddKeyFrame(new AnimationFrame()
				{
					Time = TimeForPage(2),
					Visibility=ViewStates.Invisible


				});

			//ToDo: Angle Animation

			AngleAnimation button2AngleAnimation = new AngleAnimation(button3);
			scrollView.Animator.AddAnimation(button2AngleAnimation);

			button2AngleAnimation.AddKeyFrames(
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
					},
					new AnimationFrame()
					{
						Time = TimeForPage(4),
						Angle = 60.0f
					}
				});

			//ToDo : Color Animation

			ColorAnimation button3ColorAnimation = new ColorAnimation (button3);
			scrollView.Animator.AddAnimation (button3ColorAnimation);

			button3ColorAnimation.AddKeyFrames(
				new List<AnimationFrameBase>()
				{
					new AnimationFrame()
					{
						Time = TimeForPage(2),
						Color = Android.Graphics.Color.Green
					},
					new AnimationFrame()
					{
						Time = TimeForPage(3),
						Color = Android.Graphics.Color.Blue
					}
				});

		}

		int TimeForPage(float page)
		{
			return (int)(Resources.DisplayMetrics.WidthPixels * (page - 1));
		}
	}
}
