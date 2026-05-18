using UnityEngine;
using UnityEngine.SceneManagement; // Required for changing scenes

public class SceneChanger : MonoBehaviour
{
    // Function to load scene by Name
    public void MoveToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
