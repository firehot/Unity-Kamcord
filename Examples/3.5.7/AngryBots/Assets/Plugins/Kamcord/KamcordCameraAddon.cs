using UnityEngine;
using System.Collections;

public class KamcordCameraAddon : MonoBehaviour
{
	// Needed to get around hidden assumptions inside Unity rendering engine
	void OnPreRender()
	{
		GL.InvalidateState();
	}
}
