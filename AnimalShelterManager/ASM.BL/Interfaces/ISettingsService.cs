using ASM.Data;

namespace ASM.BL.Interfaces
{
    public interface ISettingsService
    {
        Settings GetSettings();
        Settings Update(Settings settings);
    }
}
