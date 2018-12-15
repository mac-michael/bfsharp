namespace BFsharp.Samples.SL.Samples
{
    public class MyEntityBase<T> where T : MyEntityBase<T>
    {
        private IEntityExtensions<T> _extensions;
        public IEntityExtensions<T> Extensions
        {
            get
            {
                if (_extensions == null)
                    _extensions = EntityExtensions.RegisterObject(this).GetTypeSafe<T>();

                return _extensions;
            }
        }
    }
}