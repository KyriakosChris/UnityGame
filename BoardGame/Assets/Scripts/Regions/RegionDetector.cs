using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RegionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
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
            Debug.Log(this.name +other.gameObject.name);
            DisplayReg.region = this.name + "   " + other.gameObject.name;
        }
        else
        {
            Debug.Log(this.name + other.gameObject.name);
            DisplayReg.region = this.name + "   " + other.gameObject.name;
        }
    }
}
