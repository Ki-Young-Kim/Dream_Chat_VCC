
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;


[UdonBehaviourSyncMode(BehaviourSyncMode.None), RequireComponent(typeof(Camera))]
public class DisplayLight : UdonSharpBehaviour
{
    [SerializeField] private Light[] targetLights;
    [SerializeField] private int captureFrameInterval = 10;
    [SerializeField] private Texture2D proxyTexture;
    [SerializeField] private RenderTexture targetRenderTexture;
    
    private Camera _camera;
    private int _captureFrameCount;
    private Color _previousColor;
    private Color _lastCapturedColor;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        if(_camera.targetTexture == null) _camera.targetTexture = targetRenderTexture;
    }


    private void OnPostRender()
    {
        if (_captureFrameCount >= captureFrameInterval)
        {
            _captureFrameCount = 0;
            Capture();
        }
        else
        {
            _captureFrameCount++;
        }
        
        UpdateLight();
}


    private void Capture()
    {
        proxyTexture.ReadPixels(new Rect(0, 0, proxyTexture.width, proxyTexture.height), 0, 0);
        Color[] pixels = proxyTexture.GetPixels();
        float r = 0;
        float g = 0;
        float b = 0;
        for (int i = 0; i < pixels.Length; i++)
        {
            r += pixels[i].r;
            g += pixels[i].g;
            b += pixels[i].b;
        }
        r /= pixels.Length;
        g /= pixels.Length;
        b /= pixels.Length;
        _previousColor = _lastCapturedColor;
        _lastCapturedColor = new Color(r, g, b);
    }

    private void UpdateLight()
    {
        foreach (var targetLight in targetLights)
        {
            targetLight.color = Color.Lerp(_previousColor, _lastCapturedColor, _captureFrameCount / (float) captureFrameInterval);
        }
    }
}
