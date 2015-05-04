# JazzHands for iOS and Android ported to C# by Screenmedia

Jazz Hands is a simple keyframe-based animation framework for UIKit.
Animations can be controlled via gestures, scroll views, KVO, or ReactiveCocoa.

The Objective-C version of Jazz Hands is used extensively in [IFTTT for iPhone and iPad](https://ifttt.com/mobile), most famously in the app intro:

![ScreenShot](https://raw.github.com/IFTTT/JazzHands/screenshots/screenshots/intro.gif)

If you use this library and would like to be featured here please let us know.

##Demo App

Check out the demo app to see a simple demonstration of moving, resizing, fading, and hiding views in a scrolling app intro.

Download and install the component from the Component store or download the source from [GitHub](https://github.com/webmonger/Screenmedia.JazzHands)

##Installation

It's recommended that you install from the Xamarin Component Store, alternatively download the source and include the project in your solution.

##Quick Start

First, make sure monotouch is included in your project, then install the component to add JazzHands.

Add the namespace Screenmedia.JazzHands to your UIViewController.

```
using Screenmedia.JazzHands;
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

##Source

The source for the project can be found on [GitHub](https://github.com/webmonger/Screenmedia.JazzHands)

###F Sharp

There is an f# version of the demo being worked on at the moment and we'll release it as soon as possible. In the meentime if you want to see where we are at or if you'd like to help please checkout the code on [Github](https://github.com/webmonger/Screenmedia.JazzHands/tree/master/JazzHandsCSharp/Screenmedia.IFTTT.JazzHandsFSharpDemo)

## Notes

An animator can only handle one animation per type per view. If you want multiple animations of the same type on a view, use keyframes.

## Thanks
Screenmedia would like to thank IFTTT for developing this library in the first place. We'd also like to thank them for supporting this conversion and allowing us to release it on the component store. If you're not aware of IFTTT please check out their awesome platform at [https://ifttt.com/](https://ifttt.com/)

Copyright 2014 Screenmedia
