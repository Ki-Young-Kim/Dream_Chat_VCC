
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

public class Get_key : UdonSharpBehaviour
{
    public bool is_click = false;
    public GameObject picture_ui;
    private void Update()
    {
        if(picture_ui.activeSelf == false) {
            if (Input.GetKeyDown(KeyCode.P))
            {
                picture_ui.transform.localPosition = Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Head);
                picture_ui.transform.localRotation = Networking.LocalPlayer.GetBoneRotation(HumanBodyBones.Head);
                is_click = true;
                SendCustomNetworkEvent(NetworkEventTarget.All, "network_UI_On");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                picture_ui.transform.localPosition = Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Head);
                picture_ui.transform.localRotation = Networking.LocalPlayer.GetBoneRotation(HumanBodyBones.Head);
                is_click = true;
                SendCustomNetworkEvent(NetworkEventTarget.All, "network_UI_On");
            }
        } else {
            if (Input.GetKeyDown(KeyCode.P))
                {
                    is_click = true;
                    SendCustomNetworkEvent(NetworkEventTarget.All, "network_UI_Off");
                }
            if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2))
                {
                    is_click = true;
                    SendCustomNetworkEvent(NetworkEventTarget.All, "network_UI_Off");
                }
        }
    }

    public void network_UI_On() {
        picture_ui.SetActive(true);
    }

    public void network_UI_Off() {
        picture_ui.SetActive(false);
    }
}
