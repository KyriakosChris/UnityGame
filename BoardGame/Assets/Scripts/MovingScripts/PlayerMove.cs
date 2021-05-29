using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    float speed = 100f;
    float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        transform.position = new Vector3(transform.position.x + (hor * speed * Time.deltaTime), transform.position.y, transform.position.z + (vert * speed * Time.deltaTime));
        Vector3 movementDirection = new Vector3(hor, 0, vert);
        movementDirection.Normalize();
        //transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
