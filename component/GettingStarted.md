# Getting Started
First, make sure monotouch is included in your project, then install the component to add JazzHands.

Add the namespace Screenmedia.IFTTT.JazzHands to your UIViewController.

```
using Screenmedia.IFTTT.JazzHands;
```

Note: Don't use Autolayout with your view as it wont work.

On you view controller inherit from

```
public class MyViewController : AnimatedScrollViewController, IAnimatedScrollViewController
```

Now create an animation for a view that you want to animate. There are multiple
types of animation that can be applied to a view. For this example, we'll use
FrameAnimation, which moves and sizes a view. Once thats been created we need to add it to the animatior so it adds the animations to the timeline.

```
var frameAnimation = new FrameAnimation(viewToAnimate);
Animator.AddAnimation(frameAnimation);
```

Register the animation with the animator.

Add some keyframes to the animation. First we create a list of AnimationKeyFrames then create each animation item, let's move this view to 200 on the x axis, between pages 1 and 2.

```
var frameAnimationList = new List<AnimationKeyFrame> ();
var frame = Wordmark.Frame;
frame.Offset (new PointF (200, 0));

frameAnimationList.Add (new AnimationKeyFrame () {
	Time = TimeForPage (1),
	Frame = frame
});

frameAnimationList.Add (new AnimationKeyFrame() {Time = TimeForPage(2), Frame = Wordmark.Frame});
```

You now need to commit the animations to the frameAnimation

```
frameAnimation.AddKeyFrames(newAnimaitons);
```

This will produce an effect where the view will be at it's start positionand as scrolled between page 1 and page 2 it will move to 200 on the x axis.
##Animation Types

Jazz Hands supports several types of animations:

+ **FrameAnimation** moves and sizes views.
+ **AlphaAnimation** creates fade effects.
+ **HideAnimation** hides and shows views.
+ **AngleAnimation** for rotation effects.
+ **Transform3DAnimation** for 3D transforms.
+ **ScaleAnimation** to scale view sizes.
+ **ConstraintsAnimation** animates AutoLayout constraint constants. **(Currently incomplete!)**
