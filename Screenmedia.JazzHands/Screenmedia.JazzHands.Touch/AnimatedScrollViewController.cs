using System;
using UIKit;
using Foundation;
using ObjCRuntime;

namespace Screenmedia.JazzHands.Touch
{

	public interface IAnimatedScrollViewController 
	{
		NSObject WeakDelegate { get; set; }
		void AnimatedScrollViewControllerDidScrollToEnd(AnimatedScrollViewController animatedScrollViewController);
		void AnimatedScrollViewControllerDidEndDraggingAtEnd(AnimatedScrollViewController animatedScrollViewController);
	}


	public class AnimatedScrollViewController : UIViewController, IUIScrollViewDelegate
	{
		//public delegate void AnimatedScrollViewControllerDelegate();

		public Animator Animator{ get; set; }
		public UIScrollView ScrollView { get; set; }

		public IAnimatedScrollViewController animatedScrolledService;

		private bool _isAtEnd;

		static nfloat MaxContentOffsetXForScrollView(UIScrollView scrollView)
		{
			return scrollView.ContentSize.Width + scrollView.ContentInset.Right - scrollView.Bounds.Width;
		}

		public AnimatedScrollViewController ()
		{
			_isAtEnd = false;
			Animator = new Animator();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ScrollView = new UIScrollView(this.View.Bounds);
			ScrollView.Scrolled +=  (sender, args) =>
			{
				Animator.Animate(Convert.ToInt32(ScrollView.ContentOffset.X));

				_isAtEnd = ScrollView.ContentOffset.X >= MaxContentOffsetXForScrollView(ScrollView);

				//animatedScrolledService = ScrollView.Delegate;

				if (_isAtEnd && this.RespondsToSelector(new Selector("AnimatedScrollViewControllerDidScrollToEnd:")))
				{
					//animatedScrolledService.AnimatedScrollViewControllerDidScrollToEnd(this);
				}
			};

			ScrollView.ScrollAnimationEnded += (sender, args) => 
			{
				//WeakDelegate = scrollView.Delegate;
				//animatedScrolledService =  ScrollView.Delegate;

				if (_isAtEnd && this.RespondsToSelector(new Selector("AnimatedScrollViewControllerDidEndDraggingAtEnd:")))
				{
					//animatedScrolledService.AnimatedScrollViewControllerDidEndDraggingAtEnd(this);
				}
			};

			this.View.Add(ScrollView);
		}

	}
}

