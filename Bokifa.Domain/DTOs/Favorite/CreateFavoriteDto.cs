namespace Bokifa.Domain.DTOs.Favorite
{
    public record CreateFavoriteDto
    {
        public ICollection<Guid> BookIds { get; set; }
    }
}
