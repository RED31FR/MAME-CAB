#include "Arduino.h"
#include "CMicroSwitch.h"

CMicroSwitch::CMicroSwitch(int PIN, void (*pCallbackFunctionPressed)(CMicroSwitch*), void (*pCallbackFunctionUnpressed)(CMicroSwitch*)) : CObject(PIN)
{
	_pin = PIN;
	pCallbackPressed = pCallbackFunctionPressed;
	pCallbackUnpressed = pCallbackFunctionUnpressed;	
}
 
void CMicroSwitch::setup()
{
	pinMode(_pin, INPUT_PULLUP); 
	state = digitalRead(_pin);  
	pressed = state == LOW;
	lastValue = state;
	lastDebounceTime = 0;
} 

void CMicroSwitch::loop()
{
	int value = digitalRead(_pin);
	if (value != lastValue)
	{
		lastDebounceTime = millis();
	}
	if ((millis() - lastDebounceTime) > 10)
	{
		if (value != state)
		{
			state = value;
			pressed = state == LOW;
			if (pressed)
			{
				//Button pressed
				pCallbackPressed(this);
			}
			else
			{
				//Button released
				pCallbackUnpressed(this);
			}
		}
	}
	lastValue = value;
}

bool CMicroSwitch::isPressed()
{
	return state;
}