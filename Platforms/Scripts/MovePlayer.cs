using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float maxJumpTime;
    private bool ground = false;
    private float count;

    void Update()
    { 
        count = 0f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * movementSpeed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * movementSpeed);
        }
        if (Input.GetKey(KeyCode.Space) && (ground == true)) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
            count += Time.deltaTime;
            if(count > maxJumpTime){
                ground = false;
                count = 0f;
            }

        }
        
        
    }

    void OnCollisionEnter2D(Collision2D theCollision) 
    {
        if(theCollision.gameObject.CompareTag("Floor")) {
            ground = true;
        }

    }

    void OnCollisionExit2D(Collision2D theCollision) {
        if(theCollision.gameObject.CompareTag("Floor")) {
            ground = false;
        }
    }
    
}

