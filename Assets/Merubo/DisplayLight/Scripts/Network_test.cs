
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Network_test : UdonSharpBehaviour
{
    void Start()
    {
        
    }

    public override void Interact()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "log");
    }
    public void log() {
        Debug.Log("test");
    }

}
