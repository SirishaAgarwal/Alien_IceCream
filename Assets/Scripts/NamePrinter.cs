using UnityEngine;
using TMPro; // Or UnityEngine.UI if using standard InputField

public class NameLoader : MonoBehaviour
{
    // Drag your Output Field (Input Field component) here in the inspector
    public TMP_InputField usernameOutput;

    void Start()
    {
        // Load the string with the same key "Username"
        if (PlayerPrefs.HasKey("SavedUsername"))
        {
            string loadedName = PlayerPrefs.GetString("SavedUsername");
            usernameOutput.text = loadedName;
        }
    }
}
