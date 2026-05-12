using UnityEngine;

public class choTop: MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer1;
    public static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
            targetSpriteRenderer1.enabled = false;
    }
   void OnMouseDown()
    {
        Debug.Log("sprite clickedd!");
        targetSpriteRenderer1.enabled = true;
    }
}
