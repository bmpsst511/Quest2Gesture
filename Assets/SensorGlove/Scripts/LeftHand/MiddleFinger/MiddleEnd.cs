using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEnd : MonoBehaviour
{
    public static int  cal_mid;
    public float level = 3;
    public static float multi_val;
    [SerializeField]
    float eulerAngX;
    [SerializeField]
    float eulerAngY;
    [SerializeField]
    float eulerAngZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        multi_val = level;
        cal_mid = IndexEndFingerCurve.Middle - FingerCalibration.Ini_middle;
        eulerAngX = transform.localEulerAngles.x;
        eulerAngY = transform.localEulerAngles.y;
        eulerAngZ = transform.localEulerAngles.z;
        this.transform.localRotation = Quaternion.Euler(eulerAngX, eulerAngY, -cal_mid*multi_val);
    }
}
