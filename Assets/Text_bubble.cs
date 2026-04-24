using UnityEngine;
using UnityEngine.UI;

public class ButtonImageChanger : MonoBehaviour
{
    public Button myButton;
    public Sprite newSprite; // Use Sprite for the image file

    public void ChangeButtonImage()
    {
        // Access the sprite property of the button's image component
        myButton.image.sprite = newSprite;
    }
}
