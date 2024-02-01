namespace taskFelipe.Data.ValueObject
{
    public class FilterVO
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
        
        public int page { get; set; }
    }
}
