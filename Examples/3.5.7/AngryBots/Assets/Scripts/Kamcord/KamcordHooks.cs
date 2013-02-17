#if UNITY_IPHONE

using UnityEngine;
using System.Collections;

public class KamcordHooks : MonoBehaviour
{
	void StartRecording()
	{
		bool result = Kamcord.StartRecording();
		Debug.Log ("Kamcord.StartRecording: " + result);
	}
	
	void StopRecordingAndShowView()
	{
		Kamcord.StopRecording();
		Kamcord.ShowView();
	}
}

#endif
