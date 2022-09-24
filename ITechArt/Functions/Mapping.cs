namespace ITechArt.Functions
{
    public static class Mapping
    {
        public static Models.ForXML.People GetMapping(List<Models.ForDatabase.Person> list_output)
        {
            List<Models.ForXML.Person> result_all = new List<Models.ForXML.Person>();
            foreach (var output in list_output)
            {
                Models.ForXML.Person result = new Models.ForXML.Person();
                result.Name = output.Name;
                result.Age = output.Age.ToString();

                List<Models.ForXML.Pet> pets = new List<Models.ForXML.Pet>();
                foreach (var pet in output.Pets)
                {
                    Models.ForXML.Pet p = new Models.ForXML.Pet();
                    p.Name = pet.Name;
                    p.Type = pet.Type;
                    pets.Add(p);
                }
                result.Pets = new Models.ForXML.Pets() { Pet = pets };
                result_all.Add(result);
            }
            ITechArt.Models.ForXML.People people = new Models.ForXML.People();
            people.Person = result_all;
            return people;
        }
    }
}
