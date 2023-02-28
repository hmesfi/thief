using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MafiaBossController : MonoBehaviour
{
    public float speed = 5f; // The speed at which the mafia boss moves
    public float endX = 10f; // The x-coordinate of the end point of the mafia boss's movement
    public float startX = -10f; // The x-coordinate of the start point of the mafia boss's movement
    public float moveDistance = 20f; // The distance between the start and end points
    public float pauseTime = 1.5f; // The time the mafia boss pauses before moving back

    private float timer; // Timer for pausing before moving back
    private bool movingForward = true; // Flag for whether the mafia boss is currently moving forward

    // Update is called once per frame
    void Update()
    {
        if (movingForward)
        {
            // Move the mafia boss forward until it reaches the end point
            if (transform.position.x < endX)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                // Pause for a short time before moving back
                timer += Time.deltaTime;
                if (timer >= pauseTime)
                {
                    timer = 0f;
                    movingForward = false;
                }
            }
        }
        else
        {
            // Move the mafia boss back until it reaches the start point
            if (transform.position.x > startX)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                // Pause for a short time before moving forward again
                timer += Time.deltaTime;
                if (timer >= pauseTime)
                {
                    timer = 0f;
                    movingForward = true;
                }
            }
        }
    }
}