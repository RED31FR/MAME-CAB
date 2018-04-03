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

#define BRIGTHNESS     254

// When we setup the NeoPixel library, we tell it how many pixels, and which pin to use to send signals.
// Note that for older NeoPixel strips you might need to change the third parameter--see the strandtest
// example for more information on possible values.
Adafruit_NeoPixel pixels = Adafruit_NeoPixel(NUMPIXELS, PIN, NEO_GRB + NEO_KHZ800);

int b;
byte state = 0;
//state = 0 read palette size, state = 1 read palette, state = 2 read pixels size, state = 3 read pixels
int nbRead = 0;
//int indexPalette = 0;
byte myPalette[780];

byte data[2];

int paletteSize = 0;
int nbPixelColor;
int pixelIndex = 0;

void setup() {    
    #if defined (__AVR_ATtiny85__)
      if (F_CPU == 16000000) clock_prescale_set(clock_div_1);
    #endif
    // End of trinket special code

    pixels.begin(); // This initializes the NeoPixel library.
    pixels.clear();
    pixels.setBrightness(BRIGTHNESS);
    pixels.show();
    Serial.begin(115200);
    Serial.println("<Arduino is ready>");
    state = 0;
    nbRead = 0;
    pixelIndex = 0;
    nbPixelColor = 0;
    paletteSize = 0;
}

void loop()
{
  readbyteSmallArray();
}

/***********************************************************************************************************
   Image Compress Format
************************************************************************************************************
   Value 255 is not allowed (when this value is encountered, it was changed by 254) Value 255 = end of block
************************************************************************************************************
   Byte 0 to 3                                         =>  Palette Size
************************************************************************************************************
   Byte 4 to (4 + Palette Size)                        => Palette Colors
   one color is 3 bytes (R, G, B)
************************************************************************************************************
   byte Palette Size + 4 to Palette Size + 7           =>  Pixels count * 2
   one byte for number of pixels, one byte for colr index in palette
************************************************************************************************************
   last byte                                           =>  End of file byte 255
***********************************************************************************************************/
void readbyteSmallArray()
{
  boolean show = false;
  if(Serial.available()>0){
    b = Serial.read();    
    //Serial.print("state : ");
    //Serial.println(b);
    //Serial.println(state);
    switch(state)
    {
      case 0:                      
            //Serial.print("State 0");            
            paletteSize = paletteSize + b;
            nbRead = nbRead + 1;
            if(nbRead > 3)
            {
              state = 1;              
              nbRead = 0;             
            }            
      break;
      case 1:
            //Serial.print("State 1");
            if(nbRead == 0)
            {
              //Serial.print("Palette Size :");
              //Serial.println(paletteSize); 
            }                        
            /*****************************************************/
            /*myPalette[indexPalette] = (b >> 4) << 4;
            indexPalette += 1;
            myPalette[indexPalette] = (b << 4) >> 4;
            indexPalette += 1;
            /*****************************************************/
            myPalette[nbRead] = b;
            /*****************************************************/
            nbRead = nbRead + 1;
            if(nbRead > paletteSize-1)
            {
              state = 2;
              nbRead = 0;  
              nbPixelColor = 0;            
            }            
      break;
      case 2:
         //Serial.print("State 2");
         nbPixelColor = nbPixelColor + b;
         nbRead = nbRead + 1;
         if(nbRead > 2)
          {
            //Serial.print("nb Pixels ");
            //Serial.println(nbPixelColor);
            state = 3;
            nbRead = 0;       
          }   
      break;
      case 3:   
            if(nbRead == 0)
            {
              //Serial.print("NB Pixels :");
              //Serial.println(nbPixelColor); 
            }  
          //Serial.print("State 3");       
          /*if(pixelIndex > 279)
          {
            state = 0;
            nbRead = 0;
            pixelIndex = 0;
            nbPixelColor = 0;
            paletteSize = 0;
            Serial.println("affichage");
            pixels.show();
            paletteSize = b;
            nbRead = 1;
          }
          else*/
          {
            if(nbRead > 1)
            {
              //Serial.println(data[0]);
              //Serial.println(data[1]);
              for(int i = 0; i < data[0];i++)
              {
                pixels.setPixelColor(pixelIndex, pixels.Color(myPalette[data[1]*3], myPalette[data[1]*3+1], myPalette[data[1]*3+2]));
                //Serial.println(pixelIndex);
                pixelIndex = pixelIndex + 1;
                if(pixelIndex >= 280)
                {
                  pixels.show();
                  //Serial.println("affichage");
                  state = 0;
                  nbRead = 0;
                  pixelIndex = 0;
                  nbPixelColor = 0;
                  paletteSize = 0;
                  nbRead = 0;
                  show = true;
                  //Serial.println("affichage");                  
                }
              }               
              //nbRead = 0;  
              if(! show)
              {
                data[0] = b;
                nbRead = 1;   
              }              
            }
            else
            {
              data[nbRead] = b;
              nbRead = nbRead + 1;              
            }
          }          
      break;
    }
  }    
}
