
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

using UnityEngine.UI;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class test_light : UdonSharpBehaviour
{
    [SerializeField] private Texture2D proxyTexture, proxyTexture2, proxyTexture3, proxyTexture4;
    [SerializeField] private RenderTexture targetRenderTexture;
    public RawImage Rigmae1, Rigmae2, Rigmae3, Rigmae4;

    public Camera _camera;
    private bool is_click = false;
    private int cnt = 0;
    public GameObject gameobject1, gameobject2, gameobject3;
    private void Start()
    {
        //_camera = GetComponent<Camera>();
        if (_camera.targetTexture == null) _camera.targetTexture = targetRenderTexture;

        gameobject1.SetActive(false);
        gameobject2.SetActive(false);
        gameobject3.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SendCustomNetworkEvent(NetworkEventTarget.All, "is_click_true");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            
            SendCustomNetworkEvent(NetworkEventTarget.All, "is_click_true");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            SendCustomNetworkEvent(NetworkEventTarget.All, "is_click_true");
        }
    }

    public void set_3() {
        gameobject3.SetActive(true);
    }

    public void set_2() {
        gameobject3.SetActive(false);
        gameobject2.SetActive(true);
    }
    public void set_1() {
        gameobject2.SetActive(false);
        gameobject1.SetActive(true);
    }
    public void set_0() {
        gameobject1.SetActive(false);
    }



    public void network_is_click_true() {
            SendCustomNetworkEvent(NetworkEventTarget.All, "is_click_true");
    }

    public void is_click_true() {
            is_click = true;
    }

    private void OnPostRender()
    {
        if(is_click == true)
        {
            Capture();
            Debug.Log("local log");
            //SendCustomNetworkEvent(NetworkEventTarget.All, "Capture");
            //SendCustomNetworkEvent(NetworkEventTarget.All, "message");
            is_click = false;
        }
    }

    public void log_message() {
        Debug.Log("dddddd");
    }

    public void message() {
        Debug.Log("Message");
    }

    public void Capture()
    {
/*        proxyTexture.ReadPixels(new Rect(0, 0, proxyTexture.width, proxyTexture.height), 0, 0);
        proxyTexture.Apply();*/
        switch(cnt)
        {
            case 0:
                proxyTexture.ReadPixels(new Rect(0, 0, proxyTexture.width, proxyTexture.height), 0, 0);
                proxyTexture.Apply();
                Rigmae1.texture = proxyTexture;
                break;
            case 1:
                proxyTexture2.ReadPixels(new Rect(0, 0, proxyTexture2.width, proxyTexture2.height), 0, 0);
                proxyTexture2.Apply();
                Rigmae2.texture = proxyTexture2;
                break;
            case 2:
                proxyTexture3.ReadPixels(new Rect(0, 0, proxyTexture3.width, proxyTexture3.height), 0, 0);
                proxyTexture3.Apply();
                Rigmae3.texture = proxyTexture3;
                break;
            case 3:
                proxyTexture4.ReadPixels(new Rect(0, 0, proxyTexture4.width, proxyTexture4.height), 0, 0);
                proxyTexture4.Apply();
                Rigmae4.texture = proxyTexture4;
                break;
        }
        cnt++;
        if(cnt == 4) cnt = 0;
        
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        Debug.Log("OnPlayerTriggerEnter");
        SendCustomEventDelayedSeconds("network_is_click_true",4f);
        SendCustomNetworkEvent(NetworkEventTarget.All, "network_countdown");
    }

    public void network_countdown() {
        set_3();
        SendCustomEventDelayedSeconds("set_2",1f);
        SendCustomEventDelayedSeconds("set_1",2f);
        SendCustomEventDelayedSeconds("set_0",3f);
    }


}