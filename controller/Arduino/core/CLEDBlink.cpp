#include "CLEDBlink.h"

CLEDBlink::CLEDBlink(int p, int time):CLED(p)
{
  _time = time;
};

void CLEDBlink::loop()
{
  switchOutput();
  delay(_time);
}
