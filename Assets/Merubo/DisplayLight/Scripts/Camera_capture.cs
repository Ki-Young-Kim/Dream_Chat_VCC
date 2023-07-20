
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class Camera_capture : UdonSharpBehaviour
{
    [Header("Camera Picture")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject photoCanvas;

    public RenderTexture camera_capture;
    private Texture2D screenCapture;
    public Sprite photoSprite;
    void Start()
    {
        
    }
}
