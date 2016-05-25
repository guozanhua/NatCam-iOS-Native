# Native-Code-NatCam
A demonstration of using native code (C++) with the NatCam Native Pipeline. Powered by NatCam v1.2.

In this example, the camera preview data is sent to the native layer to convert Y data (lumincance) to greyscale. Since the Y channel already contains luminance data, all we have to do is fill an RGB24 texture with the data like so:

From Y4 (Y) to RGB24 (Y, Y, Y).

To do this, we use the OnNativePreviewUpdate event in NatCamNativeInterface. In order to get Y channel data in system memory, we must initialize NatCam with a Readable preview. Also, we will disable NatCam's rendering pipeline since we don't need NatCam to convert the raw camera luma and chroma data to ARGB32.

# Setup Instructions
- Download NatCam v1.2 here: https://www.assetstore.unity3d.com/en/#!/content/52154
- Import NatCam into the project
- Build and Run!

# Note
- This demo works only on iOS. For Android, you must manually compile the native sources with the Android NDK.
- This demo requires Unity 5.3 and up.
