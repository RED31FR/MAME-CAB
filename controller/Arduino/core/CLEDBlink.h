/*
  Morse.h - Library for flashing Morse code.
  Created by David A. Mellis, November 2, 2007.
  Released into the public domain.
*/
#ifndef CLEDBlink_h
#define CLEDBlink_h

#include "Arduino.h"
#include "CLED.h"

class CLEDBlink : public CLED
{
  public:
    CLEDBlink(int pin, int time); 
    virtual void loop();
  protected:
    int _time;
};

#endif
