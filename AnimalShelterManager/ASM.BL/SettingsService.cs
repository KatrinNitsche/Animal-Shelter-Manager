using ASM.Data;
using System;

namespace ASM.BL
{
    public class SettingsService
    {
        public Settings GetSettings()
        {
            return new Settings() { Title = "Your Animal Shelter" };
           
        }
    }
}
