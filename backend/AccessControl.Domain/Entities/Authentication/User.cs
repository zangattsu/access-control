namespace AccessControl.Domain.Entities.Authentication
{
    public class User : Entity<User>
    {
        public string Name { get; set; }

        public User(string nome)
        {
            Name = nome;
        }
    }
}