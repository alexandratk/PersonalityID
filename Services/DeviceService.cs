using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class DeviceService: IDeviceService
    {
        private readonly MyDataContext database;

        public DeviceService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Device> AddDevice(Device newDevice)
        {
            await database.Device.AddAsync(newDevice);
            await database.SaveChangesAsync();

            return newDevice;
        }
    }
}