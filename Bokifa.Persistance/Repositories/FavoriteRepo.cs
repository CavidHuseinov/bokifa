namespace Bokifa.Persistance.Repositories
{
    public class FavoriteRepo : CommandRepository<Favorite>, IFavoriteRepo
    {
        public FavoriteRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
