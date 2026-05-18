using UnityEngine;
public class correctPersistor : MonoBehaviour
{
    public GameObject inputObject;
    void Awake()
    {
        DontDestroyOnLoad(inputObject);
    }
}
