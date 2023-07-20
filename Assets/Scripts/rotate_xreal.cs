
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class rotate_xreal : UdonSharpBehaviour
{
    float rotSpeed = 100f;

    void Update()
    {
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
    }
}
