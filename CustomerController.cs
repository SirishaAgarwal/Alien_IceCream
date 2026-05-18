using UnityEngine;
using System.Collections;

/// <summary>
/// Moves the customer sprite from a start position to a stop position.
/// When the customer arrives, shows the Take Order button.
/// Supports auto-restart: when the scene reloads, a new customer walks in automatically.
/// Attach this to your Customer GameObject.
/// </summary>
public class CustomerController : MonoBehaviour
{
    [Header("Walk Settings")]
    [Tooltip("Where the customer starts (off-screen left) — adjust freely in Inspector")]
    public Vector3 startPosition = new Vector3(-10f, -2f, 0f);

    [Tooltip("Where the customer stops in front of the counter — adjust freely in Inspector")]
    public Vector3 stopPosition = new Vector3(-1f, -2f, 0f);

    [Tooltip("How fast the customer walks")]
    public float walkSpeed = 3f;

    [Tooltip("Delay (seconds) before the next customer walks in after scene loads")]
    public float newCustomerDelay = 0.5f;

    [Header("References")]
    [Tooltip("Drag your green Take Order Button GameObject here")]
    public GameObject takeOrderButton;

    [Tooltip("Drag the customer SpriteRenderer here (to flip direction)")]
    public SpriteRenderer spriteRenderer;

    private bool isWalking = false;
    private bool hasArrived = false;

    void Start()
    {
        // Hide take order button
        if (takeOrderButton != null)
            takeOrderButton.SetActive(false);

        // Start walking in after a short delay (works on fresh load AND scene reload)
        StartCoroutine(BeginWalkIn());
    }

    IEnumerator BeginWalkIn()
    {
        transform.position = startPosition;

        // Face right
        if (spriteRenderer != null)
            spriteRenderer.flipX = false;

        yield return new WaitForSeconds(newCustomerDelay);

        isWalking = true;
        Debug.Log("New customer walking in!");
    }

    void Update()
    {
        if (isWalking && !hasArrived)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                stopPosition,
                walkSpeed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, stopPosition) < 0.05f)
            {
                transform.position = stopPosition;
                OnCustomerArrived();
            }
        }
    }

    void OnCustomerArrived()
    {
        isWalking = false;
        hasArrived = true;

        if (takeOrderButton != null)
            takeOrderButton.SetActive(true);

        Debug.Log("Customer arrived — showing Take Order button.");
    }

    /// <summary>
    /// Call this to send the customer walking off screen after the order starts.
    /// </summary>
    public void CustomerLeave()
    {
        hasArrived = false;
        isWalking = true;

        // Walk off to the right
        stopPosition = new Vector3(15f, stopPosition.y, stopPosition.z);

        // Face right when leaving
        if (spriteRenderer != null)
            spriteRenderer.flipX = true;

        if (takeOrderButton != null)
            takeOrderButton.SetActive(false);
    }
}
