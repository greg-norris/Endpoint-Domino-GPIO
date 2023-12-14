using System.Device.Gpio;
using System.Device.Gpio.Drivers;
using static GHIElectronics.Endpoint.Core.EPM815;

//Domino Header PINs
//5v,PE1,PD3,PD4,PB13,PB12,PD11,PF11,PE0,PD13,PD12,PG0,PH10,PH12,PI4,PB9,PA6,PG9,PD1,3.3v
//GND,PE10,PE9,PF6,PE8,PA5,PF13,PF12,PD15,PA15,PA10,PZ3,PH9,PG10,PE4,PE5,PA13,PA4,PD0,GND

//Mikro BUS Header 1
//PC3,PA12,PZ7,PE12,PE13,PE14,3.3v,GND
//PA3,PZ6,PD6,PF5,PD1,PD0,5V,GND

//Mikro BUS Header 2
//PF14,PF4,PA14,PZ0,PZ1,PZ2,3.3v,GND
//PA0,PF8,PD9,PD8,PB6,PF15,5v,GND

//PH4 mislabeled on Domino REV A should be PZ5


var pinid = Gpio.Pin.PA14;

var gpioDriver = new LibGpiodDriver((int)pinid / 16);
var gpioController = new GpioController(PinNumberingScheme.Logical, gpioDriver);

gpioController.OpenPin(pinid % 16);
gpioController.SetPinMode(pinid % 16, PinMode.Output);

while (true)
{
    gpioController.Write(pinid % 16, PinValue.High);
    Thread.Sleep(100);

    gpioController.Write(pinid % 16, PinValue.Low);
    Thread.Sleep(100);

}