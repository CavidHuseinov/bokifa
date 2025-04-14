using Bokifa.Domain.DTOs.ContactAdress;

namespace Bokifa.Application.IServices
{
    public interface IContactAddressService
    {
        Task<ContactAddressDto> GetContactAddressAsync();
        Task<bool> SendNotification(CreateContactAddressDto dto);
    }
}
