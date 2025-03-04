namespace YuGiOhForbiddenAPI.Model
{
    public abstract class Card
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }

        public virtual void Update(string name, string password, int cost, string description)
        {
            this.Name = name;
            this.Password = password;
            this.Cost = cost;
            this.Description = description;
        }
    }
}
