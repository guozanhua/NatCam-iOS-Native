/*
*   Y4 to RGB24 Greyscale
*   NatCam Native Pipeline Example
*/

#include "Y2Greyscale.hpp"

byte* rgb24;

void Convert (void** rgbBuffer, const void* yBuffer, const size_t size) {
    //Null checking
    if (rgb24 == NULL) rgb24 = new byte[size * 3]; //We multiply size by 3 because this is 3-channel RGB24
    //Iterate
    for (int i = 0, p; i < size; i++, p = i * 3) { //Performing a C-style cast is bad practice, use reinterpret_cast<byte*> instead
        //Set the R channel
        rgb24[p] = ((byte*)yBuffer)[i];
        //Set the G channel
        rgb24[++p] = ((byte*)yBuffer)[i];
        //Set the B channel
        rgb24[++p] = ((byte*)yBuffer)[i];
    }
    //Assign the RGB buffer pointer
    *rgbBuffer = (void*)rgb24;
}
