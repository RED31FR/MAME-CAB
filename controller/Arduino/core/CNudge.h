#include "Arduino.h"
// Arduino Wire library is required if I2Cdev I2CDEV_ARDUINO_WIRE implementation
// is used in I2Cdev.h
#include "Wire.h"

// I2Cdev and ADXL345 must be installed as libraries, or else the .cpp/.h files
// for both classes must be in the include path of your project
#include "I2Cdev.h"
#include "ADXL345.h"

#include "CKey.h"

// class default I2C address is 0x53
// specific I2C addresses may be passed as a parameter here
// ALT low = 0x53 (default for SparkFun 6DOF board)
// ALT high = 0x1D

#ifndef CNudge_h
#define CNudge_h

class CNudge
{
  private: 
	ADXL345 accel;
	int16_t ax, ay, az;
	const float alpha = 0.5;
	double fXg = 0;
	double fYg = 0;
	double fZg = 0;
	/*void (*pCallbackLeft)(CNudge*);
	void (*pCallbackRight)(CNudge*);
	void (*pCallbackFront)(CNudge*);*/
	unsigned long lastMotion, lastLeftMotion, lastRightMotion, lastFrontMotion; 
	CKey *left, *right, *front;
  
  public:
    virtual void setup();
    virtual void loop();
    CNudge(/*void (*pCallbackFunctionL)(CNudge*), void (*pCallbackFunctionR)(CNudge*), void (*pCallbackFunctionF)(CNudge*), */char l, char r, char f);
};

#endif