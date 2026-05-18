using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Handles the full order flow:
///   1. "Take Order" button clicked → hide button, show speech bubble with random order
///   2. "Start Order" button clicked → hide bubble, start timer, load next scene
///
/// Attach this to a Manager GameObject in your scene.
/// </summary>
public class OrderManager : MonoBehaviour
{
    // ── Menu Data ─────────────────────────────────────────────────────────────

    private string[] foundations = {
        "Plain Cup", "Cookie Bowl", "Waffle Cone", "Waffle Bowl"
    };

    private string[] flavors = {
        "Nebula Swirl", "Cosmo Crunch", "Plasma Peach", "Lunar Lime",
        "Stardust Berry", "Galaxy Grape", "Meteor Mocha", "Aurora Mint",
        "Solar Sorbet", "Cosmic Caramel", "Hyper Honey", "Zero Vanilla"
    };

    private string[] toppings = {
        "Meteor Bits", "Cosmic Pearls", "Lunar Mallows", "Galaxy Gummies",
        "Comet Crumble", "Alien Ooze", "Orbit Spheres", "Aurora Shards",
        "Wormhole Whip"
    };

    // ── Inspector References ───────────────────────────────────────────────────

    [Header("Buttons")]
    [Tooltip("Your green Take Order button")]
    public GameObject takeOrderButton;

    [Tooltip("The Start Order button inside the speech bubble")]
    public Button startOrderButton;

    [Header("Speech Bubble")]
    [Tooltip("The speech bubble GameObject (hidden by default)")]
    public GameObject speechBubble;

    [Tooltip("TextMeshPro text inside the speech bubble that shows the order")]
    public TextMeshProUGUI orderText;

    [Header("Timer")]
    [Tooltip("Drag your CookTimer script/GameObject here")]
    public CookTimer cookTimer;

    [Header("Scene Transition")]
    [Tooltip("Name of the scene to load when Start Order is clicked. Must match the scene name in Build Settings.")]
    public string nextSceneName = "CookingScene"; // ← change this to your scene name

    [Header("Optional")]
    [Tooltip("Drag your CustomerController here so it walks away when order starts")]
    public CustomerController customerController;

    // ── Internal ───────────────────────────────────────────────────────────────

    void Start()
    {
        if (speechBubble != null)
            speechBubble.SetActive(false);

        if (startOrderButton != null)
            startOrderButton.onClick.AddListener(OnStartOrderClicked);
    }

    // ── Called by Take Order Button (wire this up in Inspector via OnClick) ────

    public void OnTakeOrderClicked()
    {
        GenerateAndDisplayOrder();

        if (takeOrderButton != null)
            takeOrderButton.SetActive(false);

        if (speechBubble != null)
            speechBubble.SetActive(true);
    }

    // ── Order Generation ───────────────────────────────────────────────────────

    void GenerateAndDisplayOrder()
    {
        string foundation = foundations[Random.Range(0, foundations.Length)];

        int flavorCount = Random.Range(1, 4);
        string[] chosenFlavors = GetRandomUnique(flavors, flavorCount);

        int toppingCount = Random.Range(1, 6);
        string[] chosenToppings = GetRandomUnique(toppings, toppingCount);

        if (orderText != null)
        {
            orderText.text =
                $"<b>Foundation:</b> {foundation}\n" +
                $"<b>Flavors:</b> {string.Join(", ", chosenFlavors)}\n" +
                $"<b>Toppings:</b> {string.Join(", ", chosenToppings)}";
        }
    }

    // ── Called by Start Order Button ───────────────────────────────────────────

    void OnStartOrderClicked()
    {
        if (speechBubble != null)
            speechBubble.SetActive(false);

        if (cookTimer != null)
            cookTimer.StartTimer();

        if (customerController != null)
            customerController.CustomerLeave();

        if (!string.IsNullOrEmpty(nextSceneName))
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }

    // ── Helpers ────────────────────────────────────────────────────────────────

    string[] GetRandomUnique(string[] source, int count)
    {
        count = Mathf.Min(count, source.Length);
        string[] shuffled = (string[])source.Clone();

        for (int i = shuffled.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (shuffled[i], shuffled[j]) = (shuffled[j], shuffled[i]);
        }

        string[] result = new string[count];
        System.Array.Copy(shuffled, result, count);
        return result;
    }
}
