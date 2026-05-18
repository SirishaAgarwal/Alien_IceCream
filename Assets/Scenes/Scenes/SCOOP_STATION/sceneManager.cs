using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
   public static void LoadNextLevel()
    {
        Debug.Log("scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
