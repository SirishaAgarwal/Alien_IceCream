using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class chooseIcecream : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer;
    public static int count = 0;
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
            targetSpriteRenderer.transform.position += new Vector3(40, -30, 0);
            targetSpriteRenderer.enabled = true;
            count++;
            Debug.Log(count);
            // Optional: Toggle it instead (on if off, off if on)
            // targetSpriteRenderer.enabled = !targetSpriteRenderer.enabled;
        }
        else if (count == 1)
        {
            targetSpriteRenderer.sortingOrder += 1;
            targetSpriteRenderer.transform.position += new Vector3 (40, 10, 0);
            targetSpriteRenderer.enabled = true;
            targetSpriteRenderer.SetActive(false);
            count++;
        }
        else
        {
            targetSpriteRenderer.sortingOrder += 2;
            targetSpriteRenderer.transform.position += new Vector3(40, 50, 0);
            targetSpriteRenderer.enabled = true;
            count++;
            Debug.Log(count);
        }
    }
}
