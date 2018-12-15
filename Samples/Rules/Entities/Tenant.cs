namespace Rules.Entities
{
    public class Tenant
    {
        private static Tenant _user;
        public static Tenant Current
        {
            get
            {
                if (_user == null)
                    _user = new Tenant();
                return _user;
            }
        }

        public CalcDirection Direction { get; set; }
    }
}