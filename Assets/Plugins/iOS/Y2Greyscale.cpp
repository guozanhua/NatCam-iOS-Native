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
    for (int i = 0; i < size; i++) {
        //Set the R channel
        rgb24[i * 3] = ((byte*)yBuffer)[i];
        //Set the G channel
        rgb24[i * 3 + 1] = ((byte*)yBuffer)[i];
        //Set the B channel
        rgb24[i * 3 + 2] = ((byte*)yBuffer)[i];
    }
    //Assign the RGB buffer pointer
    *rgbBuffer = (void*)rgb24;
}