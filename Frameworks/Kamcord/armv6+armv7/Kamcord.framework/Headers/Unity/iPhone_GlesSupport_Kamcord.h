#ifndef _KAMCORD_IPHONE_GLESSUPPORT_H_
#define _KAMCORD_IPHONE_GLESSUPPORT_H_

#import "iPhone_GlesSupport.h"

void CreateSurfaceGLES_Kamcord(EAGLSurfaceDesc* surface, void * context, void * parentViewController);
void DestroySurfaceGLES_Kamcord(EAGLSurfaceDesc* surface);
void CreateSurfaceMultisampleBuffersGLES_Kamcord(EAGLSurfaceDesc* surface);
void DestroySurfaceMultisampleBuffersGLES_Kamcord(EAGLSurfaceDesc* surface);
void PreparePresentSurfaceGLES_Kamcord(EAGLSurfaceDesc* surface);
void AfterPresentSurfaceGLES_Kamcord(EAGLSurfaceDesc* surface);

#endif
