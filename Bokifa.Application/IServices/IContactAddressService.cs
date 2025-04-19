using Bokifa.Domain.DTOs.ContactAdress;
using Bokifa.Domain.DTOs.NotificationModel;

namespace Bokifa.Application.IServices
{
    public interface IContactAddressService
    {
        Task<ContactAddressDto> GetAsync();
        Task<ContactAddressDto> CreateAsync(CreateContactAddressDto dto);
        Task<ContactAddressDto> UpdateAsync(UpdateContactAddressDto dto);
        Task DeleteAsync(Guid id);
    }
}
