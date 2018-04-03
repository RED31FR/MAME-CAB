#include "Arduino.h"
#include "CTimer.h"

CTimer::CTimer(unsigned long duration, void (*pCallbackFunction)())
{
	_duration = duration;
	pCallback = pCallbackFunction;
};

void CTimer::setup()
{
	_time = millis();
};
		

void CTimer::loop()
{
	unsigned long t = millis();
	if(_time + _duration < t)
	{
		_time = t;
		pCallback();
	}
};