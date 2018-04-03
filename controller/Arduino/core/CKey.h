#include "Arduino.h"

#ifndef CKey_h
#define CKey_h

class CKey
{
  private: 
		char key;
		bool state;
		bool stateChange;
  
  public:
    virtual void setup();
    virtual void loop();
    CKey(char c);
	void setState(bool s);
	bool isPressed();
};

#endif