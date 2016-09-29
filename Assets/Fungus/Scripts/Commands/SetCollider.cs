// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using System.Collections.Generic;
using Fungus.Variables;

namespace Fungus.Commands
{
    /// <summary>
    /// Sets all collider (2d or 3d) components on the target objects to be active / inactive.
    /// </summary>
    [CommandInfo("Sprite", 
                 "Set Collider", 
                 "Sets all collider (2d or 3d) components on the target objects to be active / inactive")]
    [AddComponentMenu("")]
    public class SetCollider : Command
    {       
        [Tooltip("A list of gameobjects containing collider components to be set active / inactive")]
        [SerializeField] protected List<GameObject> targetObjects = new List<GameObject>();

        [Tooltip("All objects with this tag will have their collider set active / inactive")]
        [SerializeField] protected string targetTag = "";

        [Tooltip("Set to true to enable the collider components")]
        [SerializeField] protected BooleanData activeState;

        public override void OnEnter()  
        {
            foreach (GameObject go in targetObjects)
            {
                SetColliderActive(go);
            }

            GameObject[] taggedObjects = null;
            try
            {
                taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);
            }
            catch
            {
                // The tag has not been declared in this scene
            }

            if (taggedObjects != null)
            {
                foreach (GameObject go in taggedObjects)
                {
                    SetColliderActive(go);
                }
            }

            Continue();
        }

        protected virtual void SetColliderActive(GameObject go)
        {
            if (go != null)     
            {
                // 3D objects
                foreach (Collider c in go.GetComponentsInChildren<Collider>())
                {
                    c.enabled = activeState.Value;
                }
                
                // 2D objects
                foreach (Collider2D c in go.GetComponentsInChildren<Collider2D>())
                {
                    c.enabled = activeState.Value;
                }
            }
        }
        
        public override string GetSummary()
        {
            int count = targetObjects.Count;

            if (activeState.Value)
            {
                return "Enable " + count + " collider objects.";
            }
            else
            {
                return "Disable " + count + " collider objects.";
            }
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255); 
        }
    }
        
}