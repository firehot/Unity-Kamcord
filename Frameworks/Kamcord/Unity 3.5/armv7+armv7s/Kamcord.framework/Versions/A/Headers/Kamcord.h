//
//  Kamcord.h
//  cocos2d-ios
//
//  Created by Kevin Wang on 5/5/12.
//  Copyright (c) 2012 Kamcord. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

#import "KamcordMacros.h"
#import "Common/Core/KamcordProtocols.h"
#import "Common/Core/KCAnalytics.h"

FOUNDATION_EXPORT NSString * const KamcordVersion;


@interface Kamcord : NSObject

////////////////////////////////////////////////
// Public methods

// Returns YES if and only if Kamcord is supported by 
// this device's version of iOS.
// Note: You do NOT need to wrap your Kamcord calls
//       with this function. Kamcord will turn itself
//       off if this is NO.
+ (BOOL)isEnabled;

// Setup
+ (void) setDeveloperKey:(NSString *)key
         developerSecret:(NSString *)secret
                 appName:(NSString *)appName;
+ (NSString *)developerKey;
+ (NSString *)developerSecret;
+ (NSString *)appName;

// View and OpenGL
+ (void)setParentViewController:(UIViewController *)viewController;
+ (UIViewController *)parentViewController;

+ (void)setDeviceOrientation:(KCDeviceOrientation)orientation;
+ (KCDeviceOrientation) deviceOrientation;

// For Portrait, do you want to support PortraitUpsideDown also?
+ (void)setSupportPortraitAndPortraitUpsideDown:(BOOL)value;
+ (BOOL)supportPortraitAndPortraitUpsideDown;

+ (void)setUseUIKitAutorotation:(BOOL)yes;
+ (BOOL)useUIKitAutorotation;

+ (void)setScreenWidth:(float)width
                height:(float)height;

// Social media
// The default text to show in the share box regardless of network shared to.
+ (void)setDefaultTitle:(NSString *)title;
+ (NSString *)defaultTitle;

// YouTube
+ (void)setYouTubeDescription:(NSString *)description
                         tags:(NSString *)tags;
+ (void)setYouTubeVideoCategory:(NSString *)category;
+ (NSString *)youtubeDescription;
+ (NSString *)youtubeTags;
+ (NSString *)youtubeCategory;

// Facebook
+ (void) setFacebookTitle:(NSString *)title
                  caption:(NSString *)caption
              description:(NSString *)description;
+ (NSString *)facebookTitle;
+ (NSString *)facebookCaption;
+ (NSString *)facebookDescription;

// Email
+ (void)setDefaultEmailBody:(NSString *)body;
+ (NSString *)defaultEmailBody;


// Deprecated social media default messages.
// Only work for Kamcord.ShowViewDeprecated().
+ (void) setDefaultFacebookMessage:(NSString *)message;
+ (NSString *)defaultFacebookMessage;

+ (void)setDefaultTweet:(NSString *)tweet;
+ (NSString *)defaultTweet;

+ (void) setDefaultYouTubeMessage:(NSString *)message;
+ (NSString *)defaultYouTubeMessage;

// Email
+ (void)setDefaultEmailSubject:(NSString *)subject
                          body:(NSString *)body;
+ (NSString *)defaultEmailSubject;


////////////////////
// Video recording
//

// Not necessary to call. However, if you want to avoid
// the slight FPS drop when calling startRecording,
// call this method earlier when there's very little
// processing and a slight drop in FPS won't be noticed.
// Only need to call this ONCE on app startup to prime
// the first video.
+ (BOOL)prepareNextVideo;   // Same as calling [Kamcord prepareNextVideo:NO];
+ (BOOL)prepareNextVideo:(BOOL)async;

+ (BOOL)startRecording;
+ (BOOL)stopRecording;
+ (BOOL)stopRecordingAndDiscardVideo;
+ (BOOL)pause;
+ (BOOL)resume;

// Are we currently recording?
+ (BOOL)isRecording;

// Used to keep track of settings per video
+ (void)setLevel:(NSString *)level
           score:(NSNumber *)score;

+ (NSString *)level;
+ (NSNumber *)score;


////////////////////
// Kamcord UI
//

// Displays the Kamcord view inside the previously set parentViewController;
+ (void)showView;
+ (void)showViewInViewController:(UIViewController *)parentViewController;

// Displays the old Kamcord View, deprecated since 0.9.96
+ (void)showViewDeprecated;

+ (BOOL)enableSynchronousConversionUI;


// Show the video player controls when the replay is shown?
// By default YES, since user studies have shown that users
// don't understand what they're seeing is an actual video
// as opposed to the round restarting again.
+ (void)setShowVideoControlsOnReplay:(BOOL)showControls;
+ (BOOL)showVideoControlsOnReplay;
+ (BOOL)alwaysShowProgressBar;  // Returns NO for now


// Video recording settings
// For release, use SMART_VIDEO_DIMENSIONS:
//   iPad 1 and 2: 512x384
//   iPad 3: 1024x768
//   All iPhone and iPods: 480x320
//
// For trailers, use TRAILER_VIDEO_RESOLUTION
//   All iPads: 1024x768
//   iPhone/iPod non-retina: 480x320
//   iPhone/iPad retina: 960x640
typedef enum {
    SMART_VIDEO_RESOLUTION,
    TRAILER_VIDEO_RESOLUTION,
} KC_VIDEO_RESOLUTION;

+ (void)setVideoResolution:(KC_VIDEO_RESOLUTION)resolution;
+ (KC_VIDEO_RESOLUTION)videoResolution;

+ (void)setVideoBitrateFraction:(NSString *)fraction;
+ (NSUInteger)videoBitrateNumerator;
+ (NSUInteger)videoBitrateDenominator;

// Audio recording

// Will stop all looping, non-looping, or looping and non-looping sounds.
typedef enum
{
    NONLOOPING_SOUNDS,
    LOOPING_SOUNDS,
    ALL_SOUNDS
} KC_SOUND_TYPE;

+ (void)setAudioSettings:(int)sampleRate
              bufferSize:(int)bufferSize
             numChannels:(int)numChannels;
+ (int)audioSampleRate;
+ (int)audioBufferSize;
+ (int)numAudioChannels;
+ (void)writeAudioData:(float [])data
                length:(size_t)nsamples
           numChannels:(int)numChannels;

// Every time you call startRecording, Kamcord will delete
// the previous video if it is not currently being shared.
// 
// In addition, on app startup, Kamcord will erase all
// unused videos.
//
// If you want to manually erase videos (which is not recommended),
// you can call this method. If the video is currently being shared, it
// it will be erased after the next share is complete.
//
// Please be careful with this call. If there are no pending shares,
// the video WILL be erased. If, for instance, you call
// [Kamcord presentVideoPlayerInViewController:] and
// then [Kamcord cancelConversionForLatestVideo] while the video is
// being shown, you may get EXC_BAD_ACCESS. 
//
// Returns YES if conversion for the latest video was cancelled.
// Returns NO if the latest video has already been shared and we need to wait for the conversion.
+ (BOOL)cancelConversionForLatestVideo;

// Optional: Set the maximum video time in seconds. If the recorded video goes over that time,
//           then only the last N seconds are taken.
//           To not have a maximum video time, set this value to 0 (the default).
+ (void)setMaximumVideoLength:(NSUInteger)seconds;
+ (NSUInteger)maximumVideoLength;


// --------------------------------------------------------
// Custom sharing API

// Used for both Option 1 and Option 2

// Replay the latest video in the parent view controller.
// The "latest video" is defined as the last one for which
// you called [Kamcord stopRecording].
+ (void)presentVideoPlayerInViewController:(UIViewController *)parentViewController;

// The object that will receive all non-share related callbacks.
+ (void)setDelegate:(id <KamcordDelegate>)delegate;
+ (id <KamcordDelegate>)delegate;


// The object that will receive callbacks about sharing state.
// You must make sure that this object is retained until
// all the callbacks are done. This delegate is retained
// until all the callbacks are complete, after which it
// is released by Kamcord.
+ (void)setShareDelegate:(id <KCShareDelegate>)delegate;
+ (id <KCShareDelegate>)shareDelegate;


// Option 1: Use the following API for sharing if you want
//           your own custom UI but would like Kamcord to handle
//           all of the Facebook/Twitter/YouTube authentication for you.

// Authenticate to the three social media services
+ (void)showFacebookLoginView;
+ (void)showTwitterAuthentication; 
+ (void)showYouTubeLoginViewInViewController:(UIViewController *)parentViewController;

// Status of authentication
+ (BOOL)facebookIsAuthenticated;
+ (BOOL)twitterIsAuthenticated;
+ (BOOL)youTubeIsAuthenticated;

+ (void)performFacebookLogout;
+ (void)performYouTubeLogout;

// The method to share a message on these services.
// You can also use this if you want to mix different
// authentications. For instance, you can handle
// Facebook and Twitter auth and let Kamcord upload
// to YouTube with its own auth (which it got via
// presentYouTubeLoginViewInViewController: above.
// Simply call this with shareFacebook and shareTwitter set to NO
// and shareYouTube set to YES.
//
// Once the video uploads are done, we will call back
// to videoIsReadyToShare.
//
// Returns YES if the share was accepted for processing.
// Returns NO if there was a previous share that is still
// in its early stages (specifically, before a generalError:
// or shareStartedWithSuccess:error: callback).
+ (BOOL)shareVideoOnFacebook:(BOOL)shareFacebook
                     Twitter:(BOOL)shareTwitter
                     YouTube:(BOOL)shareYouTube
                       Email:(BOOL)shareEmail
                 withMessage:(NSString *)message
mailViewParentViewController:(UIViewController *)parentViewController;

// Show the send email dialog with the Kamcord URL in the message.
// Any additional body text you'd like to add should be passed in the
// second argument.
+ (void)presentComposeEmailViewInViewController:(UIViewController *)parentViewController
                                       withBody:(NSString *)bodyText;


// Option 2: Use the following API for sharing if you want to use
//           your own custom UI and will also perform all of the 
//           Facebook/Twitter/YouTube authentication yourself.
//           Simply call this one function that will upload the video
//           to Kamcord (and optionally YouTube). Once the video is successfully
//           uploaded, you'll get a callback to 
//
//           - (void)videoIsReadyToShare:(NSURL *)onlineVideoURL
//                             thumbnail:(NSURL *)onlineThumbnailURL
//                               message:(NSString *)message
//                                  data:(NSDictionary *)data
//                                 error:(NSError *)error;
//
//           (defined above in KCShareDelegate).
//           If you don't want to upload to YouTube, simply pass
//           in nil for the youTubeAuth object.
//
//           The data object you pass in will be passed back to you
//           in videoIsReadyToShare.
//
//           Returns YES if the share was accepted for processing.
//           Returns NO if there was a previous share that is still
//           in its early stages (specifically, before a generalError:
//           or shareStartedWithSuccess:error: callback).
+ (BOOL)shareVideoWithMessage:(NSString *)message
              withYouTubeAuth:(GTMOAuth2Authentication *)youTubeAuth
                         data:(NSDictionary *)data;




// --------------------------------------------------------
// For Kamcord internal use, don't worry about these.

// Returns the singleton Kamcord object. You don't ever really need this, just
// use the static API calls. 
+ (Kamcord *)sharedManager;

// Helper to calculate the internal scale factor
+ (unsigned int)resolutionScaleFactor;

+ (BOOL)isIPhone5;
+ (BOOL)checkInternet;

+ (void)track:(NSString *)eventName
   properties:(NSDictionary *)properties
analyticsType:(KC_ANALYTICS_TYPE)analyticsType;

+ (NSString *)kamcordSDKVersion;


@end
