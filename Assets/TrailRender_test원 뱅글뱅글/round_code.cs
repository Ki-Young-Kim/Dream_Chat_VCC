
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class round_code : UdonSharpBehaviour
{
    public GameObject round_cube1, round_cube2, round_cube3;

    [SerializeField]
    float circleR, deg, objSpeed;

    private void Update()
    {
        deg += Time.deltaTime * objSpeed;
        if(deg<360)
        {
            var rad = Mathf.Deg2Rad * (deg);
            var x = circleR * Mathf.Sin(rad);
            var y = circleR * Mathf.Cos(rad);
            
            var rad2 = Mathf.Deg2Rad * (deg+120);
            var x2 = circleR * Mathf.Sin(rad2);
            var y2 = circleR * Mathf.Cos(rad2);
            
            var rad3 = Mathf.Deg2Rad * (deg+240);
            var x3 = circleR * Mathf.Sin(rad3);
            var y3 = circleR * Mathf.Cos(rad3);
            round_cube1.transform.position = transform.position + new Vector3(x, y, 0);
            //round_cube1.transform.rotation = Quaternion.Euler(0, 0, deg * -1);
            round_cube2.transform.position = transform.position + new Vector3(x2, y2, 2);
            //round_cube2.transform.rotation = Quaternion.Euler(0, 0, (deg+120) * -1);
            round_cube3.transform.position = transform.position + new Vector3(x3, y3, 4);
            //round_cube3.transform.rotation = Quaternion.Euler(0, 0, (deg+240) * -1);

        } else
        {
            deg = 0;
        }
    }
}
