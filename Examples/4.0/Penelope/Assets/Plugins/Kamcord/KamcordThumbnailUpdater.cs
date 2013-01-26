using UnityEngine;
using System.Collections;

// As of Kamcord 1.0, there is a known bug in this
// class that will cause a System.NullReferenceException crash
// on Kamcord.StopRecording(). Please refrain from using
// this script until this is fixed in 1.0.1.

public class KamcordThumbnailUpdater : MonoBehaviour, KamcordCallbackInterface
{
	// ------------------------------------------------------------------
	// Public member variables
	// ------------------------------------------------------------------
	
	// The play button texture object
	public Texture2D playButtonTexture;
	
	// The X,Y location of the thumbnail, where
	// (0,0) is the bottom left of the screen and
	// (1,1) is the top right of the screen.
	public float thumbnailRelativeX = 0.25f;
	public float thumbnailRelativeY = 0.25f;
	
	// The ratio of the thumbnail to the screen resolution.
	// A ratio of 1.0 will make the thumbnail dimensions
	// the exact same as the full screen dimensions.
	// A ratio of 0.5 will make the thumbnail width and height
	// equal to half of the full screen dimensions.
	// The min ratio is 0.2.
	public float thumbnailToScreenRatio = 0.4f;
	
	// ------------------------------------------------------------------
	// Public methods
	// ------------------------------------------------------------------
	public void EnableThumbnail(bool enable)
	{
		if (this.theGuiTexture != null)
		{
			this.theGuiTexture.enabled = enable;
		}
	}
	
	// ------------------------------------------------------------------
	// Private member variables
	// ------------------------------------------------------------------
	
	// The GUITexture object the
	private GUITexture theGuiTexture;
	
	// How large the play button is relative to the thumbnail
	private float playButtonToThumbnailRatio = 0.5f;
	private Rect playButtonLocationAndSize;	
	
	void Start ()
	{
		GUITexture[] guiTextures = gameObject.GetComponents<GUITexture>();
		Debug.Log ("Found " + guiTextures.Length + " GUITexture comopnent(s) on this game object.");
		if (guiTextures.Length == 0)
		{
			throw new System.Exception("Kamcord script " + this.name + " needs to have at least one GUITexture component on the attached game object named: " + this.gameObject.name);
		}
		
		this.theGuiTexture = guiTextures[0];
		Debug.Log (this.name + " will use " + this.theGuiTexture.name + " as the thumbnail texture.");
		
		KamcordCallbackHandler.AddListener(this);
		EnableThumbnail(false);
	}
	
	// Detect touch events
	void Update()
	{
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began && this.theGuiTexture.HitTest(touch.position))
			{
				Kamcord.ShowView();
				break;
			}
		}
	}
	
	// Display a play button if the thumbnail is visible
	void OnGUI()
	{
		if (this.theGuiTexture.enabled)
		{
			GUI.Label(playButtonLocationAndSize, playButtonTexture);
		}
	}
	
	
	// ------------------------------------------------------------------
	// KamcordCallbackInterface implementations
	
	// The Kamcord share view appeared
	public void KamcordViewDidAppear()
	{
		// Intentionally left blank
	}
	
	// The Kamcord share view disappeared
	public void KamcordViewDidDisappear()
	{
		// Intentionally left blank
	}
	
	// The video replay view appeared and disappeared
	public void MoviePlayerDidAppear()
	{
		// Intentionally left blank
	}
	
	public void MoviePlayerDidDisappear()
	{
		// Intentionally left blank
	}
	
	// The thumbnail for the latest video is ready at
	// this absolute filepath.
	public void VideoThumbnailReadyAtFilePath(string filepath)
	{
		if (System.IO.File.Exists(filepath)) 
		{
			SetThumbnailTextureToFilepath(filepath);
		}
	}
	
	public void ShareButtonPressed()
	{
		// Intentionally left blank
	}
	
	// When the video begins and finishes uploading
	public void VideoWillBeginUploading(string url)
	{
		// Intentionally left blank
	}
	
	public void VideoFinishedUploading(bool success)
	{
		// Intentionally left blank
	}
	
	
	// The async call to load the texture and then set the thumbnail
	// to the loaded texture.
	private IEnumerator WaitForLoadToFinishAndThenSetThumbnail(WWW loader)
	{
	    yield return loader;
	
	    if (loader.error == null)
		{
			// Min ratio is 0.25f
			if (this.thumbnailToScreenRatio < 0.2f)
			{
				this.thumbnailToScreenRatio = 0.2f;
			}
			
			// First set the thumbnail location and size
			float absoluteX = this.thumbnailRelativeX * Screen.width;
			float absoluteY = this.thumbnailRelativeY * Screen.height;
			float absoluteWidth  = this.thumbnailToScreenRatio * Screen.width;
			float absoluteHeight = this.thumbnailToScreenRatio * Screen.height;
			
			// Then center the play button on the thumbnail
			float playButtonWidth  = Mathf.Min(playButtonTexture.width, this.playButtonToThumbnailRatio * absoluteWidth);
			float playButtonHeight = playButtonWidth;
			float playButtonAbsoluteX = absoluteX + 0.5f * (absoluteWidth  - playButtonWidth);
			// GUI.Label screen coords origin is top left, unlike thumbnail texture :(
			float playButtonAbsoluteY = (Screen.height - absoluteY) - 0.5f * (absoluteHeight + playButtonHeight);
			
			// Save it for later use in OnGUI
			playButtonLocationAndSize = new Rect(playButtonAbsoluteX, playButtonAbsoluteY, playButtonWidth, playButtonHeight);
			
			Debug.Log ("Screen width and height: (" + Screen.width + ", " + Screen.height + ")");
			Debug.Log ("Texture location and size: (" + absoluteX + ", " + absoluteY + ", " + absoluteWidth + ", " + absoluteHeight + ")");
			
			transform.position = Vector3.zero;
			transform.localScale = Vector3.zero;
			this.theGuiTexture.pixelInset = new Rect(absoluteX, absoluteY, absoluteWidth, absoluteHeight);
	        this.theGuiTexture.texture = loader.texture;
			EnableThumbnail(true);
	    }    
	}
	
	// Method to actually load and set the thumbnail from the file URL
	private void SetThumbnailTextureToFilepath(string filepath)
	{
		WWW loader = new WWW("file://" + filepath);
		StartCoroutine(WaitForLoadToFinishAndThenSetThumbnail(loader));
	}
}
