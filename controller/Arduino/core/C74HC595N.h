#ifndef C74HC595N_h
#define C74HC595N_h

#include "Arduino.h"
#include "CObject.h"
//How many of the shift registers - change this
#define number_of_74hc595s 1
//do not touch
#define numOfRegisterPins number_of_74hc595s * 8

class C74HC595N : public CObject
{
	public:
		C74HC595N(int ser, int rclk, int srclk); 
		virtual void setup(); 
		virtual void update();		
		virtual void loop();  
		void clearRegisters();
		void writeRegisters();
		void setRegisterPin(int index, int value);
		
		/*void switchOutput(int pos);
		void changeOutput(int pos, boolean state);*/
				
	protected:
		int _SER_Pin, _RCLK_Pin, _SRCLK_Pin;
		boolean _registers[numOfRegisterPins];
		
		boolean _outputStates[8] = {
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false			
		};
};
#endif