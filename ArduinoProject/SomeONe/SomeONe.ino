#include "ESP8266WiFi.h"
#include "FS.h"

//Responses and Messages
String DeviceBooleanTResponse = "DBTR";
String DeviceBooleanFResponse = "DBFR";

//CONFIGURATION PHASE WORDS

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


//The message received from the computer
String message;

//Flags
bool isDeviceConfigured = false;
bool deviceNeedsAuth = false;

void setup() {
  //initialize serial communications at 9600 bps:
  Serial.begin(9600);

  //check the device to see if it was already configured
  isDeviceConfigured = IsDeviceConfigured();
  
  delay(100);
}

bool IsDeviceConfigured(){
  // always use this to "mount" the filesystem
  bool result = SPIFFS.begin();
  Serial.println("SPIFFS opened: " + result);

  // this opens the file "f.txt" in read-mode
  File f = SPIFFS.open("/f.txt", "r");
  
  //if the file opens it exists and it means that the device was configured -> returns true, else false.
  return f;
  
  f.close();
}

void loop() {
  if(IsDeviceConfigured == false){
    SetupDevice();
  } else {
    Loop();
  }
  delay(100);
}

void SetupDevice(){
  while(true){
    if (Serial.available()) {  
      message = Serial.readString();

      //1º - Is a someONe device
      if (message == AreYouASomeoneDevice) {
        Serial.println(DeviceBooleanTResponse);
      //2º - Get wifi list from device
      } else if(message == GiveMeEspNetworkList){
          GetWifiList(); 
      //3º - Test the connection to the wifi network
      } else if (message.substring(0, 4) == EspWifiNetworkAuth){
          TestWifiConnect(message);
      //4º - Checks if the device needs user auth
      } else if (message == NeedsUserAuth){
          NeedsUserAuthF();
      } else if (message.substring(0, 2) == SaveConfig){
          if(SaveConfigF(message)){
             break;
          }        
      } else {
        Serial.println(DeviceBooleanFResponse);
      }
    }
  }
}

void Loop(){
  
}

void SaveConfigF(String message){
  bool result = SPIFFS.begin();
  Serial.println("SPIFFS opened: " + result);

  // this opens the file "f.txt" in read-mode
  File f = SPIFFS.open("/f.txt", "w");
  
  if(f){
    //device username
    f.println(getValue(message, ';', 1));
    //device password
    f.println(getValue(message, ';', 2));
    //wifi network name
    f.println(getValue(message, ';', 3));
    //wifi netowork password
    f.println(getValue(message, ';', 4));
    //server url
    f.println(getValue(message, ';', 5));
  } else {
    Serial.println(DeviceBooleanFResponse);
    return false;
  }
  
   f.close();

   Serial.println(DeviceBooleanTResponse);
   IsDeviceConfigured = true;
   deviceNeedsAuth = true;
   
   return true;
}

//Explodes the data string in the places with a certain separator
String getValue(String data, char separator, int index)
{
  String finalString = "";
  for(int i = 0; i <= index; ++i){
    int indexOfSeparator = data.indexOf(separator);
    int indexOfSeparator2 = data.indexOf(';', firstSeparator + 1 );
    finalString = data.substring(indexOfSeparator + 1, indexOfSeparator2);
  }
}

void NeedsUserAuthF(){
    if(deviceNeedsAuth){
      Serial.println(DeviceBooleanFResponse);
    } else {
      Serial.println(DeviceBooleanTResponse);
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
        if(tryCounter > 50){ break;}
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

