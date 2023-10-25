using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    

public class CameraManager : MonoBehaviour
{
    public GameObject _3rdPersonCamera;
    public GameObject _1stPersonCamera;
    public int maneChan;
    public static CameraManager instance;
    public void ManagerarCam()
    {
        if (maneChan == 0)
        {
            Cam_2();
            maneChan = 1;
        }
        else if (maneChan== 1)
        {
            Cam_1();
            maneChan = 0;
        }
    }


    void Cam_1()
    {
        _1stPersonCamera.SetActive(true);
        _3rdPersonCamera.SetActive(false);
    }
        void Cam_2()
    {
        _1stPersonCamera.SetActive(false);
        _3rdPersonCamera.SetActive(true);
    }
}
