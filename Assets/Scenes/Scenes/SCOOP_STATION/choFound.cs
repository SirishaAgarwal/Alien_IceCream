using UnityEngine;
public class choFound : MonoBehaviour
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
        if (count==0){
             targetSpriteRenderer1.enabled = true;
        }
        count++;
    }
}
