namespace Bokifa.Domain.DTOs.Book
{
    public record UpdateBookDto
    {
        public Guid Id { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public bool InStock { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public ICollection<Guid> CategoryIds { get; set; }
        public ICollection<Guid>? TagIds { get; set; }
        public ICollection<Guid>? VariantIds { get; set; }

    }
}
