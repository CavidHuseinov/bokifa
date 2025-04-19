using Bokifa.Domain.DTOs.ContactAdress;
using Bokifa.Domain.DTOs.NotificationModel;
using Bookifa.Domain.DTOs.User;
using Bookifa.Domain.ValueObjects;

public class ContactAddressService : IContactAddressService
{
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _user;
    private readonly IHttpContextAccessor _http;
    private readonly IEmailService _emailService;
    private readonly IContactAddressRepo _command;
    private readonly INotificationModelRepo _not;
    private readonly IQueryRepository<ContactAddress> _query;
    private readonly IUnitOfWork _work;

    public ContactAddressService(
        IMapper mapper,
        UserManager<AppUser> user,
        IHttpContextAccessor http,
        IEmailService emailService,
        IQueryRepository<ContactAddress> query,
        IContactAddressRepo command,
        IUnitOfWork work,
        INotificationModelRepo not)
    {
        _mapper = mapper;
        _user = user;
        _http = http;
        _emailService = emailService;
        _query = query;
        _command = command;
        _work = work;
        _not = not;
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

        var contact = _mapper.Map<ContactAddress>(dto);
        contact.AppUserId = user.Id;
        contact.IsConfirmed = false;
        contact.CreatedAt = new CreatedAtVO(DateTime.UtcNow);
        if (dto.SendNotification==true)
        {
            var notification = new CreateNotificationModelDto
            {
                Email = user.Email
            };
            await _not.CreateAsync(_mapper.Map<NotificationModel>(notification));
            await _work.SaveChangeAsync();
        }

        await _command.CreateAsync(contact);
        await _work.SaveChangeAsync();

        return _mapper.Map<ContactAddressDto>(contact);
    }

    public async Task<ContactAddressDto> GetAsync()
    {
        var user = await GetCurrentUserAsync();

        var contact = await _query.GetAsync(x => x.AppUserId == user.Id);
        if (contact == null) throw new Exception("Contact not found");

        var data = _mapper.Map<ContactAddressDto>(contact);
        data.Email = user.Email;
        return data;
    }
    public async Task<ContactAddressDto> UpdateAsync(UpdateContactAddressDto dto)
    {
        var user = await GetCurrentUserAsync();

        var contact = await _query.GetAsync(x => x.AppUserId == user.Id);
        if (contact == null) throw new Exception("Contact not found");

        contact = _mapper.Map(dto, contact); 

        contact.IsConfirmed = false;
        contact.ConfirmedAt = null;

        await _command.UpdateAsync(contact);
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
