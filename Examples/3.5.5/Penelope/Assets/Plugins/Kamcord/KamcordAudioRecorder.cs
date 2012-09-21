using UnityEngine;

public class KamcordAudioRecorder : MonoBehaviour
{
	void Awake ()
	{
		int bufferSize;
		int numBuffers;
		AudioSettings.GetDSPBufferSize(out bufferSize, out numBuffers);
		Kamcord.SetAudioSettings(AudioSettings.outputSampleRate, bufferSize);
	}
	
	void OnAudioFilterRead(float [] data, int numChannels)
	{
		if (Kamcord.IsRecording())
		{
			Kamcord.WriteAudioData(data, data.Length, numChannels);
		}
	}
}
