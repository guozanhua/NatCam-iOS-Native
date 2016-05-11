/*
*   Y4 to RGB24 Greyscale
*   NatCam Native Pipeline Example
*/

//NOTE: Make sure you uncomment '#define NATCAM_DEVELOPER_MODE' atop NatCamNativeInterface.cs

using UnityEngine;
using System;
using System.Runtime.InteropServices;
using NatCamU;
using NatCamU.Internals;

public class Y2Greyscale : UnitygramBase {
	
	private Texture2D greyscaleTexture;
	
	// Use this for initialization
	public override void Start () {
		//Disable the rendering pipeline
		NatCamNativeInterface.DisableRenderingPipeline(true);
		//Enable component buffer updates
		NatCamNativeInterface.EnableComponentUpdate(true);
		//Register for native updates
		NatCamNativeInterface.OnNativePreviewUpdate += OnPreviewUpdate;
		//Start Unitygram Base
		base.Start();
	}
	
	// Update is called once per frame
	void OnPreviewUpdate (ComponentBuffer bufferType, IntPtr buffer, int width, int height, int size) {
		//Check that this is the Y4 buffer
		if (bufferType != ComponentBuffer.Y4) return;
		//Create an rgbBuffer pointer
		IntPtr rgbBuffer;
		//Pass the buffer to the native layer
		Convert(out rgbBuffer, buffer, (UIntPtr)(uint)size);
		//Null checking
		if (greyscaleTexture == null) {
			//Create the texture
			greyscaleTexture = new Texture2D (width, height, TextureFormat.RGB24, false, false);
			//Set the RawImage to display the texture
			RawImage.texture = greyscaleTexture;
		}
		//Load the rgb data from the native layer
		greyscaleTexture.LoadRawTextureData (rgbBuffer, size * 3);
		//Upload changes to the GPU
		greyscaleTexture.Apply();
	}
	
	
	#region --Native Ops--
	#if UNITY_IOS && !UNITIY_EDITOR
	[DllImport("__Internal")]
	private static extern void Convert (out IntPtr rgbBuffer, IntPtr buffer, UIntPtr size);
	#else
	private static void Convert (out IntPtr rgbBuffer, IntPtr buffer, UIntPtr size) {rgbBuffer = IntPtr.Zero;}
	#endif
	#endregion
}
