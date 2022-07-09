using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour
{
    #region Properties

    public static T Instance { get; private set; }

    #endregion


    #region Unity lifecycle

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }

    #endregion
}