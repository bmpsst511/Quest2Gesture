using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerCalibration : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Ini_index, Ini_middle, Ini_ring, Ini_pinky, Ini_thumb, Ini_Rindex, Ini_Rmiddle, Ini_Rring, Ini_Rpinky, Ini_Rthumb; //十根手指頭
    void Start()
    {
        Invoke("getfingerInitialdata", 1.0f);//1秒後才開始取得資料,以防止程式跑太快
    }

    void getfingerInitialdata()
    {
        //底家係左手
        Ini_index = IndexEndFingerCurve.Index;
        Ini_middle = IndexEndFingerCurve.Middle;
        Ini_ring = IndexEndFingerCurve.Ring;
        Ini_pinky = IndexEndFingerCurve.Pinky;
        Ini_thumb = IndexEndFingerCurve.Thumb;

        //底家係右手
        /* Ini_Rindex = R_IndexEndFingerCurve.Index;
        Ini_Rmiddle = R_IndexEndFingerCurve.Middle;
        Ini_Rring = R_IndexEndFingerCurve.Ring;
        Ini_Rpinky = R_IndexEndFingerCurve.Pinky;
        Ini_Rthumb = R_IndexEndFingerCurve.Thumb; */
    }
}
