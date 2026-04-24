using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalClickCounter : MonoBehaviour
{
    // Static allows access from any other script
    public static int totalClicks = 0;

    void Awake()
    {
        // Keeps this object alive across scene changes
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Detects left mouse click (0) anywhere in the game window
        if (Input.GetMouseButtonDown(0))
        {
            totalClicks++;
            Debug.Log("Total Clicks: " + totalClicks);
        }
    }
}
