using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>: MonoBehaviour
    where T: MonoBehaviour
{
    #region Vars

    private static T instance;


    public static T Instance {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    var newInstance = new GameObject("Unnamed singleton", typeof(T));
                }
            }

            return instance;
        }
    }

   
    #endregion
}
