//
//  KamcordMacros.h
//  cocos2d-ios
//
//  Created by Kevin Wang on 5/21/12.
//  Copyright (c) 2012 Kamcord Inc. All rights reserved.
//

#ifndef KamcordMacros_h
#define KamcordMacros_h

// Tell Kamcord which version we're using
#define KCUNITY 1
#define PRE_IOS_6 1

// Logging
#ifdef KCDEBUG

#define NLog(fmt, ...) printf("%s\n", [[NSString stringWithFormat:@"%s:%d %@", __PRETTY_FUNCTION__, __LINE__, [NSString stringWithFormat:fmt, ##__VA_ARGS__]] UTF8String])

#else

#define NLog(...)

#endif



////////////////////////////////////////////////
// Macros that make it easier to port Kamcord
// to different engines.

// Orientation
#define KCDeviceOrientation UIInterfaceOrientation

#define KCDeviceOrientationPortrait UIInterfaceOrientationPortrait 
#define KCDeviceOrientationPortraitUpsideDown UIInterfaceOrientationPortraitUpsideDown
#define KCDeviceOrientationLandscapeLeft UIInterfaceOrientationLandscapeLeft
#define KCDeviceOrientationLandscapeRight UIInterfaceOrientationLandscapeRight

#endif

