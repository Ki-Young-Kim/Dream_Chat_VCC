
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]

public class Follow_Cap : UdonSharpBehaviour
{

    [UdonSynced]
    public int capID = 0;
    public Transform head_cube;

    void Start()
    {
        capID = -1;
    }

    private void Update() {
        
        if(capID != -1) {
            if (Networking.LocalPlayer.playerId == capID) {
                head_cube.position = Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Head);
                head_cube.rotation = Networking.LocalPlayer.GetBoneRotation(HumanBodyBones.Head);
            } else {
                var cap_player = VRCPlayerApi.GetPlayerById(capID);
                head_cube.position = cap_player.GetBonePosition(HumanBodyBones.Head);
                head_cube.rotation = cap_player.GetBoneRotation(HumanBodyBones.Head);
            }
        }
    }

    public override void Interact()
    {
        if (!Networking.IsOwner(gameObject))
            Networking.SetOwner(Networking.LocalPlayer, gameObject);

        capID = Networking.LocalPlayer.playerId;

        RequestSerialization();
    }

    public override void OnDeserialization()
    {
        if(Networking.IsOwner(gameObject)) {
            capID = Networking.LocalPlayer.playerId;
        }
    }

}
