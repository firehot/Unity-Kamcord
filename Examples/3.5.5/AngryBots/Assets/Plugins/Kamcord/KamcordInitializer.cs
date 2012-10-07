// ------------------------------------------------------------------------------
// KamcordInitializer lets you set Kamcord parameters from within the Unity IDE.
//
// To use this prefab, drag it from Prefabs/Kamcord into the scene (Hierarchy tab)
// ------------------------------------------------------------------------------

using UnityEngine;

public class KamcordInitializer : MonoBehaviour 
{	
	// Public properties
	public string developerKey    			   		  = "Kamcord developer key";
	public string developerSecret 			   		  = "Kamcord developer secret";
	public string appName   				   		  = "Application name";
	public Kamcord.DeviceOrientation deviceOrientation = Kamcord.DeviceOrientation.Portrait;
	public Kamcord.VideoResolution videoResolution     = Kamcord.VideoResolution.Smart;
	
	// Public methods
	void Awake()
	{
		DontDestroyOnLoad(this);
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
