#include "Arduino.h"
#include "CPlunger.h"
#include <Joystick.h>

CPlunger::CPlunger(int PIN) : CObject(PIN)
{
  _pin = PIN;
}
 
void CPlunger::setup()
{
	pinMode(_pin, INPUT);  
} 

void CPlunger::loop()
{
	int val;
	
	//lecture des valeur du pin 
	val = analogRead(_pin);
	//mappage de la valeur avec une autre echelle
	if(val>=0 and val < 12)
		val = map(val, 0, 12, -127, -95);
	if(val>=12 and val < 30)
		val = map(val, 12, 30, -95, -63);
	if(val>=30 and val < 73)
		val = map(val, 30, 73, -63, -31);
	if(val>=73 and val < 160)
		val = map(val, 73, 160, -31, 1);
	if(val>=160 and val < 280)
		val = map(val, 160, 280, 1, 33);
	if(val>=280 and val < 530)
		val = map(val, 280, 530, 33, 65);
	if(val>=530 and val < 865)
		val = map(val, 530, 865, 65, 97);
	if(val>=865 and val < 1023)
		val = map(val, 865, 1023, 97, 127);
	if(val > 127)
		val = 127;
	//Serial.println(val);
	//val = map(val, 0, 1023, 0, 255);
	//val = val -127;
	//saisie de la valeur du potentiometre sur l'axe Z du joystick
	Joystick.setZAxis(val);
}