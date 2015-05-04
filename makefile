MDTOOL ?= /Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool

XAMARIN_COMPONENT ?= component/xamarin-component.exe
# Path to mono, which by default should be on your PATH.
MONO ?= mono

.PHONY: all component clean

all:
	$(MDTOOL) build -t:Clean -c:Release "Screenmedia.JazzHands.sln"
	$(MDTOOL) build -t:Build -c:Release "Screenmedia.JazzHands.sln"
	mkdir -p ./build/Core
	mv ./src/Screenmedia.JazzHands.Core/bin/Release/* ./build/Core
	mkdir -p ./build/Droid
	mv ./src/Screenmedia.JazzHands.Droid/bin/Release/* ./build/Droid
	mkdir -p ./build/Touch
	mv ./src/Screenmedia.JazzHands.Touch/bin/Release/* ./build/Touch
	$(MONO) $(XAMARIN_COMPONENT) package component
	mono .nuget/NuGet.exe pack ./Screenmedia.JazzHands.nuspec
#	mv Screenmedia.JazzHands*.nupkg ./build/

clean:
	$(MDTOOL) build -t:Clean Screenmedia.JazzHands.sln
	rm *.dll
	rm -rf build