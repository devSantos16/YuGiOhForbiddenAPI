using YuGiOhForbiddenAPI.Model;

namespace YuGiOhForbiddenAPI.Entities
{
    public class Monster : Card
    {
        private int? _atk;
        public override int? Atk 
        {
            get 
            {
                return this._atk;
            }

            protected set
            {
                this._atk = value ?? 0;
            } 
        }
    }
}
