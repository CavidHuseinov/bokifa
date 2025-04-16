using Bokifa.Domain.DTOs.ContactAdress;

namespace Bokifa.Application.IServices
{
    public interface IContactAddressService
    {
        Task<ContactAddressDto> GetAsync();
        Task<ContactAddressDto> CreateAsync(CreateContactAddressDto dto);
        Task<ContactAddressDto> UpdateAsync(UpdateContactAddressDto dto);
        Task<bool> SendNotification(CreateContactAddressDto dto);
        Task DeleteAsync(Guid id);
    }
}
