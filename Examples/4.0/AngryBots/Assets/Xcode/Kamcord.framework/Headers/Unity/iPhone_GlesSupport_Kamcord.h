#ifndef _KAMCORD_IPHONE_GLESSUPPORT_H_
#define _KAMCORD_IPHONE_GLESSUPPORT_H_

#import "iPhone_GlesSupport.h"

extern "C" void KamcordInitUnity();
void CreateSurfaceGLES_Kamcord(struct EAGLSurfaceDesc* surface, void * context, void * parentViewController);
void DestroySurfaceGLES_Kamcord(struct EAGLSurfaceDesc* surface);
void CreateSurfaceMultisampleBuffersGLES_Kamcord(struct EAGLSurfaceDesc* surface);
void DestroySurfaceMultisampleBuffersGLES_Kamcord(struct EAGLSurfaceDesc* surface);
void PreparePresentSurfaceGLES_Kamcord(struct EAGLSurfaceDesc* surface);
void AfterPresentSurfaceGLES_Kamcord(struct EAGLSurfaceDesc* surface);

#endif
