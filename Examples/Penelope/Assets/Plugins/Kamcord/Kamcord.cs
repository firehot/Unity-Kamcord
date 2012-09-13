using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class Kamcord
{
	//////////////////////////////////////////////////////////////////
	/// Method declarations
	//////////////////////////////////////////////////////////////////
	
	/* Interface to native implementation */
	
	[DllImport ("__Internal")]
	private static extern void _KamcordInit(string devKey,
											string devSecret,
											string appName,
											string deviceOrientation, 
											string videoResolution);
	
	//////////////////////////////////////////////////////////////////
    /// Share settings
    ///
	[DllImport ("__Internal")]
	private static extern void _KamcordSetFacebookSettings(string title,
                                                           string caption,
                                                           string description);
	
	[DllImport ("__Internal")]
    private static extern void _KamcordSetYouTubeSettings(string title,
                                                          string description,
                                                          string tags);
    
    [DllImport ("__Internal")]
    private static extern void _KamcordSetDefaultFacebookMessage(string message);
	
	[DllImport ("__Internal")]
    private static extern void _KamcordSetDefaultTweet(string tweet);
		
	[DllImport ("__Internal")]
    private static extern void _KamcordSetDefaultYouTubeMessage(string message);
    
	[DllImport ("__Internal")]
    private static extern void _KamcordSetDefaultEmailSubjectAndBody(string subject,
                                                                     string body);
    
	[DllImport ("__Internal")]
    private static extern void _KamcordSetLevelAndScore(string level,
                                                        double score);
	
	//////////////////////////////////////////////////////////////////
    /// Video recording 
    ///
	[DllImport ("__Internal")]
	private static extern bool _KamcordStartRecording();
	
	[DllImport ("__Internal")]
	private static extern bool _KamcordStopRecording();
	
	[DllImport ("__Internal")]
	private static extern bool _KamcordPause();
	
	[DllImport ("__Internal")]
	private static extern bool _KamcordResume();
	
	[DllImport ("__Internal")]
	private static extern bool _KamcordIsRecording();
	
	
	//////////////////////////////////////////////////////////////////
    /// UI 
    ///
    [DllImport ("__Internal")]
    private static extern void _KamcordShowView();
    
	[DllImport ("__Internal")]
    private static extern void _KamcordSetEnableSynchronousConversionUI(bool enable);
    
	[DllImport ("__Internal")]
    private static extern bool _KamcordEnableSynchronousConversionUI();
    
	[DllImport ("__Internal")]
    private static extern void _KamcordSetShowVideoControlsOnReplay(bool showControls);
    
	[DllImport ("__Internal")]
    private static extern bool _KamcordShowVideoControlsOnReplay();
	
	
	//////////////////////////////////////////////////////////////////
    /// Audio
    ///
    
	[DllImport ("__Internal")]
	private static extern void _KamcordSetAudioSettings(int sampleRate, int bufferSize);
	
	[DllImport ("__Internal")]
	private static extern void _KamcordWriteAudioData(float [] data,
													  int nsamples,
													  int numChannels);
    
	
    //////////////////////////////////////////////////////////////////
    /// Sundry Methods
    ///
    [DllImport ("__Internal")]
    private static extern bool _KamcordCancelConversionForLatestVideo();
    
	[DllImport ("__Internal")]
    private static extern void _KamcordSetMaximumVideoLength(uint seconds);
    
	[DllImport ("__Internal")]
    private static extern uint _KamcordMaximumVideoLength();
    
    
    //////////////////////////////////////////////////////////////////
    /// Custom Sharing UI
    /// 
    
	// TODO:
	// [DllImport ("__Internal")]
	// void _KamcordPresentVideoPlayerInViewController(UIViewController * parentViewController);
    
    // TODO: setMoviePlayerDelegate
    //       moviePlayerDelegate
    //       setShareDelegate
    //       shareDelegate
        
	[DllImport ("__Internal")]
    private static extern void _KamcordShowFacebookLoginView();
    
	[DllImport ("__Internal")]
    private static extern void _KamcordShowTwitterAuthentication();
	
	// TODO:
	// [DllImport ("__Internal")]
    // void _KamcordShowYouTubeLoginViewInViewController(UIViewController * parentViewController);
    
    [DllImport ("__Internal")]
    private static extern bool _KamcordFacebookIsAuthenticated();
    
	[DllImport ("__Internal")]
    private static extern bool _KamcordTwitterIsAuthenticated();
    
	[DllImport ("__Internal")]
    private static extern bool _KamcordYouTubeIsAuthenticated();
    
    [DllImport ("__Internal")]
	private static extern void _KamcordPerformFacebookLogout();
    
	[DllImport ("__Internal")]
    private static extern void _KamcordPerformYouTubeLogout();
    
    [DllImport ("__Internal")]
    private static extern bool _KamcordShareVideoWithMessage(string message,
                                                             bool shareOnFacebook,
                                                             bool shareOnTwitter,
                                                             bool shareOnYouTube);
    
    // TODO:
	// [DllImport ("__Internal")]
    // void _KamcordPresentComposeEmailViewInViewController(UIViewController * parentViewController,
    //                                                      string bodyText)
    
		
	
	
	
	//////////////////////////////////////////////////////////////////
    /// Implementations
    //////////////////////////////////////////////////////////////////
	
	/* Public interface for use inside C# / JS code */
	
	// Starts lookup for some bonjour registered service inside specified domain
	public static void Init(string devKey,
						    string devSecret,
						    string appName,
						    string deviceOrientation, // "LandscapeLeft", "LandscapeRight", "Portrait", "PortraitUpsideDown"
						    string videoResolution)	  // "SMART", "TRAILER"
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.Init");
			_KamcordInit(devKey, devSecret, appName, deviceOrientation, videoResolution);
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.Init");
		}
	}
	
	
	//////////////////////////////////////////////////////////////////
    /// Share settings
    ///
	
	public static void SetFacebookSettings(string title,
                                           string caption,
                                           string description)
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.SetFacebookSettings");
			_KamcordSetFacebookSettings(title, caption, description);
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.SetFacebookSettings");
		}
	}

    public static void SetYouTubeSettings(string title,
                                          string description,
                                          string tags)
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.SetYouTubeSettings");
			_KamcordSetYouTubeSettings(title, description, tags);
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.SetYouTubeSettings");
		}
	}
    
    public static void SetDefaultFacebookMessage(string message)
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.SetDefaultFacebookMessage");
			_KamcordSetDefaultFacebookMessage(message);
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.SetDefaultFacebookMessage");
		}
	}
	
    public static void SetDefaultTweet(string tweet)
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.SetDefaultTweet");
			_KamcordSetDefaultTweet(tweet);
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.SetDefaultTweet");
		}
	}
		
    public static void SetDefaultYouTubeMessage(string message)
    {
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.SetDefaultYouTubeMessage");
			_KamcordSetDefaultYouTubeMessage(message);
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.SetDefaultYouTubeMessage");
		}
	}
		
    public static void SetDefaultEmailSubjectAndBody(string subject,
                                                             string body)
    {
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.SetDefaultEmailSubjectAndBody");
			_KamcordSetDefaultEmailSubjectAndBody(subject, body);
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.SetDefaultEmailSubjectAndBody");
		}
	}
		
    public static void SetLevelAndScore(string level,
                                                double score)
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.SetLevelAndScore");
			_KamcordSetLevelAndScore(level, score);
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.SetLevelAndScore");
		}
	}
	
	//////////////////////////////////////////////////////////////////
    /// Video Recording
    ///
	
	// Start recording
	public static bool StartRecording()
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.StartRecording");
			return _KamcordStartRecording();
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.StartRecording");
			return false;
		}
	}
	
	// Stop recording
	public static bool StopRecording()
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.StopRecording");
			return _KamcordStopRecording();
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.StopRecording");
			return false;
		}
	}
	
	// Pause recording
	public static bool Pause()
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.Pause");
			return _KamcordPause();
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.Pause");
			return false;
		}
	}
	
	// Resume recording
	public static bool Resume()
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.Resume");
			return _KamcordResume();
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.Resume");
			return false;
		}
	}
	
	// Are we currently recording?
	public static bool IsRecording()
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			// Debug.Log ("Kamcord.IsRecording");
			return _KamcordIsRecording();
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.IsRecording");
			return false;
		}
	}
	
	public static void SetAudioSettings(int sampleRate, int bufferSize)
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.SetAudioSettings");
			_KamcordSetAudioSettings(sampleRate, bufferSize);
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.SetAudioSettings");
		}
	}
	
	// Write audio to the current video
	public static void WriteAudioData(float [] data,
									  int nsamples,
									  int numChannels)
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.WriteAudioData");
			_KamcordWriteAudioData(data, nsamples, numChannels);
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.WriteAudioData");
		}
	}
	
	
	//////////////////////////////////////////////////////////////////
    /// UI 
    ///	
	
	// Show Kamcord view
	public static void ShowView()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.ShowView");
			_KamcordShowView();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.ShowView");
		}
	}
	
	public static void SetEnableSynchronousConversionUI(bool enable)
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.SetEnableSynchronousConversionUI");
			_KamcordSetEnableSynchronousConversionUI(enable);
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.SetEnableSynchronousConversionUI");
		}
	}
    
    public static bool EnableSynchronousConversionUI()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.EnableSynchronousConversionUI");
			return _KamcordEnableSynchronousConversionUI();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.EnableSynchronousConversionUI");
			return false;
		}
	}
    
    public static void SetShowVideoControlsOnReplay(bool showControls)
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.ShowView");
			_KamcordShowView();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.ShowView");
		}
	}
    
    public static bool ShowVideoControlsOnReplay()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.ShowView");
			return _KamcordShowVideoControlsOnReplay();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.ShowView");
			return false;
		}
	}
	
	
	
	//////////////////////////////////////////////////////////////////
    /// Sundry Methods
    ///
    public static bool CancelConversionForLatestVideo()
    {
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.CancelConversionForLatestVideo");
			return _KamcordCancelConversionForLatestVideo();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.CancelConversionForLatestVideo");
			return false;
		}
	}
		
    public static void SetMaximumVideoLength(uint seconds)
    {
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.SetMaximumVideoLength");
			_KamcordSetMaximumVideoLength(seconds);
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.SetMaximumVideoLength");
		}
	}
	
    public static uint MaximumVideoLength()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.MaximumVideoLength");
			return _KamcordMaximumVideoLength();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.MaximumVideoLength");
			return 0;
		}
	}
	
	
	
	//////////////////////////////////////////////////////////////////
    /// Custom Sharing UI
    /// 
    
	// TODO:
	// void PresentVideoPlayerInViewController(UIViewController * parentViewController);
    
    // TODO: setMoviePlayerDelegate
    //       moviePlayerDelegate
    //       setShareDelegate
    //       shareDelegate

    public static void ShowFacebookLoginView()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.ShowFacebookLoginView");
			_KamcordShowFacebookLoginView();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.ShowFacebookLoginView");
		}
	}
    
    public static void ShowTwitterAuthentication()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.ShowTwitterAuthentication");
			_KamcordShowTwitterAuthentication();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.ShowTwitterAuthentication");
		}
	}
	
	// TODO:
    // public static void ShowYouTubeLoginViewInViewController(UIViewController * parentViewController);
    
    public static bool FacebookIsAuthenticated()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.FacebookIsAuthenticated");
			return _KamcordFacebookIsAuthenticated();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.FacebookIsAuthenticated");
			return false;
		}
	}
    
    public static bool TwitterIsAuthenticated()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.TwitterIsAuthenticated");
			return _KamcordTwitterIsAuthenticated();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.TwitterIsAuthenticated");
			return false;
		}
	}
    
    public static bool YouTubeIsAuthenticated()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.YouTubeIsAuthenticated");
			return _KamcordYouTubeIsAuthenticated();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.YouTubeIsAuthenticated");
			return false;
		}
	}
    
	public static void PerformFacebookLogout()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.PerformFacebookLogout");
			_KamcordPerformFacebookLogout();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.PerformFacebookLogout");
		}
	}
    
    public static void PerformYouTubeLogout()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.PerformYouTubeLogout");
			_KamcordPerformYouTubeLogout();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.PerformYouTubeLogout");
		}
	}
    
    public static bool ShareVideoWithMessage(string message,
                                             bool shareOnFacebook,
                                             bool shareOnTwitter,
                                             bool shareOnYouTube)
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			Debug.Log ("Kamcord.ShareVideoWithMessage");
			return _KamcordShareVideoWithMessage(message, shareOnFacebook, shareOnTwitter, shareOnYouTube);
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.ShareVideoWithMessage");
			return false;
		}
	}
}
