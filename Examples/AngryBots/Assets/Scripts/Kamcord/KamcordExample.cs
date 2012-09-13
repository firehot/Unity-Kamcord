using UnityEngine;
using System.Collections;

public class KamcordExample : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		Debug.Log ("KamcordTest Start() begin");
		Kamcord.SetYouTubeSettings("AngryBots",
								   "What would ya do for a Klondike bar?",
								   "iOS Unity Kamcord angry maniacal robot");
		Kamcord.SetFacebookSettings("AngryBots",
								 	"What u lookin' at Willis?",
									"Tastes like chicken");
		Kamcord.SetEnableSynchronousConversionUI(true);
		Debug.Log ("KamcordTest Start() end");
	}

	void StartRecording()
	{
		Debug.Log ("Starting recording.");
		Kamcord.StartRecording();
	}
	
	void StopRecording()
	{
		Debug.Log ("Stop recording.");
		Kamcord.StopRecording();
		Kamcord.ShowView();
	}
}
