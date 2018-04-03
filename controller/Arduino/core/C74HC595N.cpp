#include "C74HC595N.h"

C74HC595N::C74HC595N(int ser, int rclk, int srclk): CObject(ser)
{
  _SER_Pin = ser;
  _RCLK_Pin = rclk;
  _SRCLK_Pin = srclk;
};

void C74HC595N::setup()
{	
	//define pin modes
	pinMode(_SER_Pin, OUTPUT);
	pinMode(_RCLK_Pin, OUTPUT);
	pinMode(_SRCLK_Pin, OUTPUT);
	clearRegisters();
	writeRegisters();
}

void C74HC595N::update()
{
	writeRegisters();
};

void C74HC595N::loop()
{
	update();
};

void C74HC595N::clearRegisters()
{
	for(int i = numOfRegisterPins - 1; i >=  0; i--)
	{
		_registers[i] = LOW;
	}
};

void C74HC595N::writeRegisters()
{
	digitalWrite(_RCLK_Pin, LOW);
 
	for(int i = numOfRegisterPins - 1; i >=  0; i--)
	{
		digitalWrite(_SRCLK_Pin, LOW);

		int val = _registers[i];

		digitalWrite(_SER_Pin, val);
		digitalWrite(_SRCLK_Pin, HIGH);
	}
	digitalWrite(_RCLK_Pin, HIGH);
};

void C74HC595N::setRegisterPin(int index, int value)
{
	_registers[index] = value;
};

