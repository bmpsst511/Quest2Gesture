using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbFront : MonoBehaviour
{
    //public GameObject IndexEnd;
    public int FrontCurveVal;
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
        multi_val = ThumbEnd.multi_val;
        FrontCurveVal = ThumbEnd.cal_thumb;
        eulerAngX = transform.localEulerAngles.x;
        eulerAngY = transform.localEulerAngles.y;
        eulerAngZ = transform.localEulerAngles.z;
        this.transform.localRotation = Quaternion.Euler(eulerAngX, eulerAngY, -FrontCurveVal*multi_val);
    }
}
