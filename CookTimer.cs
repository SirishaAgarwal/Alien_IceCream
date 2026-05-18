using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

/// <summary>
/// Countdown timer shown in the top-right corner.
/// When time runs out: shows a "Time's Up!" overlay, then loads a scene of your choice.
/// Call StartTimer() to begin.
/// </summary>
public class CookTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    [Tooltip("Total cook time in seconds (300 = 5 minutes)")]
    public float totalTime = 300f;

    [Tooltip("How long to show the 'Time Ran Out' screen before transitioning (seconds)")]
    public float timeOutDisplayDuration = 2.5f;

    [Header("Timer UI")]
    [Tooltip("TextMeshPro text that displays the countdown (e.g. 04:59)")]
    public TextMeshProUGUI timerText;

    [Tooltip("The timer panel/container to show/hide")]
    public GameObject timerPanel;

    [Header("Time's Up Screen")]
    [Tooltip("A full-screen overlay panel that says 'Time Ran Out!' — hidden by default")]
    public GameObject timeUpPanel;

    [Tooltip("Optional: TextMeshPro inside the Time's Up panel if you want to customize the message")]
    public TextMeshProUGUI timeUpText;

    [Header("Scene Transition")]
    [Tooltip("Name of the scene to load when time runs out. Must be in Build Settings.")]
    public string timeOutSceneName = "MainScene"; // ← set this in Inspector

    private float timeRemaining;
    private bool isRunning = false;

    void Start()
    {
        timeRemaining = totalTime;

        if (timerPanel != null)
            timerPanel.SetActive(false);

        if (timeUpPanel != null)
            timeUpPanel.SetActive(false);

        UpdateDisplay();
    }

    void Update()
    {
        if (!isRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            isRunning = false;
            UpdateDisplay();
            OnTimerFinished();
        }
        else
        {
            UpdateDisplay();
        }
    }

    /// <summary>Call this to start (or restart) the timer.</summary>
    public void StartTimer()
    {
        timeRemaining = totalTime;
        isRunning = true;

        if (timerPanel != null)
            timerPanel.SetActive(true);

        if (timeUpPanel != null)
            timeUpPanel.SetActive(false);

        Debug.Log("Cook timer started!");
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    void UpdateDisplay()
    {
        if (timerText == null) return;

        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";

        // Turn red in the last 30 seconds
        timerText.color = timeRemaining <= 30f ? Color.red : Color.white;
    }

    void OnTimerFinished()
    {
        Debug.Log("Time's up!");

        // Hide the timer
        if (timerPanel != null)
            timerPanel.SetActive(false);

        // Show the "Time Ran Out" overlay
        if (timeUpPanel != null)
        {
            timeUpPanel.SetActive(true);

            if (timeUpText != null)
                timeUpText.text = "Time Ran Out!";
        }

        // Wait, then go to the chosen scene
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(timeOutDisplayDuration);

        if (!string.IsNullOrEmpty(timeOutSceneName))
            UnityEngine.SceneManagement.SceneManager.LoadScene(timeOutSceneName);
        else
            Debug.LogWarning("CookTimer: No timeOutSceneName set! Please set it in the Inspector.");
    }
}
