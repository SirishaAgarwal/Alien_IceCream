using UnityEngine;
using TMPro; // Required for TextMeshPro

public class UsernameHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public string playerUsername;

    public void SaveName()
    {
        // Capture text from the UI
        playerUsername = inputField.text;

        // Save locally so it persists after closing the game
        PlayerPrefs.SetString("SavedUsername", playerUsername);
        PlayerPrefs.Save();

        Debug.Log("Username saved: " + playerUsername);
    }

    void Start()
    {
        // Load the name if it was previously saved
        if (PlayerPrefs.HasKey("SavedUsername"))
        {
            playerUsername = PlayerPrefs.GetString("SavedUsername");
            inputField.text = playerUsername;
        }
    }
}
