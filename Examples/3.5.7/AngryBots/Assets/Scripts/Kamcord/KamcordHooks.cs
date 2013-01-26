using UnityEngine;
using System.Collections;

public class KamcordHooks : MonoBehaviour
{
	void StartRecording()
	{
		Kamcord.StartRecording();
	}
	
	void StopRecordingAndShowView()
	{
		Kamcord.StopRecording();
		Kamcord.ShowView();
	}
}
