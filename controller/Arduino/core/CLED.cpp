#include "CLED.h"

CLED::CLED(int p):CObject(p)
{
  _state = LOW;
};

void CLED::setup()
{
  pinMode(_pin, OUTPUT);
}

void CLED::loop()
{
  digitalWrite(_pin, _state);    
};

void CLED::changeOuput(int state)
{
  _state = state;
};

void CLED::switchOutput()
{
  if(_state == LOW)
    _state = HIGH;
  else
    _state = LOW;
}
