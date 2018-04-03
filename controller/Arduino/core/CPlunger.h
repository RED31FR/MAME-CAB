#include "Arduino.h"
#include "CObject.h"

#ifndef CPlunger_h
#define CPlunger_h
 
class CPlunger : public CObject
{
  public:
    virtual void setup();
    virtual void loop();
    CPlunger(int PIN);
};
 
#endif