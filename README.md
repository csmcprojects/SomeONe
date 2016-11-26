# SomeONe v1.0.0
A simple system that allows with the turn of a switch and less than 2 minutes to setup tell the world if is someone there or not. Where? In a club, in the toilet, the options are endless.

# How to use

1. Mount the required circuit.

2. Deploy the setup program
It will require a windows platform to run and the apropriate dependencies. If requested I may add an instaler for the program, but for now you may run the code and generate your own release version of the software.

3. Follow the steps to configure the program

4. Voilá! It should be working now and sending data to the server when the state changes.

Check the wiki for more detailed instructions.

# Hardware

This project was done with an Wemos D2 mini board and the signaling of a person in the room was done manually with a switch that must be turned on and off when a person enters or leaves the room, respectivly.

You can use different methods to signal the presence of a person in the room. A simple but functional idea is the use of an infrared detector and a transistor connected in the place of the switch. 

The only requirement is that the circuit is closed, what closes the circuit can be anything you want. In the future more analog circuits and versions may be added, or you can fork the project and add your own versions.

Check the wiki for more detailed information.

# Software

In order to configure the device a c# program was developed. The program was only tested in windows environment, but it may work in linux using the mono project, but I'm not sure of that.

# Comming soon

1. 3D printer case for storing the wemos board and analog circuit using a simple switch as the detection method.
2. Expansion of the current system to allow for the use of RFID cards and user log.


