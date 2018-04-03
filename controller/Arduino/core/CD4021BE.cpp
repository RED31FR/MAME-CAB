#include "CD4021BE.h"

CCD4021BE::CCD4021BE(int latch, int data, int clock, void (*pCbFunctionPressed)(CCD4021BE*), int nb) : CObject(latch)
{
  _latchPin = latch;
  _dataPin = data;
  _clockPin = clock;
  _nb = nb;
  pCallbackTestBtns = pCbFunctionPressed;
};

void CCD4021BE::setup()
{
    //define pin modes
    pinMode(_latchPin, OUTPUT);
    pinMode(_clockPin, OUTPUT);
    pinMode(_dataPin, INPUT);
    for(int i =0; i < _nb;i++)
    {
        _switchVars[i] = 0;
    }
}

void CCD4021BE::loop()
{
    initConnection();
    for(int i =0; i < _nb;i++)
    {
        getData(i);
    }
    pCallbackTestBtns(this);
}


////// ----------------------------------------shiftIn function
///// just needs the location of the data pin and the clock pin
///// it returns a byte with each bit in the byte corresponding
///// to a pin on the shift register. leftBit 7 = Pin 7 / Bit 0= Pin 0

byte CCD4021BE::shiftIn() {
    int i;
    int temp = 0;
    int pinState;
    byte myDataIn = 0;

    pinMode(_clockPin, OUTPUT);
    pinMode(_dataPin, INPUT);
    //we will be holding the clock pin high 8 times (0,..,7) at the
    //end of each time through the for loop

    //at the begining of each loop when we set the clock low, it will
    //be doing the necessary low to high drop to cause the shift
    //register's DataPin to change state based on the value
    //of the next bit in its serial information flow.
    //The register transmits the information about the pins from pin 7 to pin 0
    //so that is why our function counts down
    for (i=7; i>=0; i--)
    {
    digitalWrite(_clockPin, 0);
    delayMicroseconds(0.2);
    temp = digitalRead(_dataPin);
    if (temp) {
      pinState = 1;
      //set the bit to 0 no matter what
      myDataIn = myDataIn | (1 << i);
    }
    else {
      //turn it off -- only necessary for debuging
     //print statement since myDataIn starts as 0
      pinState = 0;
    }

    //Debuging print statements
    //Serial.print(pinState);
    //Serial.print("     ");
    //Serial.println (dataIn, BIN);

    digitalWrite(_clockPin, 1);

    }
    //debuging print statements whitespace
    //Serial.println();
    //Serial.println(myDataIn, BIN);
    return myDataIn;
}

boolean CCD4021BE::getInputState(int pos)
{
    if(pos < NBCD4021BE * 8)
        return _inputStates[pos];
    else
        return false;
}

void CCD4021BE::initConnection()
{
    //Pulse the latch pin:
    //set it to 1 to collect parallel data
    digitalWrite(_latchPin,1);
    //set it to 1 to collect parallel data, wait
    delayMicroseconds(20);
    //set it to 0 to transmit data serially
    digitalWrite(_latchPin,0);
}

void CCD4021BE::getData(int pos)
{
    //while the shift register is in serial mode
    //collect each shift register into a byte
    //the register attached to the chip comes in first
    _switchVars[pos] = shiftIn();

    /*
    //Print out the results.
    //leading 0's at the top of the byte
    //(7, 6, 5, etc) will be dropped before
    //the first pin that has a high input
    //reading
    //Serial.println(switchVar1, BIN);
    */

    //This for-loop steps through the byte
    //bit by bit which holds the shift register data
    //and if it was high (1) then it prints
    //the corresponding location in the array
    for (int n=0; n<8; n++)
    {
        //so, when n is 3, it compares the bits
        //in switchVar1 and the binary number 00001000
        //which will only return true if there is a
        //1 in that bit (ie that pin) from the shift
        //register.
        if (_switchVars[pos] & (1 << n) )
        {
            /*
            //print the value of the array location
            //Serial.println(note2sing[n]);
            */
            _inputStates[n+(pos*8)] = true;
        }
        else
        {
            _inputStates[n+(pos*8)] = false;
        }
    }
}
