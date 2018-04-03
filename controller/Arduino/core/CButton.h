#include "Arduino.h"
#include "CObject.h"

#ifndef CButton_h
#define CButton_h
 
class CButton : public CObject
{
  private:
    int lastValue;
    unsigned long lastDebounceTime; 
    void (*pCallback)(CButton*);
	
  public:
    String label;
    int state;
    bool pressed;
    virtual void setup();
    virtual void loop();
    CButton(int PIN, void (*pCallbackFunction)(CButton*));
};
 
#endif