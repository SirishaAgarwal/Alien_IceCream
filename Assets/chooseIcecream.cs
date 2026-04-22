using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class chooseIcecream : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
            targetSpriteRenderer.enabled = false;
    }
    bool wannaShow = true;
   void OnMouseDown()
    {
        Debug.Log("sprite clickedd!");
        if (targetSpriteRenderer != null && count==0)
        {
            targetSpriteRenderer.enabled = true;
            count++;
            // Optional: Toggle it instead (on if off, off if on)
            // targetSpriteRenderer.enabled = !targetSpriteRenderer.enabled;
        }
    }
}
