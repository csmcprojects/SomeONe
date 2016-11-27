/*The MIT License (MIT)
Copyright (c) <2016> <Carlos Campos>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT 
NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

//Library for using the WiFi API
#include "ESP8266WiFi.h"
//Library that contains the SPIFFS API
#include "FS.h"

//COMMANDS FOR SUCESS and FAILURE operations
String DeviceBooleanTResponse = "DBTR";
String DeviceBooleanFResponse = "DBFR";

//CONFIGURATION COMMANDS

//1º - Code for checking if this is a Someone device
String AreYouASomeoneDevice = "AYASD" ;
//2º - Code that asks the arduino to scan for the available wifi networks
String GiveMeEspNetworkList = "GMENL";
//3º - Code that tests the wifi connection with the data given by the user
String EspWifiNetworkAuth = "EWNA";
//4º - Code that checks if the device needs authenticationn
String NeedsUserAuth = "NUA";
//5º - Code that authenticates a user
String UserAuth = "UA";
//6º - Code for registering an user
String RegisterUser = "RU";
//7º - Code that has appended the servel url
String ServerURL = "SURL  ";
//8º - Code to save the configuration
String SaveConfig = "SC";
//9º - Reset the arduino
String ResetDevice = "RD";

//The message received from the computer
String message;

//Flags

//If the device has been configured this is true, else false.
bool isDeviceConfigured = false;

//Data used by the device when it's working

String deviceName = "";
String devicePassword = "";
String networkName = "";
String networkPassword = "";
String serverHost = "";
String serverUrl = "";
String serverAuthKey = "";

//The state of the sensor (read in port A0)
bool deviceStatus = false;

bool LoadConfigData(){
  if(networkName == ""){   
    //Checks if the device is configured by checking if there is any configuration file in memory
    bool result = SPIFFS.begin(); 
    if(result){
      // this opens the file "f.txt" in read-mode
      File f = SPIFFS.open("/f.txt", "r"); 
      if(f){
        String text = f.readString();
        deviceName = getValue(";"+text, ';', 0);
        devicePassword = getValue(text, ';', 1);
        networkName = getValue(text, ';', 2);
        networkPassword = getValue(text, ';', 3);
        serverHost = getValue(text, ';', 4);
        serverUrl = getValue(text, ';', 5);
        serverAuthKey = getValue(text, ';', 6);
        f.close();
        return true;
      }
      return false;
    } else {
      return false;
    }   
  }
  return true;
}


bool ConnectToWifi(){
  if(WiFi.status() == WL_CONNECTED) return true;
  //Serial.println("Trying to connect to wifi\033");
  char nn[sizeof(networkName)+1]; 
  networkName.toCharArray(nn, sizeof(networkName)+1);
  char np[sizeof(networkPassword)]; 
  networkPassword.toCharArray(np, sizeof(networkPassword));
  
  WiFi.begin(nn, np);
  int tryCounter = 0;
  while (WiFi.status() != WL_CONNECTED)
  {
    delay(500);
    tryCounter++;
    if(tryCounter > 50){ break;}
  }
  if(WiFi.status() == WL_CONNECTED){
     return true;
  } else {
     return false;
  }
}

bool StateIsDifferentFromLast(){
  //Serial.print("Sensor value: ");
  float sensor = analogRead(0) * (5.0 / 1023.0);
  //Serial.println(sensor);
  bool sensorBool = ((sensor > 2.0) ? true : false);
  bool auxDeviceStatus = deviceStatus;
  deviceStatus = sensorBool;
  return (auxDeviceStatus != deviceStatus);
}

bool SendDataToServer(){
  WiFiClient client;
  char su[500];
  (serverHost).toCharArray(su, 500);

  //Serial.print("Connecting to server at: ");
  //Serial.println(su);
  if (client.connect(su, 80)) {
    //Serial.println("Connected to server");
    // Make a HTTP request:
    client.println("GET "+ serverUrl + "?deviceName="+ deviceName +"&deviceKey=" + serverAuthKey + "&deviceState=" + deviceStatus +" HTTP/1.1");
    client.println("Host: " + serverHost);
    client.println("Connection: close");
    client.println();
    //Serial.println("Request sent : GET "+ serverUrl + "?deviceName="+ deviceName +"&deviceKey=" + serverAuthKey + "&deviceState=" + deviceStatus +" HTTP/1.1");
    //Serial.println("Server response: ");
    while (client.available()) {
      char c = client.read();
     // Serial.write(c);
    }
    //Serial.println("\033[1;32mEnd server response\033[0m\n\n");
  
    client.stop();
    return true;
  }
  client.stop();
  return false;
}

void Loop(){
   if(LoadConfigData()){
    //Serial.println("Configuration data loaded.");
    if(StateIsDifferentFromLast()){
      //Serial.println("Connected to the wifi network.");
        if(ConnectToWifi()){
        String statusToString = (deviceStatus ? "true" : "false");
        //Serial.println("State as been updated to " + statusToString + ".");  
        if(SendDataToServer()){
          //Serial.println("Data sent to server.");
        } else {
          //Serial.println("Failed to send data to server.");
        }
      } else {
         //Serial.println("Failed to connect to thw wifi network.");
        
      }
    } else {
     //Sleep for 30 seconds
     delay(2000);
    }
   } else {
     //Serial.println("Failed to load configuration data.");
   }
}

//Checks if the device is configured by checking if there is any configuration file in memory
bool IsDeviceConfigured(){
  bool result = SPIFFS.begin(); 
  // this opens the file "f.txt" in read-mode
  File f = SPIFFS.open("/f.txt", "r"); 
  bool file = f;
  //if the file opens it exists and it means that the device was configured -> returns true, else false.
  f.close();
  return file;
}

bool SaveConfigF(String message){
  //Resets the device
  Reset();
  //Add the new configuration
  bool result = SPIFFS.begin();
  
  // this opens the file "f.txt" in read-mode
  File f = SPIFFS.open("/f.txt", "w");
  if(f){
    //device username
    f.print(getValue(message, ';', 1)+";");
    //device password
    f.print(getValue(message, ';', 2)+";");
    //wifi network name
    f.print(getValue(message, ';', 3)+";");
    //wifi netowork password
    f.print(getValue(message, ';', 4)+";");
    //server host
    f.print(getValue(message, ';', 5)+";");
    //server request url
    f.print(getValue(message, ';', 6)+";");
    //server auth key
    f.println(getValue(message, ';', 7)+";");
  } else {
    Serial.println(DeviceBooleanFResponse);
    return false;
  }
  
   f.close();
   
   isDeviceConfigured = true;
   
   return true;
}

//Explodes the data string in the places with a certain separator (index starts at 0)
String getValue(String data, char separator, int index)
{
  String finalString = data;
  for(int i = 0; i <= index; ++i){
    int indexOfSeparator = 0;
    if (i == 0) indexOfSeparator = 0;
    else indexOfSeparator = finalString.indexOf(separator);
    int indexOfSeparator2 = finalString.indexOf(';', indexOfSeparator + 1 );
    if(i == index){ finalString = finalString.substring(indexOfSeparator + 1, indexOfSeparator2); break;}
    else{ finalString = finalString.substring(indexOfSeparator2);}
  }
  return finalString;
}

void AuthenticateUser(String message){
  String password = getValue(message, ';', 1);
  String oldPassword = "";
  bool result = SPIFFS.begin();
  
  // this opens the file "f.txt" in read-mode
  File f = SPIFFS.open("/f.txt", "r");
  if(f){
    String text = f.readStringUntil('n');
    oldPassword = getValue(text, ';', 1);
    if(oldPassword == password) Serial.println(DeviceBooleanTResponse);
    else Serial.println(DeviceBooleanFResponse);
  } else {
    Serial.println(DeviceBooleanFResponse);
  }
}

void NeedsUserAuthF(){
    if(IsDeviceConfigured()){
      Serial.println(DeviceBooleanTResponse);
    } else {
      Serial.println(DeviceBooleanFResponse);
    }
}

void TestWifiConnect(String message){
     int firstSeparator = message.indexOf(';');
     int secondSeparator = message.indexOf(';', firstSeparator + 1 );
     char networkName[sizeof(message.substring(firstSeparator + 1, secondSeparator)) + 1];
     (message.substring(firstSeparator + 1, secondSeparator)).toCharArray(networkName, sizeof(networkName));
     char networkPassword[sizeof(message.substring(secondSeparator + 1))];
     (message.substring(secondSeparator + 1)).toCharArray(networkPassword, sizeof(networkPassword));

     WiFi.begin(networkName, networkPassword);
     int tryCounter = 0;
      while (WiFi.status() != WL_CONNECTED)
      {
        delay(500);
        tryCounter++;
        if(tryCounter > 30){ break;}
      }
     if(WiFi.status() == WL_CONNECTED){
         Serial.println(DeviceBooleanTResponse);
     } else {
         Serial.println(DeviceBooleanFResponse);
     }
     WiFi.disconnect();
}

///Gets the available network list
void GetWifiList(){
int n = WiFi.scanNetworks();
  if (n == 0)
    Serial.println("no networks found");
  else
  {

    for (int i = 0; i < n; ++i)
    {
      // Print SSID and RSSI for each network found
      Serial.print(WiFi.SSID(i));
      Serial.print("$");
      Serial.print(WiFi.RSSI(i));
      Serial.print("$");
      if(WiFi.encryptionType(i) == ENC_TYPE_NONE){
         Serial.print(WiFi.encryptionType(i));
      }else{
         Serial.print(" ");
      }
      Serial.print("#");
      delay(10);
    }
  }
  Serial.println("");

  // Wait a bit before scanning again
  delay(100);
}

void Reset(){
  bool result = SPIFFS.begin();
  SPIFFS.remove("/f.txt");
  SPIFFS.format();
  //This forces the data to be loaded again
  //because the LoadConfigData function looks if the networkName
  //is empty to update the variables
  networkName = "";
  isDeviceConfigured = false;
}

//Loop that is called when the device is being configured.
void SetupDevice(){
  while(Serial.available()){
      //The received message
      message = Serial.readString();
      //1º - Is a someONe device
      if (message == AreYouASomeoneDevice) {
        //Returns true
        Serial.println(DeviceBooleanTResponse);
      //2º - Get wifi list
      } else if(message == GiveMeEspNetworkList){
         //Returns a list of the available wifi networks picked up
         //by the WiFi module
          GetWifiList(); 
      //3º - Test the connection to the wifi network
      } else if (message.substring(0, 4) == EspWifiNetworkAuth){
        //Returns true if the device is able to connect to the wifi
        //network successfully.
          TestWifiConnect(message);
      //4º - Checks if the device needs user auth
      } else if (message == NeedsUserAuth){
          NeedsUserAuthF();
      //5º - Authenticates a user
      }else if (message.substring(0, 2) == UserAuth){
        AuthenticateUser(message);
      } else if (message.substring(0, 2) == SaveConfig){
          if(SaveConfigF(message)){          
             Serial.println(DeviceBooleanTResponse);
             break;
          } else {
            Serial.println(DeviceBooleanFResponse);
            break;
          }
      //Reset arduino
      } else if(message == ResetDevice){
        Reset();       
        Serial.println(DeviceBooleanTResponse);
        break;      
      } else {
        Serial.println(DeviceBooleanFResponse);
      }
    }
     digitalWrite(D1, HIGH);   // turn the LED on (HIGH is the voltage level)
     delay(1000);              // wait for a second
     digitalWrite(D1, LOW);    // turn the LED off by making the voltage LOW
     delay(1000); 
}

//The setup (executes once when the device is connected to power or when someone reboots the device)
void setup() {
  //initialize serial communications at 9600 bps
  Serial.begin(9600);
  
  //Check the device to see if it has already been configured
  isDeviceConfigured = IsDeviceConfigured();

  //PIN SETUP

  //D1 - This pin is used to indicate if the device is configured or not; or if the device is connected to
  //the wifi network or not.
  // -> Led Blink - The device is not configured.
  // -> Led permenantly on - The device is not connected to the wifi network and failed to reconnect.
  // -> Led off - Everything is ok.
  pinMode(D1, OUTPUT);
  //A0 - This pin is used to read the state of the sensor.
  // -> PIN HIGH - Then someone is in the room
  // -> PIN LOW - The room is empty
  pinMode(A0, INPUT);

  delay(100);
}

//The loop that is executed continuously after the setup
void loop() {
  //if the device is configured
  if(isDeviceConfigured){
    //while there is no serial available, meaning that the device is not receiving any commands
    //from the configuration program in a computer then execute the "work" loop that checks for 
    //the signal in the sensor and sends it to the assigned url.
    while(!Serial.available()){
       Loop();
    }
    //If a serial message is received then jump to the setup device loop
    SetupDevice();
  } else {
    //if the device is not configured (first time) then go the setup device loop
    SetupDevice();
  }
  delay(100);
}
