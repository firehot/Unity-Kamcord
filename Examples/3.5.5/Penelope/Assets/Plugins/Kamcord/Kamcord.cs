using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

//////////////////////////////////////////////////////////////////
/// Version: 0.9.98
//////////////////////////////////////////////////////////////////

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
	private static extern void _KamcordSetYouTubeVideoCategory(string category);
    
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
	private static extern bool _KamcordStopRecordingAndDeferProcessing();
	
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
    private static extern void _KamcordShowViewDeprecated();
    
	[DllImport ("__Internal")]
    private static extern void _KamcordSetShowVideoControlsOnReplay(bool showControls);
    
	[DllImport ("__Internal")]
    private static extern bool _KamcordShowVideoControlsOnReplay();
	
	
	//////////////////////////////////////////////////////////////////
    /// Audio
    ///
    
	[DllImport ("__Internal")]
	private static extern void _KamcordSetAudioSettings(int sampleRate, int bufferSize, int numChannels);
	
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
    
	[DllImport ("__Internal")]
	private static extern void _KamcordPresentVideoPlayerFullscreen();
    
    // TODO: setShareDelegate
    //       shareDelegate
        
	[DllImport ("__Internal")]
	private static extern void _KamcordSubscribeToCallbacks(bool subscribe);
	
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
    
		
	
	
	// Possible values of deviceOrientation:
	public enum DeviceOrientation
	{
		Portrait,
		LandscapeLeft,
		LandscapeRight,
		PortraitUpsideDown
	};
	
	// Possible values of videoResolution
	public enum VideoResolution
	{
		Smart,
		Trailer
	};
	
	// Possible values of the YouTube video category
	public enum YouTubeVideoCategory
	{
		Comedy,
		Education,
		Entertainment,
		Games,
		Music
	};
	
	
	//////////////////////////////////////////////////////////////////
    /// Implementations
    //////////////////////////////////////////////////////////////////
	
	/* Public interface for use inside C# / JS code */
	
	// Starts lookup for some bonjour registered service inside specified domain
	public static void Init(string devKey,
						    string devSecret,
						    string appName,
						    DeviceOrientation deviceOrientation,
						    VideoResolution videoResolution)
	{
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.Init");
			_KamcordInit(devKey, devSecret, appName, deviceOrientation.ToString(), videoResolution.ToString());
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.SetYouTubeSettings");
			_KamcordSetYouTubeSettings(title, description, tags);
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.SetYouTubeSettings");
		}
	}
	
	public static void SetYouTubeVideoCategory(YouTubeVideoCategory category)
	{
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.SetYouTubeVideoCategory");
			_KamcordSetYouTubeVideoCategory(category.ToString());
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.SetYouTubeSettings");
		}
	}
    
    public static void SetDefaultFacebookMessage(string message)
	{
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
	
	// Stop recording and discard video
	public static bool StopRecordingAndDeferProcessing()
	{
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.StopRecordingAndDeferProcessing");
			return _KamcordStopRecordingAndDeferProcessing();
		}
		else
		{
			Debug.Log ("[NOT CALLED] Kamcord.StopRecordingAndDeferProcessing");
			return false;
		}
	}
	
	// Pause recording
	public static bool Pause()
	{
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _KamcordIsRecording();
		}
		else
		{
			return false;
		}
	}
	
	public static void SetAudioSettings(int sampleRate, int bufferSize, int numChannels)
	{
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.SetAudioSettings");
			_KamcordSetAudioSettings(sampleRate, bufferSize, numChannels);
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			// Debug.Log ("Kamcord.WriteAudioData");
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.ShowView");
			_KamcordShowView();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.ShowView");
		}
	}
	
	public static void ShowViewDeprecated()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.ShowViewDeprecated");
			_KamcordShowViewDeprecated();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.ShowView");
		}
	}
	
    public static void SetShowVideoControlsOnReplay(bool showControls)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.ShowView");
			_KamcordSetShowVideoControlsOnReplay(showControls);
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.ShowView");
		}
	}
    
    public static bool ShowVideoControlsOnReplay()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.SetMaximumVideoLength");
			_KamcordSetMaximumVideoLength(seconds);
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.SetMaximumVideoLength");
		}
	}
	
    public static uint MaximumVideoLength()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.MaximumVideoLength");
			return _KamcordMaximumVideoLength();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.MaximumVideoLength");
			return 0;
		}
	}
	
	
	//////////////////////////////////////////////////////////////////
    /// Subscribe to callbacks from Kamcord
    /// 
	
	public static void SubscribeToCallbacks(bool subscribe)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.SubscribeToCallbacks");
			_KamcordSubscribeToCallbacks(subscribe);
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.SubscribeToCallbacks");
		}
	}
	
	public static int GetNumChannelsFromSpeakerMode(AudioSpeakerMode speakerMode)
	{
		switch (AudioSettings.speakerMode)
		{
		case AudioSpeakerMode.Mono:
			return 1;
			
		case AudioSpeakerMode.Stereo:
			return 2;
			
		case AudioSpeakerMode.Quad:
			return 4;
			
		case AudioSpeakerMode.Surround:
		case AudioSpeakerMode.Mode5point1:
			return 5;
			
		case AudioSpeakerMode.Mode7point1:
			return 7;
		
		case AudioSpeakerMode.Prologic:
			return 2;
			
		case AudioSpeakerMode.Raw:
		default:
			return 2;
		}
	}
	
	
	//////////////////////////////////////////////////////////////////
    /// Custom Sharing UI
    /// 
    
	/*
	public static void PresentVideoPlayerFullscreen()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.PresentVideoPlayerFullscreen");
			_KamcordPresentVideoPlayerFullscreen();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.PresentVideoPlayerFullscreen");
		}
	}
	*/
    
    // TODO: setShareDelegate
    //       shareDelegate
	
    public static void ShowFacebookLoginView()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.ShowFacebookLoginView");
			_KamcordShowFacebookLoginView();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.ShowFacebookLoginView");
		}
	}
    
    public static void ShowTwitterAuthentication()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.PerformFacebookLogout");
			_KamcordPerformFacebookLogout();
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.PerformFacebookLogout");
		}
	}
    
    public static void PerformYouTubeLogout()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log ("Kamcord.ShareVideoWithMessage");
			return _KamcordShareVideoWithMessage(message, shareOnFacebook, shareOnTwitter, shareOnYouTube);
		} else {
			Debug.Log ("[NOT CALLED] Kamcord.ShareVideoWithMessage");
			return false;
		}
	}
}
