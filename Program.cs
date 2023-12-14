using GHIElectronics.Endpoint.Pins;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;

//Domino Header PINs
//5-v,PE1,PD3,PD4,PB13,PB12,PD11,PF11,PE0,PD13,PD12,PG0,PH10,PH12,PI4,PB9,PA6,PG2,PD1,3.3v
//GND,PE10,PE9,PF6,PE6,PA5,PF13,PF12,PD15,PA15,PA10,PH4,PH9,PG10,PE4,PE5,PA13,PA4,PD0,GND

//No PG2

var pinid = GHIElectronics.Endpoint.Pins.STM32MP1.GpioPin.PD1;

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