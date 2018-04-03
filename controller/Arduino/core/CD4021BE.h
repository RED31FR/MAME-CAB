#ifndef CD4021BE_h
#define CD4021BE_h

#include "Arduino.h"
#include "CObject.h"
#define NBCD4021BE 3

class CCD4021BE : public CObject
{
	public:
                CCD4021BE(int latch, int data, int clock, void (*pCbFunctionPressed)(CCD4021BE*), int nb = 1);
		virtual void setup(); 	
		virtual void loop();  
		boolean getInputState(int pos);		
				
	protected:
		void (*pCallbackTestBtns)(CCD4021BE*);
	
                int _latchPin, _dataPin, _clockPin, _nb;
                byte _switchVars[NBCD4021BE];
                boolean _inputStates[NBCD4021BE * 8] = {
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false			
		};
		
                void initConnection();
                void getData(int pos);
                byte shiftIn();
};
#endif
