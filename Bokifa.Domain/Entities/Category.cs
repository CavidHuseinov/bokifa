﻿namespace Bokifa.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public PrimaryLanguageType PrimaryLanguageType { get; set; } = PrimaryLanguageType.Eng;
        public ICollection<TCategory>? TCategories { get; set; }
        public ICollection<BookAndCategory>? BookAndCategories { get; set; }

    }
}
