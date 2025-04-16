using Bokifa.Domain.DTOs.ContactAdress;
using Bookifa.Domain.DTOs.User;
using Bookifa.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Bokifa.Persistance.Services
{
    public class ContactAddressService : IContactAddressService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _user;
        private readonly IHttpContextAccessor _http;
        private readonly IEmailService _emailService;
        private readonly IContactAddressRepo _command;
        private readonly IQueryRepository<ContactAddress> _query;
        private readonly IUnitOfWork _work;

        public ContactAddressService(
            IMapper mapper,
            UserManager<AppUser> user,
            IHttpContextAccessor http,
            IEmailService emailService,
            IQueryRepository<ContactAddress> query,
            IContactAddressRepo command,
            IUnitOfWork work)
        {
            _mapper = mapper;
            _user = user;
            _http = http;
            _emailService = emailService;
            _query = query;
            _command = command;
            _work = work;
        }
        private async Task<AppUser> GetCurrentUserAsync()
        {
            var userId = _user.GetUserId(_http.HttpContext.User);
            if (userId == null) throw new Exception("User not found");
            return await _user.FindByIdAsync(userId);
        }
        public async Task<ContactAddressDto> CreateAsync(CreateContactAddressDto dto)
        {
            var user = await GetCurrentUserAsync();

            var existing = await _query.GetAsync(x => x.AppUserId == user.Id);
            if (existing != null) throw new Exception("Contact already exists");


            var contact = new ContactAddress
            {
                PhoneNumber = dto.PhoneNumber,
                AppUserId = user.Id,
                IsConfirmed = false,
                CreatedAt = new CreatedAtVO(DateTime.Now)
            };

            await _command.CreateAsync(contact);
            await _work.SaveChangeAsync();

            return _mapper.Map<ContactAddressDto>(contact);
        }

        public async Task<ContactAddressDto> GetAsync()
        {
            var user = await GetCurrentUserAsync();

            var contact = await _query.GetAsync(x => x.AppUserId == user.Id);
            if (contact == null) throw new Exception("Contact not found");

            var data = new ContactAddressDto
            {
                PhoneNumber = contact.PhoneNumber,
                IsConfirmed = contact.IsConfirmed,
                ConfirmedAt = contact.ConfirmedAt,
                Email = user.Email
            };
            return data;
        }

        public async Task<bool> SendNotification(CreateContactAddressDto dto)
        {
            if (dto.SendNotification)
            {
                if (_user == null || _user.Users == null)
                {
                    throw new Exception("Xetaaaaa");
                }
                var users = _user.Users.ToList();
                foreach (var user in users)
                {
                    var data = new UserDto
                    {
                        Name = user.Name,
                        Surname = user.Surname,
                        Email = user.Email
                    };
                    var emailLists = new List<string>
                    {
                        data.Email
                    };
                    string subject = "A new book has been added";
                    string body = $"A new book has been added! Don't miss the chance to grab it, {data.Name} {data.Surname}";

                    await _emailService.SendEmailsAsync(emailLists, subject, body);
                }

                return true;
            }
            return false;
        }

        public async Task<ContactAddressDto> UpdateAsync(UpdateContactAddressDto dto)
        {
            var user = await GetCurrentUserAsync();

            var contact = await _query.GetAsync(x => x.AppUserId == user.Id);
            if (contact == null) throw new Exception("Contact not found");

            contact.PhoneNumber = dto.NewPhoneNumber;
            contact.IsConfirmed = false;
            contact.ConfirmedAt = null;

            _command.UpdateAsync(contact);
            await _work.SaveChangeAsync();

            return _mapper.Map<ContactAddressDto>(contact);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetCurrentUserAsync();
            var contact = await _query.GetAsync(x => x.AppUserId == user.Id);
            if (contact == null) throw new Exception("Contact not found");
            await _command.DeleteAsync(contact);
            await _work.SaveChangeAsync();
        }
    }
}
