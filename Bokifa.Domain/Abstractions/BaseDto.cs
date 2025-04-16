namespace Bookifa.Domain.Abstractions
{
    public abstract record BaseDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedAt { get; set; }
    }
}
