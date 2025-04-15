namespace Bokifa.Persistance.Repositories
{
    public class FavoriteRepo : CommandRepository<Favorite>, IFavoriteRepo
    {
        public FavoriteRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
