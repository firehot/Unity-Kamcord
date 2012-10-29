using UnityEngine;

public class KamcordAudioRecorder : MonoBehaviour
{
	void Awake ()
	{
		// Get the buffer size and num buffers
		int bufferSize;
		int numBuffers;
		AudioSettings.GetDSPBufferSize(out bufferSize, out numBuffers);
		
		// Get the number of channels
		int numChannels = Kamcord.GetNumChannelsFromSpeakerMode(AudioSettings.speakerMode);
		
		// Tell Kamcord
		Kamcord.SetAudioSettings(AudioSettings.outputSampleRate, bufferSize, numChannels);
	}
	
	void OnAudioFilterRead(float [] data, int numChannels)
	{
		if (Kamcord.IsRecording())
		{
			Kamcord.WriteAudioData(data, data.Length, numChannels);
		}
	}
	
	void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			Kamcord.Pause();
		} else {
			Kamcord.Resume();
		}
	}
}
