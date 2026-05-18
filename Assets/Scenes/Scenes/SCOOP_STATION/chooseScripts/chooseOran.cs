using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class chooseOran : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer1;
    public SpriteRenderer targetSpriteRenderer2;
    public SpriteRenderer targetSpriteRenderer3;
    public static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
            targetSpriteRenderer1.enabled = false;
            targetSpriteRenderer2.enabled = false;
            targetSpriteRenderer3.enabled = false;
    }
   void OnMouseDown()
    {
        Debug.Log("sprite clickedd!");
        if (GlobalClickCounter.totalClicks==24)
        {
            targetSpriteRenderer1.enabled = true;
            count++;
            Debug.Log(count);
        }
        else if (GlobalClickCounter.totalClicks==36)
        {
            targetSpriteRenderer2.enabled = true;
            count++;
        }
        else if (GlobalClickCounter.totalClicks==48)
        {
            targetSpriteRenderer3.enabled = true;
            count++;
            Debug.Log(count);
        }
    }
}