namespace ITechArt.Models.ForDatabase
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
