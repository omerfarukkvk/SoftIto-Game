namespace _Project.Runtime.Core.Singleton
{
    /* Singletonun amacı oluşturulan objenin her yerden erişmesini sağlamaktır. Bunuda static sayesinde yapıyoruz.
    static obje oluşurken bellekte bir yere işaretlenip sürekli aynı yerde kalmasını sağlamakta. */
    public class SingletonModel<T> where T : new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
    }
}
