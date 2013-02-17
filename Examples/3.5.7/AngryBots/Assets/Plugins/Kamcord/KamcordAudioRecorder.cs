#if UNITY_IPHONE

using UnityEngine;

public class KamcordAudioRecorder : MonoBehaviour
{
	void OnAudioFilterRead(float [] data, int numChannels)
	{
		if (Kamcord.IsRecording())
		{
			Kamcord.WriteAudioData(data, data.Length, numChannels);
		}
	}
}

#endif
