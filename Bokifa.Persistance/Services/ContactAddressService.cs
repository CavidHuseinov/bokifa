using Bokifa.Domain.DTOs.ContactAdress;
using Bookifa.Domain.DTOs.User;

namespace Bokifa.Persistance.Services
{
    public class ContactAddressService : IContactAddressService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _user;
        private readonly IHttpContextAccessor _http;
        private readonly IEmailService _emailService;

        public ContactAddressService(
            IMapper mapper,
            UserManager<AppUser> user,
            IHttpContextAccessor http,
            IEmailService emailService)
        {
            _mapper = mapper;
            _user = user;
            _http = http;
            _emailService = emailService;
        }
        public async Task<ContactAddressDto> GetContactAddressAsync()
        {
            var userId = _user.GetUserId( _http.HttpContext?.User);
            if (userId == null)
            {   
                throw new UnauthorizedAccessException("User not found");
            }
            var user = await _user.FindByIdAsync(userId);

            var data = new UserDto
            {
                Email = user.Email,  
                PhoneNumber = user.PhoneNumber 
            };

            var contactAddressDto = new ContactAddressDto
            {
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };
            return contactAddressDto;
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


    }
}
