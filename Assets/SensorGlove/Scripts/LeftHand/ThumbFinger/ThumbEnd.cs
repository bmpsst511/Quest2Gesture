using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbEnd : MonoBehaviour
{
    //public GameObject IndexEnd;
    public static int cal_thumb;
    public static float multi_val;
    public float level = 3;
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
        cal_thumb = IndexEndFingerCurve.Thumb - FingerCalibration.Ini_thumb;
        eulerAngX = transform.localEulerAngles.x;
        eulerAngY = transform.localEulerAngles.y;
        eulerAngZ = transform.localEulerAngles.z;
        this.transform.localRotation = Quaternion.Euler(-cal_thumb*multi_val, eulerAngY, eulerAngZ);
    }
}
