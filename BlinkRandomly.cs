using UnityEngine;
using System.Collections;

public class BlinkRandomly : MonoBehaviour
{
    SkinnedMeshRenderer skinnedMeshRenderer;
    
    // Index of the blend shape that controls the left eye blink
    private readonly int blinkShapeIndex = 10;  
    
    // Index of the blend shape that controls the right eye blink
    private readonly int blinkShapeIndex2 = 11; 

    // Speed at which the eyes blink
    private float blinkSpeed = 100f;     
    
    // Time between blinks
    private float blinkInterval = 1f;         
    
    // Target value for the blend shape weight
    private float targetBlendValue;           

    // Whether or not the character is currently blinking
    private bool isBlinking = false;           

    private IEnumerator Start()
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

    private void Update()
    {
        // Smoothly transition between the open and closed states of the eyes
        skinnedMeshRenderer.SetBlendShapeWeight(blinkShapeIndex, Mathf.MoveTowards(skinnedMeshRenderer.GetBlendShapeWeight(blinkShapeIndex), targetBlendValue, Time.deltaTime * blinkSpeed));
        skinnedMeshRenderer.SetBlendShapeWeight(blinkShapeIndex2, Mathf.MoveTowards(skinnedMeshRenderer.GetBlendShapeWeight(blinkShapeIndex2), targetBlendValue, Time.deltaTime * blinkSpeed));
    }

    private void Blink()
    {
        // Switch the target blend value between 0 and 100 to control the open and closed states of the eyes
        targetBlendValue = (targetBlendValue == 0f) ? 100f : 0f;
    }
}
