MDTOOL ?= /Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool

.PHONY: all clean

package: all

all:
	$(MDTOOL) build -t:Clean -c:Release "Screenmedia.JazzHands.sln"
	$(MDTOOL) build -t:Build -c:Release "Screenmedia.JazzHands.sln"
	mkdir -p ./build/Core
	mv ./src/Screenmedia.JazzHands.Core/bin/Release/* ./build/Core
	mkdir -p ./build/Droid
	mv ./src/Screenmedia.JazzHands.Droid/bin/Release/* ./build/Droid
	mkdir -p ./build/Touch
	mv ./src/Screenmedia.JazzHands.Touch/bin/Release/* ./build/Touch

clean:
	$(MDTOOL) build -t:Clean Screenmedia.JazzHands.sln
	rm *.dll
	rm -rf build