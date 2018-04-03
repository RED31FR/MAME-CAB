#ifndef CTRIPLELED_h
#define CTRIPLELED_h

#include "Arduino.h"
#include "CObject.h"
#include "CLED.h"
#include "CButton.h"

class CTripleLED : public CObject
{
	public:
		CTripleLED(int pinLed1, int pinLed2, int pinLed3, int pinBtn1, int pinBtn2, int pinBtn3, int pinBtn4, int pinBtn5, void (*pCOne)(CButton*),void (*pCTwo)(CButton*), void (*pCThree)(CButton*), void (*pCFour)(CButton*), void (*pCFive)(CButton*));
		virtual void setup();    
		virtual void loop();		
		void switchOutput(int pos);
		void changeOutput(int pos, boolean state);
		void slipOutputLeft();
		void slipOutputRight();
		
	protected:
		CLED* _leds[3];		
		CButton* _buttons[5];		

		void (*pCallbackOne)(CButton*);
		void (*pCallbackTwo)(CButton*);
		void (*pCallbackThree)(CButton*);
		void (*pCallbackFour)(CButton*);
};

#endif