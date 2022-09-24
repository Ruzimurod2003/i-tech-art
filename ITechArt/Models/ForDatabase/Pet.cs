namespace ITechArt.Models.ForDatabase
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
