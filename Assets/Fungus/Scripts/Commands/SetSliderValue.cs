// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

﻿using UnityEngine;
using UnityEngine.UI;
using Fungus.Variables;

namespace Fungus.Commands
{
    /// <summary>
    /// Sets the value property of a slider object.
    /// </summary>
    [CommandInfo("UI",
                 "Set Slider Value",
                 "Sets the value property of a slider object")]
    public class SetSliderValue : Command 
    {
        [Tooltip("Target slider object to set the value on")]
        [SerializeField] protected Slider slider;

        [Tooltip("Float value to set the slider value to.")]
        [SerializeField] protected FloatData value;

        public override void OnEnter() 
        {
            slider.value = value;

            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }

        public override string GetSummary()
        {
            if (slider == null)
            {
                return "Error: Slider object not selected";
            }

            return slider.name + " = " + value.GetDescription();
        }
    }
}