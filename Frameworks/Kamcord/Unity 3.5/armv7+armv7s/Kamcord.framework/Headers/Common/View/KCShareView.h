//
//  KCShareView.h
//  cocos2d-ios
//
//  Created by Chris Grimm on 6/26/12.
//  Copyright (c) 2012 Kamcord. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "KCViewController.h"

@class KCVideo;

@interface KCShareView : KCViewController

- (id)initWithVideo:(KCVideo *)video;
- (void)dealloc;

@end
