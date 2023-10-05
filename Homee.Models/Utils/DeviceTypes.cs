using System;
using System.ComponentModel.DataAnnotations;

namespace Homee.Models.Utils
{
    public enum DeviceType
    {
        [Display(Name = "Light")]
        Light,

        [Display(Name = "Thermostat")]
        Thermostat,

        [Display(Name = "Camera")]
        Camera,

        [Display(Name = "Door Lock")]
        DoorLock,

        [Display(Name = "Smart Plug")]
        SmartPlug,

        [Display(Name = "Smart Switch")]
        SmartSwitch,

        [Display(Name = "Window Blinds/Shades")]
        WindowBlindsShades,

        [Display(Name = "Ceiling Fan")]
        CeilingFan,

        [Display(Name = "Air Conditioner")]
        AirConditioner,

        [Display(Name = "Refrigerator")]
        Refrigerator,

        [Display(Name = "Oven")]
        Oven,

        [Display(Name = "Microwave")]
        Microwave,

        [Display(Name = "Dishwasher")]
        Dishwasher,

        [Display(Name = "Washing Machine")]
        WashingMachine,

        [Display(Name = "Dryer")]
        Dryer,

        [Display(Name = "Garage Door Opener")]
        GarageDoorOpener,

        [Display(Name = "Smoke Detector")]
        SmokeDetector,

        [Display(Name = "Carbon Monoxide Detector")]
        CarbonMonoxideDetector,

        [Display(Name = "Motion Sensor")]
        MotionSensor,

        [Display(Name = "Contact Sensor")]
        ContactSensor,

        [Display(Name = "Water Leak Sensor")]
        WaterLeakSensor,

        [Display(Name = "Smart Speaker")]
        SmartSpeaker,

        [Display(Name = "Smart Display")]
        SmartDisplay,

        [Display(Name = "Smart Alarm Clock")]
        SmartAlarmClock,

        [Display(Name = "Smart Mirror")]
        SmartMirror
    }
}
