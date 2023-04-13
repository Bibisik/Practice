using UnityEngine;

public class SoundsNoDestroy : MonoBehaviour
{
    private static SoundsNoDestroy instance;

    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
