/*#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif*/
/* pin 7 orange
 *  pin 8 vert
 *  pin 9 bleue
 */

#include <Keyboard.h>
#include <Joystick.h>
#include <CD4021BE.h>

#define USEJOYSTICK 0
#define PIN 6

typedef struct
{
  uint16_t position;
  uint8_t r;
  uint8_t g;
  uint8_t b;
  bool state;
} Button;

Button buttons[24];
/*
Adafruit_NeoPixel strip = Adafruit_NeoPixel(24, PIN, NEO_RGB + NEO_KHZ800);
uint32_t c;*/

/*uint8_t keys[] = {
KEY_LEFT_ARROW, KEY_RIGHT_ARROW, KEY_UP_ARROW, KEY_DOWN_ARROW, KEY_LEFT_CTRL, KEY_LEFT_ALT, ' ', KEY_LEFT_SHIFT, 
'w', 'd', 'd', 'g', 'r', 'f', 'q', 's', 
'a', 'z', 'p', 'n', '%', '!', '@', KEY_ESC
};*/

uint8_t keys[] = {
KEY_LEFT_ALT, KEY_LEFT_CTRL, ' ', 'w', KEY_UP_ARROW, KEY_DOWN_ARROW, KEY_LEFT_ARROW, KEY_RIGHT_ARROW,
'r', 'd', 'g', '5', '2', '1', KEY_LEFT_SHIFT, 'x', 
KEY_ESC, 's', 'c', 'z','b', 'a','q', 'f'

};


/* 
  P1LEFT      KEY_LEFT_ARROW
  P1RIGHT     KEY_RIGHT_ARROW
  P1UP        KEY_UP_ARROW
  P1DOWN      KEY_DOWN_ARROW
  P1BTN1      KEY_LEFT_CTRL
  P1BTN2      KEY_LEFT_ALT
  P1BTN3      SPACE
  P1BTN4      KEY_LEFT_SHIFT
  P1BTN5      Z
  P1BTN6      X

  P2LEFT      D
  P2RIGHT     G
  P2UP        R
  P2DOWN      F
  P2BTN1      A
  P2BTN2      S
  P2BTN3      Q
  P2BTN4      W
  PBTN5       ND
  P2BTN6      ND

  InsertCoin  5
  StartP1     1
  StartP2     2
  Exit        KEY_ESC
     
*/

CCD4021BE *inputs;

//fonction appelle par l'objet CCD4021BE inputs à chaque tour de boucle loop
//permet de réaliser des actions en fonction de l'etats des boutons
void testCD4021Btn(CCD4021BE *cd4021)
{
  for(int i = 0; i < 24; i++)
  {
    if(cd4021->getInputState(i))
    {
       if(!buttons[i].state)
       {
         if (USEJOYSTICK == 1)
         {
            Joystick.setButton(i, true);
         }         
         Keyboard.press(keys[i]);         
         buttons[i].state = true;
         /*c = strip.Color(buttons[i].b, buttons[i].r, buttons[i].g);
         strip.setPixelColor(buttons[i].position , c);*/
         /*for(int j=0; i<strip.numPixels(); j++) {
            c = strip.Color(0, 0, i);
             strip.setPixelColor(j , c);
         }*/
       }
    }
    else
    {
        if(buttons[i].state)
        {
          if (USEJOYSTICK == 1)
          {
            Joystick.setButton(i, false);
          }
          Keyboard.release(keys[i]);          
          buttons[i].state = false;
          //c = strip.Color(0, 0, 0);
          //strip.setPixelColor(buttons[i].position, c);
        }       
    }    
    //strip.show();
  }
  if(buttons[13].state && buttons[11].state && buttons[12].state)
  {
    buttons[16].state = true;
    Keyboard.press(keys[16]);
  }
  else
  {
    buttons[16].state = false;
    Keyboard.release(keys[16]); 
  }      
}

void setup() 
{
  inputs = new CCD4021BE(8/*vert latch*/, 9/*bleu data*/, 7/*jaune clock*/, &testCD4021Btn, 3);
  inputs->setup();
  if (USEJOYSTICK == 1)
  {
    Joystick.begin();
  }
  Keyboard.begin();

  /*#if defined (__AVR_ATtiny85__)
    if (F_CPU == 16000000) clock_prescale_set(clock_div_1);
  #endif*/
  for(int i =0 ; i<24;i++)
    buttons[i].state = false;
  buttons[0].position = 9;
  buttons[0].r = 0;
  buttons[0].g = 0;
  buttons[0].b = 250;
  buttons[1].position = 10;
  buttons[1].r = 250;
  buttons[1].g = 0;
  buttons[1].b = 0;
  buttons[2].position = 11;
  buttons[2].r = 0;
  buttons[2].g = 0;
  buttons[2].b = 250;
  buttons[3].position = 6;
  buttons[3].r = 250;
  buttons[3].g = 0;
  buttons[3].b = 0;
  buttons[4].position = 0;
  buttons[4].r = 250;
  buttons[4].g = 0;
  buttons[4].b = 0;
  buttons[5].position = 0;
  buttons[5].r = 250;
  buttons[5].g = 0;
  buttons[5].b = 0;
  buttons[6].position = 0;
  buttons[6].r = 250;
  buttons[6].g = 0;
  buttons[6].b = 0;
  buttons[7].position = 0;
  buttons[7].r = 250;
  buttons[7].g = 0;
  buttons[7].b = 0;
  buttons[8].position = 5;
  buttons[8].r = 0;
  buttons[8].g = 0;
  buttons[8].b = 250;
  buttons[9].position = 0;
  buttons[9].r = 250;
  buttons[9].g = 0;
  buttons[9].b = 0;
  buttons[10].position = 0;
  buttons[10].r = 250;
  buttons[10].g = 0;
  buttons[10].b = 0;
  buttons[11].position = 0;
  buttons[11].r = 250;
  buttons[11].g = 0;
  buttons[11].b = 0;
  buttons[12].position = 0;
  buttons[12].r = 250;
  buttons[12].g = 0;
  buttons[12].b = 0;
  buttons[13].position = 0;
  buttons[13].r = 250;
  buttons[13].g = 0;
  buttons[13].b = 0;
  buttons[14].position = 7;
  buttons[14].r = 0;
  buttons[14].g = 0;
  buttons[14].b = 250;
  buttons[15].position = 8;
  buttons[15].r = 250;
  buttons[15].g = 0;
  buttons[15].b = 0;
  buttons[16].position = 0;
  buttons[16].r = 250;
  buttons[16].g = 0;
  buttons[16].b = 0;
  buttons[17].position = 0;
  buttons[17].r = 250;
  buttons[17].g = 0;
  buttons[17].b = 0;
  buttons[18].position = 0;
  buttons[18].r = 250;
  buttons[18].g = 0;
  buttons[18].b = 0;
  buttons[19].position = 0;
  buttons[19].r = 250;
  buttons[19].g = 0;
  buttons[19].b = 0;
  buttons[20].position = 1;
  buttons[20].r = 0;
  buttons[20].g = 0;
  buttons[20].b = 250;
  buttons[21].position = 2;
  buttons[21].r = 250;
  buttons[21].g = 0;
  buttons[21].b = 0;
  buttons[22].position = 3;
  buttons[22].r = 0;
  buttons[22].g = 0;
  buttons[22].b = 250;
  buttons[23].position = 4;
  buttons[23].r = 250;
  buttons[23].g = 0;
  buttons[23].b = 0;

  
  //strip.begin();
  //strip.show(); // Initialize all pixels to 'off'
}

void loop() 
{
  //traitement des entrées inputs
  inputs->loop();
 }
