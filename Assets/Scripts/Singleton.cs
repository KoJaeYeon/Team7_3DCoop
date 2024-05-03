using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            //�ν��Ͻ��� null�̸�
            if(instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if(instance == null )
                {
                    GameObject singtonObject = new GameObject();
                    instance = singtonObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }
}
