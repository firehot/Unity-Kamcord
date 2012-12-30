// -------------------------------------------------------------------------------
// Implement any callbacks you want from Kamcord here. You can simply fill
// out the method bodies or delegate each method call to a different script/class.
// -------------------------------------------------------------------------------

using UnityEngine;
using System.Collections.Generic;

public class KamcordCallbackHandler : MonoBehaviour
{
	// Methods to take care of subscribing and unsubscribing to callbacks
	private static List<KamcordCallbackInterface> listeners = new List<KamcordCallbackInterface>();
	
	
	// Call this static method to have your object receive all of the
	// KamcordCallbackInterface callbacks.
	public static void AddListener(KamcordCallbackInterface listener)
	{
		if (!listeners.Contains(listener))
		{
			listeners.Add(listener);
		}
	}
	
	public static void RemoveListener(KamcordCallbackInterface listener)
	{
		listeners.Remove(listener);
	}
	
	
	// The Kamcord share view appeared
	private void KamcordViewDidAppear(string empty)
	{
		Debug.Log("KamcordViewDidAppear");
		foreach (KamcordCallbackInterface listener in listeners)
		{
			listener.KamcordViewDidAppear();
		}
	}
	
	// The Kamcord share view disappeared
	private void KamcordViewDidDisappear(string empty)
	{
		Debug.Log ("KamcordViewDidDisappear");
		foreach (KamcordCallbackInterface listener in listeners)
		{
			listener.MoviePlayerDidAppear();
		}
	}
	
	// The video replay view appeared
	private void MoviePlayerDidAppear(string empty)
	{
		Debug.Log ("MoviePlayerDidAppear");
		foreach (KamcordCallbackInterface listener in listeners)
		{
			listener.MoviePlayerDidDisappear();
		}
	}
	
	// The video replay view disappeared
	private void MoviePlayerDidDisappear(string empty)
	{
		Debug.Log ("MoviePlayerDidDisappear");
		foreach (KamcordCallbackInterface listener in listeners)
		{
			listener.MoviePlayerDidDisappear();
		}
	}
	
	// The share button was pressed
	private void ShareButtonPressed(string empty)
	{
		Debug.Log("ShareButtonPressed");
		foreach (KamcordCallbackInterface listener in listeners)
		{
			listener.ShareButtonPressed();
		}
	}
	
	// The thumbnail for the latest video is ready at this
	// absolute file path
	private void VideoThumbnailReadyAtFilePath(string filepath)
	{
		Debug.Log ("VideoThumbnailReadyAtFilePath: " + filepath);
		foreach (KamcordCallbackInterface listener in listeners)
		{
			listener.VideoThumbnailReadyAtFilePath(filepath);
		}
	}
	
	// When the video begins and finishes uploading
	private void VideoWillUploadToURL(string url)
	{
		Debug.Log ("VideoWillBeginUploading: " + url);
		foreach (KamcordCallbackInterface listener in listeners)
		{
			listener.VideoWillBeginUploading(url);
		}
	}
	
	private void VideoUploadedWithSuccess(string success)
	{
		Debug.Log ("VideoFinishedUploading: " + success);
		bool truthValue = (success == "true" ? true : false);
		foreach (KamcordCallbackInterface listener in listeners)
		{
			listener.VideoFinishedUploading(truthValue);
		}
	}
}
