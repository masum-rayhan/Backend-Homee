using Homee.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.DataAccess.Utils;

public static class DeviceTypeService
{
    public static (string StateType, bool State, string Value) GetInitialDeviceState(DeviceType deviceType)
    {
        string stateType = string.Empty;
        bool state = false;
        string value = string.Empty;

        switch (deviceType)
        {
            case DeviceType.Light:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.Thermostat:
                stateType = "Temperature";
                state = true;
                value = "72°F";
                break;
            case DeviceType.Camera:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.DoorLock:
                stateType = "Lock";
                state = false;
                value = "Unlocked";
                break;
            case DeviceType.SmartPlug:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.SmartSwitch:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.WindowBlindsShades:
                stateType = "Position";
                state = false;
                value = "Closed";
                break;
            case DeviceType.CeilingFan:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.AirConditioner:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.Refrigerator:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.Oven:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.Microwave:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.Dishwasher:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.WashingMachine:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.Dryer:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.GarageDoorOpener:
                stateType = "Door";
                state = false;
                value = "Closed";
                break;
            case DeviceType.SmokeDetector:
                stateType = "Smoke";
                state = false;
                value = "Not Triggered";
                break;
            case DeviceType.CarbonMonoxideDetector:
                stateType = "Carbon Monoxide";
                state = false;
                value = "Not Triggered";
                break;
            case DeviceType.MotionSensor:
                stateType = "Motion";
                state = false;
                value = "Not Detected";
                break;
            case DeviceType.ContactSensor:
                stateType = "Contact";
                state = false;
                value = "No Contact";
                break;
            case DeviceType.WaterLeakSensor:
                stateType = "Water Leak";
                state = false;
                value = "No Leak";
                break;
            case DeviceType.SmartSpeaker:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.SmartDisplay:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.SmartAlarmClock:
                stateType = "Power";
                state = false;
                value = "0";
                break;
            case DeviceType.SmartMirror:
                stateType = "Power";
                state = false;
                value = "0";
                break;
        }

        return (stateType, state, value);
    }
}
