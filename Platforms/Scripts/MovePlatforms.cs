using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    [SerializeField] private Vector2 direction; //mudar direcao
    private float moveSpeed = 2f;
    [SerializeField] private float stopTime;
    [SerializeField] private float moveTime;
    private float timer = 0f;

    private enum State { Moving, Stopped };
    private State state;

    private void Awake() 
    {
        direction = direction.normalized;
        state = State.Moving;
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        /* If the platform is moving and it surpasses the time 
        moving, make it stop */
        if(state == State.Moving)
        {
            if(timer >= moveTime) {
                state = State.Stopped;
                direction *= -1; //changes direction by multiplying by 1
                timer = 0f; // restart timer
            }
            else {
                transform.Translate(direction * Time.deltaTime * moveSpeed);
            }
        }
        /* If the platform is stopped and it surpasses the
        stop limit, make it move */
        else 
        {
            if(timer >= stopTime) {
                state = State.Moving;
                timer = 0f;
            }

        }   
    }
}
