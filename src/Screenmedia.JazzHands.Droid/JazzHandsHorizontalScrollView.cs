using System;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;
using Android.Views;
using Android.Util;
using System.Diagnostics;
using Android.Animation;
using System.Linq;

namespace Screenmedia.JazzHands.Droid
{
	public class JazzHandsHorizontalScrollView : HorizontalScrollView
	{
		float? button1YOrigin;

		JazzHandsHorizontalScrollView _scroller;
		RelativeLayout _viewBody;
		float _startX;
		float _endX;
		List<int> _pagesStartAt= new List<int>();
		int _startPage;
		public Animator Animator{ get; set; }

		int? _pages = null;
		public int? Pages {
			get {
				return _pages;
			}
			set {
				_pages = value;
				getPage ();
			}
		}

		List<int> _pagePositions = new List<int>();

		private List<View> _views = new List<View>();
		public List<View> Views { 
			get {
				return _views;
			} 
		}

		public JazzHandsHorizontalScrollView(Context context) : base(context) {
			Init ();
		}
		public JazzHandsHorizontalScrollView(Context context, IAttributeSet attributeSet) : base(context, attributeSet) {
			Init ();
		}
		public JazzHandsHorizontalScrollView(Context context, IAttributeSet attributeSet, int defStyle) : base(context, attributeSet, defStyle) {
			Init ();
		}

		void Init (){
			Animator = new Animator();
		}

		protected override void OnDraw (Android.Graphics.Canvas canvas)
		{

			if (_pages == null)
				throw new Exception ("Please make sure you set Pages before using this control");

			_scroller = FindViewById<JazzHandsHorizontalScrollView> (this.Id);
			_viewBody = SafeCastFirstView (_scroller.GetChildAt (0));
			_viewBody.SetBackgroundColor (Android.Graphics.Color.WhiteSmoke);

			if (_viewBody == null)
				throw new Exception ("The RelativeLayout that the animation content goes in is not available. Please make sure you have a RelativeLayout within you JazzHandsHorizontalScrollView");

			int fullWidth = Resources.DisplayMetrics.WidthPixels * Pages.Value;

			((RelativeLayout)_scroller.GetChildAt(0)).AddView (new View (Context) {
				LayoutParameters = new LayoutParams(fullWidth, 0)
			});

			for (int i = 0; i < Pages.Value; i++) {
				_pagePositions.Add (i * Resources.DisplayMetrics.WidthPixels);
			}

//			int value = (int)TypedValue.ApplyDimension (ComplexUnitType.Px, 
//				            (float)Resources.DisplayMetrics.WidthPixels * Pages, Resources.DisplayMetrics);
//
//			ViewGroup.LayoutParams lp = new LinearLayout.LayoutParams (value, Resources.DisplayMetrics.HeightPixels);
//			LayoutParameters = lp;

			base.OnDraw (canvas);
		}

		protected override void OnScrollChanged (int x, int y, int oldx, int oldy) {

//			if (!button1YOrigin.HasValue)
//				button1YOrigin = _views [1].GetY ();
//
//			Trace.WriteLine("Scrolling", "X from ["+oldx+"] to ["+x+"]");
//			_views[0].SetY(x);
//			_views[1].SetY(button1YOrigin.Value-x);

			Animator.Animate(Convert.ToInt32(x));

			base.OnScrollChanged(x, y, oldx, oldy);
		}

		public override bool OnTouchEvent (MotionEvent e)
		{
			switch (e.Action) {
			case MotionEventActions.Down:
				_startX = this.ScrollX;
				this.Parent.RequestDisallowInterceptTouchEvent (true);
				break;
			case MotionEventActions.Move:
				this.Parent.RequestDisallowInterceptTouchEvent (false);
				break;
			case MotionEventActions.Up:
				_endX = this.ScrollX;
				float fullWidth = Resources.DisplayMetrics.WidthPixels;
				//ToDo: Trying to animate the scroller by assigning new position after user leave the tap
				//need to calculate the exact position of the scroller on screen and calculte
				if (_endX > (_startX + (fullWidth / 2))) { // going right to left
					_startPage = _pagesStartAt.FirstOrDefault (x => x == _startX);
					//Console.WriteLine ("Move Forward to next page: " + _startPage);
					float newPosition = _startX + fullWidth;
					ObjectAnimator animator = ObjectAnimator.OfInt (_scroller, "scrollX", Convert.ToInt32(newPosition));
					animator.Start ();
				} else if (_endX < (_startX - (fullWidth / 2))) {
					_startPage = _pagesStartAt.FirstOrDefault (x => x == _startX);
					//Console.WriteLine ("Move Forward to next page: " + _startPage);
					float newPosition = _startX - fullWidth;
					ObjectAnimator animator = ObjectAnimator.OfInt (_scroller, "scrollX", Convert.ToInt32(newPosition));
					animator.Start ();
				}else{
					//Console.WriteLine ("Move Backward to previous page: " + _startPage);
					float newPosition = _startX ;
					ObjectAnimator animator = ObjectAnimator.OfInt (_scroller, "scrollX", Convert.ToInt32(newPosition));
					animator.Start ();
				}
				this.Parent.RequestDisallowInterceptTouchEvent (false);
				break;
			}

			return base.OnTouchEvent (e);
		}

		public override void Fling (int velocityX){	}

		RelativeLayout SafeCastFirstView (View view)
		{
			return view as RelativeLayout;
		}

		private void getPage()
		{
//			float width = _scroller.Width ;
//			int page=(int)((_scroller.GetX() + (0.5f * width)) / width);
//			return page;
			for(int i = 0; i < _pages; i++)
			{
				_pagesStartAt.Add (i * Resources.DisplayMetrics.WidthPixels);
			}
		}
	}
}

