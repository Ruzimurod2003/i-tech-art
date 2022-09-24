using ITechArt.Models.ForDatabase;
using Sylvan.Data.Excel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Text;

namespace ITechArt.Functions
{
    public interface IFileXLSX
    {
        List<Person> GetValue();
    }
    public class FileXLSX: IFileXLSX
    {
        private readonly IConfiguration config;

        public FileXLSX(IConfiguration _config)
        {
            config = _config;
        }
        public List<Person> GetValue()
        {
            string filePath = config["Location:FileXLSX"];
            using ExcelDataReader edr = ExcelDataReader.Create(filePath);
            List<Person> persons = new List<Person>();

            do
            {
                var sheetName = edr.WorksheetName;
                while (edr.Read())
                {
                    Person person = new Person();
                    person.Name = Values.GetString(edr.GetString(0));
                    person.Age = Values.GetInt(edr.GetString(1));
                    List<Pet> pets = new List<Pet>();
                    for (int i = 3; i < edr.FieldCount; i += 2)
                    {
                        if (Values.GetString(edr.GetString(i - 1)) is not null || Values.GetString(edr.GetString(i)) is not null)
                        {
                            Pet pet = new Pet();
                            pet.Name = Values.GetString(edr.GetString(i - 1));
                            pet.Type = Values.GetString(edr.GetString(i));
                            pets.Add(pet);
                        }

                    }
                    person.Pets = pets;
                    persons.Add(person);
                }
            } while (edr.NextResult());
            return persons;
        }
    }
}
