# Native-Code-NatCam
A demonstration of using native code (C++) with the NatCam Native Pipeline. Powered by NatCam v1.2.

In this example, the camera preview data is sent to the native layer to convert from color to greyscale using the formula:

  Y = 0.2126 R + 0.7152 G + 0.0722 B

Since this is a very expensive operation because of the sheer amount of data we must process (width * height iterations), we can approximate this for better performance by performing a bit shift:

  Y = (R << 1 + R + G << 2 + B) >> 3
