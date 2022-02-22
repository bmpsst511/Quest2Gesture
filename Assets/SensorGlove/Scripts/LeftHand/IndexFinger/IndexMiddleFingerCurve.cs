using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexMiddleFingerCurve : MonoBehaviour
{
    //public GameObject IndexEnd;
    public int MiddleCurveVal;
    float multi_val;
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
        multi_val = IndexEndFingerCurve.multi_val;
        MiddleCurveVal = IndexEndFingerCurve.cal_index;
        eulerAngX = transform.localEulerAngles.x;
        eulerAngY = transform.localEulerAngles.y;
        eulerAngZ = transform.localEulerAngles.z;
        //CurveVal = eulerAngX;
        this.transform.localRotation = Quaternion.Euler(eulerAngX, eulerAngY, -MiddleCurveVal*multi_val);
    }
}

