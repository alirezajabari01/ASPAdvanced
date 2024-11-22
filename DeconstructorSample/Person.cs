namespace DeconstructorSample
{
    public class Person
    {
        public int Id { get; set; } = 3;
        public string Name { get; set; } = "Tahere";

        public void Deconstruct(out int id)
        {
            id = Id;
        }

        public void Deconstruct(out int id, out string name)
        {
            id = Id;
            name = Name;
        }
    }
}
