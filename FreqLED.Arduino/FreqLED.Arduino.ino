#include <FastLED.h>

#define LED_PIN 7
#define LED_BRIGHTNESS 50
#define NUM_LEDS 30

CRGB leds[NUM_LEDS];

String current_effect = "";
String temp_effect = "";
String temp_value = "";
String incoming_text = "";
char incoming_byte = 0;
int temp_values_index = 0;
int local_color[3] = { 0, 0, 0 };
int current_values[5] = { 0, 0, 0, 0, 0 };
int temp_values[5] = { 0, 0, 0, 0, 0 };
bool decoding = false;
bool reading_effect = false;
bool reading_value = false;

bool handShake = true;

int ballPosition = 0;
int ballFrames = 0;
bool ballUp = true;

void setup() {
  FastLED.addLeds<WS2812, LED_PIN, GRB>(leds, NUM_LEDS);
  FastLED.setBrightness(LED_BRIGHTNESS);
  FastLED.clear();
  FastLED.show();
  Serial.begin(19200, SERIAL_8N1);
  Serial.println(1);
}


void loop() {
  if (Serial.available() > 0) {
    //incoming_byte = Serial.read();
    incoming_text = Serial.readStringUntil('\n');
    //Serial.println(incoming_text);
    handShake = false;
    decode();
  }

  if (current_effect == "fx01") {
    SimpleColorVumeter(current_values[0], 255, 0, 0);
  } else if (current_effect == "fx02") {
    SimpleColorVumeter(current_values[0], 0, 255, 0);
  } else if (current_effect == "fx03") {
    SimpleColorVumeter(current_values[0], 0, 0, 255);
  } else if (current_effect == "fx04") {
    SimpleColorVumeter(current_values[0], current_values[1], current_values[2], current_values[3]);
  } else if (current_effect == "fx05") {
    SimpleClassicVumeter(current_values[0]);
  } else if (current_effect == "fx06") {
    SimpleClassicFadeVumeter(current_values[0]);
  } else if (current_effect == "fx07") {
    CenteredClassicVumeter(current_values[0]);
  } else if (current_effect == "fx08") {
    CenteredColorVumeter(current_values[0], current_values[1], current_values[2], current_values[3]);
  } else if (current_effect == "fx09") {
    FlatColorVumeter(current_values[0], current_values[1], current_values[2], current_values[3]);
  } else if (current_effect == "fx10") {
    BouncingBall(current_values[0], current_values[1], current_values[2], current_values[3], current_values[4], 0);
  } else if (handShake) {
    Serial.println("@");
    delay(100);
  } else {
    // Serial.println("Error");
    // delay(100);
  }
}

void SimpleColorVumeter(int _vol, int r, int g, int b) {
  for (int i = 0; i < NUM_LEDS; i++) {
    if (i < (_vol * NUM_LEDS) / 255) {
      leds[i] = CRGB(r, g, b);
    } else {
      leds[i] = CRGB(0, 0, 0);
    }
  }
  FastLED.show();
}

void SimpleClassicVumeter(int _vol) {
  for (int i = 0; i < NUM_LEDS; i++) {
    if (i < _vol * NUM_LEDS / 255) {
      if (i > NUM_LEDS * 0.8) {
        leds[i] = CRGB(255, 0, 0);
      } else if (i > NUM_LEDS * 0.6) {
        leds[i] = CRGB(255, 255, 0);
      } else {
        leds[i] = CRGB(0, 255, 0);
      }
    } else {
      leds[i] = CRGB(0, 0, 0);
    }
  }
  FastLED.show();
}

void SimpleClassicFadeVumeter(int _vol) {
  for (int i = 0; i < NUM_LEDS; i++) {
    if (i < _vol * NUM_LEDS / 255) {
      if (i <= NUM_LEDS * 0.7) {
        if (i > NUM_LEDS * 0.3) {
          local_color[0] = (pow(i, 3) * 255) / pow(NUM_LEDS * 0.7, 3);
        } else {
          local_color[0] = 0;
        }
        local_color[1] = 255;
      } else {
        local_color[0] = 255;
        if (i <= NUM_LEDS * 0.7) {
          local_color[1] = 255;
        } else {
          if (i <= NUM_LEDS * 0.95) {
            local_color[1] = 255 - (pow(i, 7) * 255) / pow(NUM_LEDS * 0.95, 7);
          } else {
            local_color[1] = 0;
          }
        }
      }
    } else {
      local_color[0] = 0;
      local_color[1] = 0;
    }
    local_color[2] = 0;
    leds[i] = CRGB(local_color[0], local_color[1], local_color[2]);
  }
  FastLED.show();
}

void CenteredClassicVumeter(int volume) {
  for (int i = 0; i < NUM_LEDS / 2; i++) {
    if (i < volume * NUM_LEDS / 510) {
      if (i > NUM_LEDS / 2 * 0.8) {
        leds[(NUM_LEDS / 2) + i] = CRGB(255, 0, 0);
        leds[(NUM_LEDS / 2) - 1 - i] = CRGB(255, 0, 0);
      } else if (i > NUM_LEDS / 2 * 0.6) {
        leds[(NUM_LEDS / 2) + i] = CRGB(255, 255, 0);
        leds[(NUM_LEDS / 2) - 1 - i] = CRGB(255, 255, 0);
      } else {
        leds[(NUM_LEDS / 2) + i] = CRGB(0, 255, 0);
        leds[(NUM_LEDS / 2) - 1 - i] = CRGB(0, 255, 0);
      }
    } else {
      leds[(NUM_LEDS / 2) + i] = CRGB(0, 0, 0);
      leds[(NUM_LEDS / 2) - 1 - i] = CRGB(0, 0, 0);
    }
  }
  FastLED.show();
}

void CenteredColorVumeter(int volume, int r, int g, int b) {
  for (int i = 0; i < NUM_LEDS / 2; i++) {
    if (i < volume * NUM_LEDS / 510) {
      leds[(NUM_LEDS / 2) + i] = CRGB(r, g, b);
      ;
      leds[(NUM_LEDS / 2) - 1 - i] = CRGB(r, g, b);
      ;
    } else {
      leds[(NUM_LEDS / 2) + i] = CRGB(0, 0, 0);
      leds[(NUM_LEDS / 2) - 1 - i] = CRGB(0, 0, 0);
    }
  }
  FastLED.show();
}

void FlatColorVumeter(int volume, int r, int g, int b)  //max vol == 255
{
  for (int i = 0; i < NUM_LEDS; i++) {
    if (volume < 255 * 0.3) {
      leds[i] = CRGB(0, 0, 0);
    } else if (volume < 255 * 0.7) {
      leds[i] = CRGB((int)(volume - (255 * 0.3)) * r / (int)(255 * 0.4), (int)(volume - (255 * 0.3)) * g / (int)(255 * 0.4), (int)(volume - (255 * 0.3)) * b / (int)(255 * 0.4));
    } else {
      leds[i] = CRGB(r, g, b);
    }
  }
  FastLED.show();
}

void BouncingBall(int speed, int glow, int r, int g, int b, int _counter) {
  glow = glow * 10 / 255;

  if (ballFrames < 255 - speed) {
    ballFrames++;
    return;
  }

  ballFrames = 0;

  for (int i = 0; i < NUM_LEDS; i++) {
    leds[i] = i == ballPosition ? CRGB(r, g, b) : CRGB(0, 0, 0);
  }

  if (ballUp) {
    for (int i = 0; i < glow; i++) {
      if (ballPosition > i) {
        leds[ballPosition - i - 1] = CRGB(r - (r / glow * i), g - (g / glow * i), b - (b / glow * i));
      }
    }
    for (int i = ((ballPosition + 1) * 2) - 2; i < glow; i++) {
      leds[ballPosition + ++_counter] = CRGB(r - (r / glow * i), g - (g / glow * i), b - (b / glow * i));
    }
  }

  if (!ballUp) {
    for (int i = 0; i < glow; i++) {
      if (ballPosition < NUM_LEDS - i - 1) {
        leds[ballPosition + i + 1] = CRGB(r - (r / glow * i), g - (g / glow * i), b - (b / glow * i));
      }
    }

    for (int i = ((NUM_LEDS - ballPosition) * 2) - 2; i < glow; i++) {
      leds[ballPosition - ++_counter] = CRGB(r - (r / glow * i), g - (g / glow * i), b - (b / glow * i));
    }
  }

  if (ballPosition == NUM_LEDS - 1) {
    ballUp = false;
  }

  if (ballPosition == 0) {
    ballUp = true;
  }

  ballPosition = ballUp ? ballPosition + 1 : ballPosition - 1;
  FastLED.show();
}

String lefPadZeros(String text, int ceros) {
  String _text = "";
  if (text.length() >= ceros) {
    return text;
  } else {
    for (int i = 0; i < ceros - text.length(); i++) {
      _text += "0";
    }
    return _text + text;
  }
}

bool effectExist(String effect) {
  for (int i = 0; i < 20; i++) {
    if (effect == "fx" + lefPadZeros((String)i, 2)) {
      return true;
    }
  }
  return false;
}

void decode() {
  for (int index = 0; index < incoming_text.length(); index++) {
    incoming_byte = (char)incoming_text[index];
    if (incoming_byte == 64) {
      decoding = true;
      reading_effect = true;
      temp_effect = "";
      temp_values_index = 0;
      temp_value = "";
    } else if (decoding) {
      if (reading_effect) {
        if ((incoming_byte >= 65 && incoming_byte <= 90) || (incoming_byte >= 97 && incoming_byte <= 122))  //validate is a lowercase letter
        {
          temp_effect += String(incoming_byte);
        } else if (incoming_byte >= 48 && incoming_byte <= 57) {
          temp_effect += String(incoming_byte);
        } else if (incoming_byte == 38) {
          reading_effect = false;
          reading_value = true;
        } else if (incoming_byte == 35) {
          if (temp_effect.length() > 0) {
            current_effect = temp_effect;
          }
          decoding = false;
        } else {
          decoding = false;
        }
      } else if (reading_value) {
        if (incoming_byte >= 48 && incoming_byte <= 57)  //validate is a number
        {
          temp_value += String(incoming_byte);
        } else if (incoming_byte == 38) {
          if (temp_value.toInt() >= 0 && temp_value.toInt() <= 255) {
            temp_values[temp_values_index] = temp_value.toInt();
            temp_value = "";
            temp_values_index++;
          } else {
            decoding = false;
          }
        } else if (incoming_byte == 35) {
          if (temp_value.toInt() >= 0 && temp_value.toInt() <= 255) {
            temp_values[temp_values_index] = temp_value.toInt();
            current_effect = temp_effect;

            // current_values = temp_values;
            for (int i = 0; i < sizeof(temp_values); i++) {
              if (i <= temp_values_index) {
                current_values[i] = temp_values[i];
              } else {
                current_values[i] = 0;
              }
            }

            // if (!effectExist(current_effect)) {
            //   // Serial.print("Error => ");
            //   // Serial.print(current_effect);
            // }

            // Serial.print(current_effect);
            // Serial.print(",");
            // Serial.print(current_values[0]);
            // Serial.print(",");
            // Serial.print(current_values[1]);
            // Serial.print(",");
            // Serial.print(current_values[2]);
            // Serial.print(",");
            // Serial.print(current_values[3]);
            // Serial.print(",");
            // Serial.print(current_values[4]);
            Serial.println(effectExist(current_effect) ? current_effect : current_effect + "<- error");
            decoding = false;
          } else {
            decoding = false;
          }
        } else {
          decoding = false;
        }
      } else {
      }
    } else {
    }
  }
}