//
// KamcordInitializer lets you set Kamcord parameters from within the Unity IDE.
//
// To use this prefab, drag it from Prefabs/Kamcord onto 
//

using UnityEngine;

public class KamcordInitializer : MonoBehaviour 
{	
	// Possible values of deviceOrientation:
	//  - Portrait
	//  - PotraitUpsideDown
	//  - LandscapeLeft
	//  - LandscapeRight
	
	// Possible values of videoResolution
	//  - Smart    (Should be used for release)
	//  - Trailer  (Should only be used for making a trailer)
	
	// Public properties
	public string developerKey    	= "Kamcord developer key";
	public string developerSecret 	= "Kamcord developer secret";
	public string appName   		= "Application name";
	public string deviceOrientation = "Portrait";
	public string videoResolution   = "Smart";
	
	// Public methods
	void Awake()
	{
		Kamcord.Init(developerKey, developerSecret, appName, deviceOrientation, videoResolution);
	}

	void OnApplicationPause(bool pause)
	{
		if (pause)
			Kamcord.Pause();
		else
			Kamcord.Resume();
	}
}
