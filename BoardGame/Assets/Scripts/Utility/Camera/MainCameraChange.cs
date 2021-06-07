using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainCameraChange : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    public void CamChange()
    {
        cam1.enabled = false;
        cam2.enabled = false;
        if (GameObject.Find("CameraChange/Text").GetComponent<Text>().text.Equals("Map"))
        {
            cam1.enabled = false;
            cam2.enabled = true;
            GameObject.Find("CameraChange/Text").GetComponent<Text>().text = "Player";
        }
        else
        {
            cam1.enabled = true;
            cam2.enabled = false;
            GameObject.Find("CameraChange/Text").GetComponent<Text>().text = "Map";
        }
    }
}
