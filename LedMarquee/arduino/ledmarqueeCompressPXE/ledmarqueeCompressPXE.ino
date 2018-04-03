#define WIDTH   28
#define HEIGHT  10
#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif

// Which pin on the Arduino is connected to the NeoPixels?
// On a Trinket or Gemma we suggest changing this to 1
#define PIN            6

// How many NeoPixels are attached to the Arduino?
#define NUMPIXELS      280

// When we setup the NeoPixel library, we tell it how many pixels, and which pin to use to send signals.
// Note that for older NeoPixel strips you might need to change the third parameter--see the strandtest
// example for more information on possible values.
Adafruit_NeoPixel pixels = Adafruit_NeoPixel(NUMPIXELS, PIN, NEO_GRB + NEO_KHZ800);

byte b;
boolean receive = false;
boolean receiveAll = false;
byte myPalette[100];

byte data[200];
int dataSize = 0;
int dataIndex = 0;
int paletteSize;
int nbPixelColor;
int pixelIndex = 0;
boolean verboseMode = false;

void setup() {
    Serial.begin(115200);
    Serial.println("<Arduino is ready>");
    #if defined (__AVR_ATtiny85__)
      if (F_CPU == 16000000) clock_prescale_set(clock_div_1);
    #endif
    // End of trinket special code

    pixels.begin(); // This initializes the NeoPixel library.
    pixels.clear();
    pixels.setBrightness(100);
    pixels.show();
}

void loop()
{
  if(receiveAll)
  {
    manageData();
    receiveAll = false;
    receive = false;
    dataSize = 0;
    dataIndex = 0;
  }
  else
  {
    
    readbyte();
    printbyte();    
  }
}

void writePalette()
{
  for(int i = 0; i < paletteSize;i++)
    Serial.println(myPalette[i]);
}

void writePixels()
{
  //for(int i = 0; i < WIDTH*HEIGHT*3;i++)
    //Serial.println(myPixels[i]);
}

void manageData()
{
  paletteSize = data[0];
  for(int i = 1; i < paletteSize + 1;i++)
  {
    myPalette[i-1] = data[i];
  }  
  nbPixelColor = data[paletteSize + 1];
  int indexStart = paletteSize + 2;
  for(int i = indexStart; i < indexStart+nbPixelColor; i+=2)
  {
    for(int j = 0; j < data[i]; j++)
    {      
      pixels.setPixelColor(pixelIndex, pixels.Color(myPalette[data[i+1]*3],myPalette[data[i+1]*3+1],myPalette[data[i+1]*3+2]));
      pixelIndex++;
    }
    
  }
  pixels.show();
  if(verboseMode){
    writePalette();
    Serial.println("--------------------");
    writePixels();
    Serial.println("--------------------");      
  } 
  pixelIndex = 0;  
}

void readbyte()
{
  if(Serial.available()>0 && ! receive){
    b = Serial.read();
    if(b == 255)
      receiveAll= true;
    receive = true;
  }  
}

void printbyte(){
  if (receive && ! receiveAll)
  {
    data[dataIndex++] = b;
    dataSize++;
    receive = false;
  }
}

