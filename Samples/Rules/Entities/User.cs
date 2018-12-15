using BFsharp;

namespace Rules.Entities
{
    public class User : EntityBase<User>
    {
        private static User _user;
        public static User Current
        {
            get
            {
                if (_user == null)
                    _user = new User {Discount=0.9m};
                return _user;
            }
        }

        public decimal Discount { get; set; }
    }
}