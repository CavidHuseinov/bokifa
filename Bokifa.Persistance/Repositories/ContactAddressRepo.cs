

namespace Bokifa.Persistance.Repositories
{
    public class ContactAddressRepo : CommandRepository<ContactAddress>, IContactAddressRepo
    {
        public ContactAddressRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
