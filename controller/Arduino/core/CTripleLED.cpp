#include "CTripleLED.h"

CTripleLED::CTripleLED(int pinLed1, int pinLed2, int pinLed3, int pinBtn1, int pinBtn2, int pinBtn3, int pinBtn4, int pinBtn5, void (*pCOne)(CButton*),void (*pCTwo)(CButton*), void (*pCThree)(CButton*), void (*pCFour)(CButton*), void (*pCFive)(CButton*)):CObject(2)
{
	_leds[0] = new CLED(pinLed1);
	_leds[1] = new CLED(pinLed2);
	_leds[2] = new CLED(pinLed3);
	
	_buttons[0] = new CButton(pinBtn1, pCOne);
	_buttons[1] = new CButton(pinBtn2, pCTwo);
	_buttons[2] = new CButton(pinBtn3, pCThree);
	_buttons[3] = new CButton(pinBtn4, pCFour);
	_buttons[4] = new CButton(pinBtn5, pCFive);
};

void CTripleLED::setup()
{
	for(int i = 0; i < 3; i++)
	{
		_leds[i]->setup();
		_buttons[i]->setup();
	}
};
    
void CTripleLED::loop()
{
	for(int i = 0; i < 3; i++)
	{
		_buttons[i]->loop();
		_leds[i]->loop();
	}
	_buttons[3]->loop();
	_buttons[4]->loop();
};

void CTripleLED::slipOutputLeft()
{
	
};

void CTripleLED::slipOutputRight()
{
	
};

void CTripleLED::switchOutput(int pos)
{
	if(pos < 3)
	{
		_leds[pos]->switchOutput();
	}
};

void CTripleLED::changeOutput(int pos, boolean state)
{
	if(pos < 3)
	{
		_leds[pos]->changeOuput(state);
	}
};