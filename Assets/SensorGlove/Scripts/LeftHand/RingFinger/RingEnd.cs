using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingEnd : MonoBehaviour
{
    //public GameObject IndexEnd;
    public static int cal_ring;
    public static float multi_val;
    public float level=3;
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
        cal_ring = IndexEndFingerCurve.Ring - FingerCalibration.Ini_ring;
        eulerAngX = transform.localEulerAngles.x;
        eulerAngY = transform.localEulerAngles.y;
        eulerAngZ = transform.localEulerAngles.z;
        this.transform.localRotation = Quaternion.Euler(eulerAngX, eulerAngY, -cal_ring*multi_val);
    }
}
