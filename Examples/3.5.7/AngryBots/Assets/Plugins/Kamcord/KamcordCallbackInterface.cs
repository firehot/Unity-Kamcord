#if UNITY_IPHONE

// ---------------------------------------------------------------------------
// This is the interface that KamcordCallbackProcessor implements. These
// are all the possible callbacks that the Kamcord Objective-C framework
// will make back into Unity.
// ---------------------------------------------------------------------------

public interface KamcordCallbackInterface
{
	// The Kamcord share view appeared and disappeared
	void KamcordViewDidAppear();
	void KamcordViewDidDisappear();
	
	// The video replay view appeared and disappeared
	void MoviePlayerDidAppear();
	void MoviePlayerDidDisappear();
	
	// The thumbnail for the latest video is ready at
	// this absolute filepath.
	void VideoThumbnailReadyAtFilePath(string filepath);
	
	// The user pressed the share button
	void ShareButtonPressed();
	
	// When the video begins and finishes uploading
	void VideoWillBeginUploading(string url);
	void VideoFinishedUploading(bool success);
}

#endif

