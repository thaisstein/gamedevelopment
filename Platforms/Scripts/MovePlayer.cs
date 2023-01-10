using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 8f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * movementSpeed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * movementSpeed);
        }
        
    }
}
