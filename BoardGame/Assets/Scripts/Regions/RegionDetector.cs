using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RegionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    public static string region;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1"))
        {
            Debug.Log(other.gameObject.name + "Region 1");
            region = other.gameObject.name + "Region 1";
        }
        else
        {
            Debug.Log(other.gameObject.name + "Region 1");
            region = other.gameObject.name + "Region 1";
        }
    }
}
