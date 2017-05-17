using UnityEngine;
using Fungus;
public class Intro : MonoBehaviour
{

    public Flowchart HomeFlowchart;

    public void OnAnimationFInished()
    {
        //HomeFlowchart.BroadcastMessage("AnimationFinished");
        //HomeFlowchart.SendMessage(, SendMessageOptions.DontRequireReceiver);
        HomeFlowchart.ExecuteBlock("Intro  finished");
    }
}
