
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class teleport : UdonSharpBehaviour
{
    public Transform teleport_des;
    public AudioSource bgm;
    
    void Start()
    {
        
    }

    // public override void Interact()
    // {

    //     Networking.LocalPlayer.TeleportTo(teleport_des.position, teleport_des.rotation);
    // }
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(!bgm.isPlaying) {
            bgm.Play();
        } else {
            bgm.Pause();
        }

        Networking.LocalPlayer.TeleportTo(teleport_des.position, teleport_des.rotation);
    }
}
