using UnityEngine;
public class PersistBetweenScenes : MonoBehaviour
{
    public GameObject obj1;
   
    private void Awake()
    {
        DontDestroyOnLoad(obj1);
    }
}
