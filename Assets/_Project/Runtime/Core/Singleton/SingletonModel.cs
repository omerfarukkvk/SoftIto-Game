namespace _Project.Runtime.Core.Singleton
{
    public class SingletonModel<T>
    {
       private static T _instance;

        public static T Instance
        { 
            get => _instance;
            set => _instance = value;
        }
    }
}
