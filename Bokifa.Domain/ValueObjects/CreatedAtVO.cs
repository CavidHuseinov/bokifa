namespace Bookifa.Domain.ValueObjects
{
    public class CreatedAtVO
    {
        public DateTime Date { get; private set; }

        private CreatedAtVO() { }
        public CreatedAtVO(DateTime date)
        {
            Date = date;
        }
        public override string ToString() =>
            (this.Date.Date) switch
            {
                var date when date == DateTime.Today => $"Today {Date:HH:mm}",
                var date when date == DateTime.Today.AddDays(-1) => $"Yesterday {Date:HH:mm}",
                _ => Date.ToString("dd.MM.yyyy HH:mm")
            };
    }
}
