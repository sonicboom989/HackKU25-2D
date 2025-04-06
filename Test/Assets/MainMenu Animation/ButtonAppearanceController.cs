using UnityEngine;
using System.Collections;

public class ButtonAppearanceController : MonoBehaviour
{
    public GameObject startButton;  // Reference to the Start button
    public GameObject exitButton;   // Reference to the Exit button
    public float delayTime = 3f;    // Time to wait before showing buttons (in seconds)
    public float fadeDuration = 1f; // Duration of the fade-in effect (in seconds)

    private CanvasGroup startButtonCanvasGroup; // To control the start button's transparency
    private CanvasGroup exitButtonCanvasGroup;  // To control the exit button's transparency

    void Start()
    {
        // Get the CanvasGroup component from the buttons
        startButtonCanvasGroup = startButton.GetComponent<CanvasGroup>();
        exitButtonCanvasGroup = exitButton.GetComponent<CanvasGroup>();

        // Initially make the buttons completely invisible
        startButtonCanvasGroup.alpha = 0f;
        exitButtonCanvasGroup.alpha = 0f;

        // Start the coroutine to show buttons after delay
        StartCoroutine(ShowButtonsAfterDelay());
    }

    private IEnumerator ShowButtonsAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayTime);

        // Activate the buttons after the delay
        startButton.SetActive(true);
        exitButton.SetActive(true);

        // Fade the buttons in by gradually increasing the alpha value
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Calculate the alpha value based on the time elapsed
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            startButtonCanvasGroup.alpha = alpha;
            exitButtonCanvasGroup.alpha = alpha;

            elapsedTime += Time.deltaTime;  // Increase time
            yield return null;  // Wait for the next frame
        }

        // Ensure the final alpha value is exactly 1
        startButtonCanvasGroup.alpha = 1f;
        exitButtonCanvasGroup.alpha = 1f;
    }
}
