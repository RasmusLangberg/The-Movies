namespace The_Movies.Model
{
    public class Sal
    {
        public string Name { get; set; }

        public Sal(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Sal skal have et navn.", nameof(name));

            Name = name;
        }

    }
}
