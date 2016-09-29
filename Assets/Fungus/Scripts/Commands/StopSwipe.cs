// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;

namespace Fungus.Commands
{
    /// <summary>
    /// Deactivates swipe panning mode.
    /// </summary>
    [CommandInfo("Camera", 
                 "Stop Swipe", 
                 "Deactivates swipe panning mode.")]
    [AddComponentMenu("")]
    public class StopSwipe : Command 
    {
        public override void OnEnter()
        {
            ICameraController cameraController = CameraController.GetInstance();

            cameraController.StopSwipePan();

            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(216, 228, 170, 255);
        }
    }
}