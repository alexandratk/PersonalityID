using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Itrefaces
{
    public interface IDeviceService
    {
        Task<Device> AddDevice(Device newDevice);
        Task<Device> UpdateDevice(DeviceDto deviceDto, int deviceId);
        Task DeleteDevice(int deviceId);
    }
}