// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;

namespace Fungus.Commands
{
    /// <summary>
    /// Stops the currently playing game music.
    /// </summary>
    [CommandInfo("Audio", 
                 "Stop Music", 
                 "Stops the currently playing game music.")]
    [AddComponentMenu("")]
    public class StopMusic : Command
    {
        public override void OnEnter()
        {
            IMusicController musicController = MusicController.GetInstance();
            if (musicController != null)
            {
                musicController.StopMusic();
            }

            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(242, 209, 176, 255);
        }
    }
}