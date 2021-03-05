namespace VS.Task.Data.Entities
{
    public class Provider
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long GroupId { get; set; }

        public Group Group { get; set; }
    }
}
