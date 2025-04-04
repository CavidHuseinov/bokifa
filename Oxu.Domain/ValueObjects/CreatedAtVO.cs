namespace Oxu.Domain.ValueObjects
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
                var date when date == DateTime.Today => $"Bugun {Date:HH:mm}",
                var date when date == DateTime.Today.AddDays(-1) => $"Dunen {Date:HH:mm}",
                _ => Date.ToString("dd.MM.yyyy HH:mm")
            };
    }
}
