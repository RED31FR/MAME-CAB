/*
  Morse.h - Library for flashing Morse code.
  Created by David A. Mellis, November 2, 2007.
  Released into the public domain.
*/
#ifndef CObject_h
#define CObject_h

#include "Arduino.h"

class CObject
{
  public:
    CObject(int pin);
    virtual void setup();
    virtual void loop();
  protected:
    int _pin;
};

#endif
