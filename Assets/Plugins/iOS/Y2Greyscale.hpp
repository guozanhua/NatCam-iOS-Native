/*
*   Y4 to RGB24 Greyscale
*   NatCam Native Pipeline Example
*/

#include <stdlib.h>

typedef unsigned char byte;

extern "C" void Convert (void** rgbBuffer, const void* yBuffer, const size_t size);