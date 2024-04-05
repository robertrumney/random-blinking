using UnityEngine;
using System.Collections;

public class BlinkRandomly : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer eye1;
    [SerializeField]
    private SkinnedMeshRenderer eye2;

    private readonly int blinkShapeIndex = 0; // Assuming both eyes use the same blink shape index
    private bool isBlinking = false;
    private float timeSinceLastBlink = 0f;
    private float nextBlinkTime = 0f;

    void Start()
    {
        SetNextBlinkTime();
    }

    void Update()
    {
        timeSinceLastBlink += Time.deltaTime;

        if (timeSinceLastBlink >= nextBlinkTime && !isBlinking)
        {
            StartCoroutine(BlinkEyes());
            SetNextBlinkTime(); // Prepare for the next blink
        }
    }

    IEnumerator BlinkEyes()
    {
        isBlinking = true;
        // Close the eyes quickly
        for (float i = 0; i <= 100; i += Time.deltaTime * 2000)
        {
            eye1.SetBlendShapeWeight(blinkShapeIndex, i);
            eye2.SetBlendShapeWeight(blinkShapeIndex, i);
            yield return null;
        }

        // Keep the eyes closed for a brief moment
        yield return new WaitForSeconds(0.05f);

        // Open the eyes more slowly
        for (float i = 100; i >= 0; i -= Time.deltaTime * 500)
        {
            eye1.SetBlendShapeWeight(blinkShapeIndex, i);
            eye2.SetBlendShapeWeight(blinkShapeIndex, i);
            yield return null;
        }

        isBlinking = false;
        timeSinceLastBlink = 0f; // Reset the timer
    }

    void SetNextBlinkTime()
    {
        // Set the next blink time to a random value between 1 and 4 seconds.
        nextBlinkTime = Random.Range(1f, 4f);
    }
}
