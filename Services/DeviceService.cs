using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityID.Interfaces;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly MyDataContext database;
        private readonly IUpdateHelper updateHelper;

        public DeviceService(MyDataContext database, IUpdateHelper updateHelper)
        {
            this.updateHelper = updateHelper;
            this.database = database;
        }

        public async Task<Device> AddDevice(Device newDevice)
        {
            await database.Device.AddAsync(newDevice);
            await database.SaveChangesAsync();

            return newDevice;
        }

        public async Task DeleteDevice(int DeviceId)
        {
            var deletingDeviceDescription =
             await database.Device.FirstOrDefaultAsync(p => p.Id == DeviceId);

            if (deletingDeviceDescription is null)
                throw new System.Exception("No proper place found");

            database.Device.Remove(deletingDeviceDescription);
            await database.SaveChangesAsync();

        }

        public async Task<Device> UpdateDevice(DeviceDto deviceDto, int deviceId)
        {
            var updatedAdministrator = await updateHelper.updateEntity<Device, DeviceDto>(deviceDto, deviceId);
            return updatedAdministrator;
        }
    }
}