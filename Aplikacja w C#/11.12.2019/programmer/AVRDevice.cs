using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kucia.sprog.Programmer
{

    public class AVRDevice
    {
        public string Name;
        public int FlashSize;
        public int EEPROMSize;
        public int FlashPageSize;
        public int EEPROMPageSize;
        public int FlashPages;
        public int EEPROMPages;
        public byte ManufacterID;
        public byte MemoryID;
        public byte DeviceID;

        public AVRDevice(string name, int flashSize, int eepromSize, int flashPageSize, int eepromPageSize, byte manufacterId, byte memoryID, byte deviceID)
        {
            this.Name = name;
            this.FlashSize = flashSize;
            this.FlashPageSize = flashPageSize;
            this.FlashPages = this.FlashSize / this.FlashPageSize;
            this.EEPROMSize = eepromSize;
            this.EEPROMPageSize = eepromPageSize;
            this.EEPROMPages = this.EEPROMSize / this.EEPROMPageSize;
            this.ManufacterID = manufacterId;
            this.MemoryID = memoryID;
            this.DeviceID = deviceID;
        }
    }

    public class AVRDevices
    {
        public static AVRDevice AtMega8 = new AVRDevice("AtMega8", 8 * 1024, 512, 64, 8, 0x1E, 0x93, 0x07);
        public static AVRDevice AtMega32 = new AVRDevice("AtMega32", 32 * 1024, 1024, 128, 8, 0x1E, 0x95, 0x02);
    }

}
