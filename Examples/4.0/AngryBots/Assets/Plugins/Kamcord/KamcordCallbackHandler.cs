// -------------------------------------------------------------------------------
// Implement any callbacks you want from Kamcord here. You can simply fill
// out the method bodies or delegate each method call to a different script/class.
// -------------------------------------------------------------------------------

using UnityEngine;

public class KamcordCallbackHandler : MonoBehaviour, KamcordCallbackInterface
{
	// The Kamcord share view was dismissed
	public void KamcordViewDidDisappear()
	{
		// Implement as you'd like
	}
	
	// The video replay view appeared
	public void MoviePlayerDidAppear()
	{
		// Implement as you'd like
	}
	
	// The video replay view disappeared
	public void MoviePlayerDidDisappear()
	{
		// Implement as you'd like
	}
	
	// The video thumbnail for the latest video is ready
	// at the given absolute file path
	public void VideoThumbnailReadyAtFilePath(string filepath)
	{
		// Implement as you'd like
	}
}
