﻿using Iot.Device.Bmxx80;
using System;
using System.Device.Gpio;
using System.Device.I2c;
using System.Threading;

int pin = 18;
int lightTime = 1000;
int dimTime = 200;

using GpioController controller = new();
controller.OpenPin(pin, PinMode.Output);
Console.WriteLine($"GPIO pin enabled: {pin}");


//控制二极管
Task.Run(() =>
{
    while (true)
    {
        Console.WriteLine($"Light for {lightTime}ms");
        controller.Write(pin, PinValue.High);
        Thread.Sleep(lightTime);

        Console.WriteLine($"Dim for {dimTime}ms");
        controller.Write(pin, PinValue.Low);
        Thread.Sleep(dimTime);
    }

});

//获取温度
Task.Run(() => 
{
    var busId = 1;

    var deviceAddress = 1;

    var i2cSettings = new I2cConnectionSettings(busId, deviceAddress);

    using var i2cDevice = I2cDevice.Create(i2cSettings);

    var bme280 = new Bme280(i2cDevice);

    int measurementTime = bme280.GetMeasurementDuration();


    while(true)
    {
        Console.Clear();

        

    }

});


Console.Read();

