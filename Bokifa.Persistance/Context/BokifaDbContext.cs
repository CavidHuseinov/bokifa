namespace Bookifa.Persistance.Context
{
    public sealed class BokifaDbContext : IdentityDbContext<AppUser>
    {
        public BokifaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<HeadBanner> HeadBanners { get; set; }
        public DbSet<THeadBanner> THeadBanners { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<TBanner> TBanners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAndCategory> BookAndCategories { get; set; }
        public DbSet<TBook> TBooks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TTag> TTags {  get; set; }
        public DbSet<BookAndTag> BookAndTags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<TVariant> TVariants { get; set; }
        public DbSet<BookAndVariant> BookAndVariants { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TBlog> TBlogs { get; set; }
        public DbSet<BlogAndTag> BlogAndTags { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
