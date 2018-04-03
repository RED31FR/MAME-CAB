#include "Arduino.h"
#include "CObject.h"

#ifndef CTimer_h
#define CTimer_h
 
class CTimer
{
	protected:
		unsigned long _duration;
		unsigned long _time;
		void (*pCallback)();
		
	public:
		CTimer(unsigned long duration, void (*pCallbackFunction)());
		void setup();
		void loop();
}; 
#endif