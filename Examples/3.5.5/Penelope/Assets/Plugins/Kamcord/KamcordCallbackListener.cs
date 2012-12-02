// -------------------------------------------------------------------------------
// This class/object is the C# target (i.e. middleman) that the Kamcord
// Objective-C framework will send messages to. This class will then interpret
// those callbacks and pass them on to KamcordCallbackHandler.cs, which
// you should implement to handle any relevant callbacks you care about.
//
// Do NOT modify!
// -------------------------------------------------------------------------------

using UnityEngine;
using System;

public class KamcordCallbackListener : MonoBehaviour
{
	// The static object that we will forward all callbacks to
	private static KamcordCallbackInterface callbackHandler = null; 
	
	// Subscribe or unsubscribe to Kamcord notifications
	public static void SubscribeToKamcordNotifications(bool subscribe)
	{
		if (subscribe)
		{
			if (callbackHandler == null) {
				callbackHandler = (KamcordCallbackInterface)GameObject.Find("KamcordPrefab").GetComponent("KamcordCallbackHandler");
			}	
		} else {
			callbackHandler = null;
		}
	}
	

	// -------------------------------------------------------------------------------
	// The callbacks from the Kamcord Objective-C framework
	// -------------------------------------------------------------------------------
	
	// The Kamcord share view was dismissed
	private void KamcordViewDidDisappear(string empty)
	{
		Debug.Log ("KamcordViewDidDisappear");
		if (callbackHandler != null)
		{
			callbackHandler.KamcordViewDidDisappear();
		}
	}
	
	// The video replay view appeared
	private void MoviePlayerDidAppear(string empty)
	{
		Debug.Log ("MoviePlayerDidAppear");
		if (callbackHandler != null)
		{
			callbackHandler.MoviePlayerDidAppear();
		}
	}
	
	// The video replay view disappeared
	private void MoviePlayerDidDisappear(string empty)
	{
		Debug.Log ("MoviePlayerDidDisappear");
		if (callbackHandler != null)
		{
			callbackHandler.MoviePlayerDidDisappear();
		}
	}
	
	// The thumbnail for the latest video is ready at this
	// absolute file path
	private void VideoThumbnailReadyAtFilePath(string filepath)
	{
		Debug.Log ("VideoThumbnailReadyAtFilePath: " + filepath);
		if (callbackHandler != null)
		{
			callbackHandler.VideoThumbnailReadyAtFilePath(filepath);
		}
	}
	
	// When the video begins and finishes uploading
	private void VideoWillUploadToURL(string url)
	{
		Debug.Log ("VideoWillBeginUploading: " + url);
		if (callbackHandler != null)
		{
			callbackHandler.VideoWillBeginUploading(url);
		}
	}
	
	private void VideoUploadedWithSuccess(string success)
	{
		Debug.Log ("VideoFinishedUploading: " + success);
		if (callbackHandler != null)
		{
			bool truthValue = (success == "true" ? true : false);
			callbackHandler.VideoFinishedUploading(truthValue);
		}
	}
}
