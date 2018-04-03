/*
  Morse.h - Library for flashing Morse code.
  Created by David A. Mellis, November 2, 2007.
  Released into the public domain.
*/
#ifndef CLED_h
#define CLED_h

#include "Arduino.h"
#include "CObject.h"

class CLED : public CObject
{
  public:
    CLED(int pin); 
    virtual void setup();    
    virtual void loop();  
    void changeOuput(int state);
    void switchOutput();
  protected:
    int _state;
};

#endif
