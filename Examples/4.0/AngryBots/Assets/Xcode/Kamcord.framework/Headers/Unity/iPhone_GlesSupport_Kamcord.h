#ifndef _KAMCORD_IPHONE_GLESSUPPORT_H_
#define _KAMCORD_IPHONE_GLESSUPPORT_H_

#import "iPhone_GlesSupport.h"

extern "C" void KamcordInitUnity();
extern "C" void ForceOrientationCheck();

void CreateSurfaceGLES_Kamcord(EAGLSurfaceDesc * surface, void * context, void * parentViewController);
void CreateRenderingSurfaceGLES_Kamcord(EAGLSurfaceDesc * surface);
void DestroySurfaceGLES_Kamcord(EAGLSurfaceDesc * surface);
void DestroyRenderingSurfaceGLES_Kamcord(EAGLSurfaceDesc * surface);
void PreparePresentSurfaceGLES_Kamcord(EAGLSurfaceDesc * surface);
void AfterPresentSurfaceGLES_Kamcord(EAGLSurfaceDesc * surface);

#endif
