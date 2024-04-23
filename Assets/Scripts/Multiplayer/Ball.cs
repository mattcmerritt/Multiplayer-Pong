using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Multiplayer
{
    public class Ball : MonoBehaviour
    {
        // Ball information
        [SerializeField, Range(0f, 100f)] private float moveSpeed;
        [SerializeField] private float moveDirection;

        // Components
        [SerializeField] private Rigidbody2D rb;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // center the ball
                transform.position = Vector3.zero;

                moveDirection = Random.Range(0, 2) == 0 ? -1 : 1;

                // set the speed of the ball to randomly go towards a player
                rb.velocity = (new Vector2(moveDirection, 0f)).normalized * moveSpeed;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.GetComponent<Paddle>())
            {
                // calculate where the paddle was hit to get bounce vertical direction
                float hitLocation = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;
                // switch the move direction
                moveDirection = moveDirection == 1 ? -1 : 1;

                // set the speed
                rb.velocity = (new Vector2(moveDirection, hitLocation)).normalized * moveSpeed;
            }
        }
    }
}
