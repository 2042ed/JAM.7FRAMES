using UnityEngine;
using Fungus;

public class Intro : MonoBehaviour
{
    public Flowchart HomeFlowchart;

    public void OnAnimationFinished()
    {
        HomeFlowchart.SendFungusMessage("AnimationFinished");
    }
}
