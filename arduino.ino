const int ledPin = 13;
const int knockSensor = A0;
const int threshold = 25;
const int buzzerPin = 8;;

int sensorReading = 0;
int ledState = LOW;

char receivedChar;
boolean newData = false;

void setup() {
  pinMode(ledPin, OUTPUT);
  pinMode(buzzerPin, OUTPUT);
  Serial.begin(9600);

}

void loop() {
  // put your main code here, to run repeatedly:
  sensorReading = analogRead(knockSensor);
  Serial.println(sensorReading);
//
//  if (sensorReading >= threshold) {
//    ledState = !ledState;
//    digitalWrite(ledPin, ledState);
//    Serial.println("K");
//  }
  delay(100);

  digitalWrite(buzzerPin, HIGH);
  delay(500);
  digitalWrite(buzzerPin, LOW);

//  recvOneChar();
//  buzz_motor();

 }
 
void recvOneChar() {
 if (Serial.available() > 0) {
 receivedChar = Serial.read();
 newData = true;
 }
}

void buzz_motor() {
 if (newData == true) {
  if (receivedChar == 'b') {
    Serial.println("received");
    digitalWrite(buzzerPin, HIGH);
    delay(100);
    digitalWrite(buzzerPin, LOW);
  }
 newData = false;
 }
}
