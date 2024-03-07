namespace _Project.Runtime.Core.Singleton
{
    /* Singletonun amacı oluşturulan objenin her yerden erişmesini sağlamaktır. Bunuda static sayesinde yapıyoruz.
    static obje oluşurken bellekte bir yere işaretlenip sürekli aynı yerde kalmasını sağlamakta. */
    public class SingletonModel<T> //Generic Class, T tipi herhangi bir tip olabilir string int float veya başka biri sınıf tipi
    {
        private static T _instance;
        public static T Instance
        { 
            get => _instance;
            set => _instance = value;
        }
    }
}
