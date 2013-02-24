#if UNITY_IPHONE

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
		Kamcord.SubscribeToCallbacks(true);
		
		// Get the buffer size and num buffers
		int bufferSize;
		int numBuffers;
		AudioSettings.GetDSPBufferSize(out bufferSize, out numBuffers);
		
		// Get the number of channels
		int numChannels = Kamcord.GetNumChannelsFromSpeakerMode(AudioSettings.speakerMode);
		
		// Tell Kamcord
		Kamcord.SetAudioSettings(AudioSettings.outputSampleRate, bufferSize, numChannels);
	}
	
	/*
	void OnLevelWasLoaded(int level)
	{
		Debug.Log ("Loaded level " + level);

		// Attach AudioListener to all objects in the scene
		AudioListener[] listeners = FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
		Debug.Log("Found " + listeners.Length + " audio listeners.");
		foreach (AudioListener listener in listeners)
		{
			Debug.Log("Found: " + listener.gameObject);
			listener.gameObject.AddComponent("KamcordAudioRecorder");
		}
	}
	*/

	void OnApplicationPause(bool pause)
	{
		if (pause)
			Kamcord.Pause();
		else
			Kamcord.Resume();
	}
}

#endif

