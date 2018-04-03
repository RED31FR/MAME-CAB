#include "CNudge.h"

CNudge::CNudge(/*void (*pCallbackFunctionL)(CNudge*), void (*pCallbackFunctionR)(CNudge*), void (*pCallbackFunctionF)(CNudge*), */char l, char r, char f)
{
	/*pCallbackL = pCallbackFunctionL;
	pCallbackR = pCallbackFunctionR;
	pCallbackF = pCallbackFunctionF;*/
	left = new CKey(l);
	right = new CKey(r);
	front = new CKey(f);
}

void CNudge::setup()
{
	// join I2C bus (I2Cdev library doesn't do this automatically)
    Wire.begin();
	accel.initialize();
	left->setup();
	right->setup();
	front->setup();
	lastMotion = lastLeftMotion = lastRightMotion = lastFrontMotion = 0;
} 

void CNudge::loop()
{
	double pitch, roll;
    // read raw accel measurements from device
    accel.getAcceleration(&ax, &ay, &az);

    //Low Pass Filter
    fXg = ax * alpha + (fXg * (1.0 - alpha));
    fYg = ay * alpha + (fYg * (1.0 - alpha));
    fZg = az * alpha + (fZg * (1.0 - alpha));
  
    //Roll & Pitch Equations
    roll  = (atan2(-fYg, fZg)*180.0)/M_PI;
    pitch = (atan2(fXg, sqrt(fYg*fYg + fZg*fZg))*180.0)/M_PI;
    if(left->isPressed())
		left->setState(false);
	if(right->isPressed())
		right->setState(false);
	if(front->isPressed())
		front->setState(false);
	
	if(pitch < -10 && (millis() - lastMotion > 500))
    {
		right->setState(true);
		lastMotion = millis();
		//lastRightMotion = millis();
		Serial.println("Tappe droite--");
		//delay(500);
    }
    if(pitch > 20 && (millis() - lastMotion > 500))
    {
		left->setState(true);
		lastMotion = millis();
		//lastLeftMotion = millis();
		Serial.println("Tappe gauche--");
		//delay(500);
    }
	if(roll < 170 && (millis() - lastMotion > 500))
    {
		front->setState(true);
		lastMotion = millis();
		lastLeftMotion = millis();
		Serial.println("Tappe frontale");
		//delay(500);
    }
	//Serial.println(roll);
	left->loop();
	right->loop();
	front->loop();
}