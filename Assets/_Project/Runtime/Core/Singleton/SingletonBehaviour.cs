using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Singletonun amacı oluşturulan objenin her yerden erişmesini sağlamaktır. Bunuda static sayesinde yapıyoruz.
static obje oluşurken bellekte bir yere işaretlenip sürekli aynı yerde kalmasını sağlamakta.

where T : MonoBehaviour un amacı T tipi sadece MonoBehaviour ve onun miras verdiği objeler olmak zorunda Transform, Vector3 vb.
*/
public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public T Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            
            /* T türündeki nesneleri sahnedeki tüm nesneler arasında arar. belirtilen türdeki tüm aktif nesneleri döndürür. T tipindeki tüm nesneleri döndürür
            'is' anahtar kelimesi, bir nesnenin belirli bir türe uyup uymadığını kontrol eder. Eğer T tipindeki bir array varsa if e girer.
            Sahnede bulduğu nesneden sadece 1 tane varsa onu geri göndürür. */
            if (FindObjectsOfType(typeof(T)) is T[] managers && managers.Length != 0)
            {
                if (managers.Length == 1)
                {
                    return _instance = managers[0];
                }
            }

            // yoksa yeni bir gameobject oluşturup geri döndürür
            var o = new GameObject(typeof(T).Name, typeof(T));
            _instance = o.GetComponent<T>();
            
            return _instance;
        }
    }

}
