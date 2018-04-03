#include <Keyboard.h>
#include "CKey.h"

CKey::CKey(char c)
{
	key = c;
	state = LOW;
	stateChange = false;
}
 
void CKey::setup()
{
	
} 

void CKey::loop()
{
	if(stateChange)
	{
		if(state)
			Keyboard.press(key);
		else
			Keyboard.release(key);
		stateChange = false;
	}
}

void CKey::setState(bool s)
{
	if(state != s)
	{
		state = s;
		stateChange = true;
	}
}

bool CKey::isPressed()
{
	return state;
}