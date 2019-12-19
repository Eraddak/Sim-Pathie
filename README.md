# Sim-Pathie

Steps to build the Unity project :

	- Create a new project from the Unity Hub (v. 2019.3 prefered)

	- Leave Unity and replace the Assets folder with the one from this project.

	- Restart Unity

	- When you reach the UI scene, Unity will ask you to import Text Mesh Pro. Do so.

	- Add the GoogleVR package (see links below)

	- Add the library LibPD (see links below)

NOTE : LibPD won't compile in 64 bits but works perfectly once built under android 32 bits.

GoogleVR : https://github.com/googlevr/gvr-unity-sdk/releases

LibPD : https://github.com/irllabs/libpd4unity-starter/tree/master/Assets
Get the LibPD folder in Assets

	- Under File > Build Settings :
		
		- switch platform to android

		- Add all the scenes by drag&dropping it

	- Under Edit > Project Settings :

		- Player > Resolution and Presentation > Orientation

		set Default Orientation to Portrait

		- Player > Other Settings
		
		set Android minimum version to KitKat 4.4 (API level 19)

		- Player > XR Settings

		check Virtual Reality Supported
		add None
		add Cardboard

If you don't plan to do shaders or post processing (for daltonism for example), for faster build, you can also :

		- Graphics > Built-in Shader Settings

		Switch everything to "No Support"
		Always Included Shaders :
			Size = 0