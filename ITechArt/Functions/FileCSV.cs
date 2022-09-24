using ITechArt.Models.ForDatabase;

namespace ITechArt.Functions
{
    public interface IFileCSV
    {
        List<Person> GetValue();
    }
    public class FileCSV : IFileCSV
    {
        private readonly IConfiguration config;

        public FileCSV(IConfiguration _config)
        {
            config = _config;
        }
        public List<Person> GetValue()
        {
            List<Person> persons = new List<Person>();
            string filePath = config["Location:FileCSV"];
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Person person = new Person();
                    person.Name = Values.GetString(values[0]);
                    person.Age = Values.GetInt(values[1]);
                    List<Pet> pets = new List<Pet>();
                    for (int i = 3; i < values.Length; i += 2)
                    {
                        if (Values.GetString(values[i - 1]) is not null || Values.GetString(values[i]) is not null)
                        {
                            Pet pet = new Pet();
                            pet.Name = Values.GetString(values[i - 1]);
                            pet.Type = Values.GetString(values[i]);
                            pets.Add(pet);
                        }
                    }
                    person.Pets = pets;
                    persons.Add(person);
                }
            }
            persons.RemoveAt(0);
            return persons;
        }
    }
}