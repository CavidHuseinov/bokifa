namespace Bokifa.Domain.DTOs.Favorite
{
    public record CreateFavoriteDto
    {
        public Guid BookId { get; set; }
    }
}
