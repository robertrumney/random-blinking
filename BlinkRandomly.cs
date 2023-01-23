using UnityEngine;
using System.Collections;

public class BlinkRandomly : MonoBehaviour
{
    SkinnedMeshRenderer skinnedMeshRenderer;

    readonly int blinkShapeIndex = 10;  // Index of the blend shape that controls the left eye blink
    readonly int blinkShapeIndex2 = 11; // Index of the blend shape that controls the right eye blink

    float blinkSpeed = 100f;           // Speed at which the eyes blink
    float blinkInterval = 1f;          // Time between blinks
    float targetBlendValue;            // Target value for the blend shape weight

    bool isBlinking = false;           // Whether or not the character is currently blinking

    IEnumerator Start()
    {
        // Get the SkinnedMeshRenderer component on the current GameObject
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        targetBlendValue = 0f;

        // Run this loop forever
        while(true)
        {
            // If the character is blinking, set a random blink interval
            if (isBlinking)
                blinkInterval = Random.Range(1.0f, 5.0f);
            else
                blinkInterval = 0.2f;

            // Set a random blink speed
            blinkSpeed = Random.Range(500, 1000);

            // Call the Blink function
            Blink();

            // Wait for the blink interval before continuing
            yield return new WaitForSeconds(blinkInterval);

            // Toggle the isBlinking flag
            isBlinking = !isBlinking;
        }
    
    }

    void Update()
    {
        // Smoothly transition between the open and closed states of the eyes
        skinnedMeshRenderer.SetBlendShapeWeight(blinkShapeIndex, Mathf.MoveTowards(skinnedMeshRenderer.GetBlendShapeWeight(blinkShapeIndex), targetBlendValue, Time.deltaTime * blinkSpeed));
        skinnedMeshRenderer.SetBlendShapeWeight(blinkShapeIndex2, Mathf.MoveTowards(skinnedMeshRenderer.GetBlendShapeWeight(blinkShapeIndex2), targetBlendValue, Time.deltaTime * blinkSpeed));
    }

    void Blink()
    {
        // Switch the target blend value between 0 and 100 to control the open and closed states of the eyes
        targetBlendValue = (targetBlendValue == 0f) ? 100f : 0f;
    }
}
