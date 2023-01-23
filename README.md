# BlinkRandomly
A Unity script that randomly controls the blinking of a character's eyes.

## Overview
This script uses the `SkinnedMeshRenderer` component to smoothly transition between the open and closed states of a character's eyes. The blink interval and blink speed are randomly generated, giving the character a more natural, lifelike appearance.

## Getting Started
1. Add the `BlinkRandomly` script to your Unity project.
2. Attach the script to the GameObject that represents your character's eyes.
3. **Assumes your blend shapes are already set up**
4. In the script, set the `blinkShapeIndex` and `blinkShapeIndex2` variables to the appropriate blend shape indices for your character's left and right eyes, respectively.

## Usage
The script automatically starts running when the scene is loaded, so no further action is required to activate it. The blink interval and blink speed will be randomly generated, and the character's eyes will blink at a natural, unpredictable rate.

## Customization
You can adjust the parameters of the blink animation by modifying the following variables in the script:
- `blinkSpeed`: The speed at which the eyes blink.
- `blinkInterval`: The time between blinks.

You can also customize the range of random values that are used for the blink interval and blink speed by modifying the `Random.Range` functions in the `Start` function.

## Note
This script provides a simple, effective way to add natural-looking blinking animation to your character's eyes in Unity. With a few small modifications, it can easily be adapted to work with any character rig. However, it also assumes that your skinned mesh already has the neccesary blend shapes set up.
