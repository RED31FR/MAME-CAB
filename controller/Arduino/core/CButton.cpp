#include "Arduino.h"
#include "CButton.h"

CButton::CButton(int PIN, void (*pCallbackFunction)(CButton*)) : CObject(PIN)
{
  _pin = PIN;
  pCallback = pCallbackFunction;
}
 
void CButton::setup()
{
  pinMode(_pin, INPUT_PULLUP);
  state = digitalRead(_pin);
  pressed = state == LOW;
  lastValue = state;
  lastDebounceTime = 0;
} 

void CButton::loop()
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
      pCallback(this);
    }
  }
  lastValue = value;
}