namespace YuGiOhForbiddenAPI.Model
{
    public abstract class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public virtual int? Atk { get; protected set; } = null;
        public virtual int? Def { get; protected set; } = null;

    }
}
