#include "Arduino.h"
#include "CObject.h"

#ifndef CMicroSwitch_h
#define CMicroSwitch_h
 
class CMicroSwitch : public CObject
{
  private: 
	int lastValue;
	int state;
    bool pressed;	
    unsigned long lastDebounceTime; 
    void (*pCallbackPressed)(CMicroSwitch*);
	void (*pCallbackUnpressed)(CMicroSwitch*);	
  
  public:
    String label;    
    virtual void setup();
    virtual void loop();
    CMicroSwitch(int PIN, void (*pCallbackFunctionPressed)(CMicroSwitch*), void (*pCallbackFunctionUnressed)(CMicroSwitch*));
	bool isPressed();
};
 
#endif