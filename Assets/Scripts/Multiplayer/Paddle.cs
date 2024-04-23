using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace Multiplayer
{
    public class Paddle : NetworkBehaviour
    {
        // Player information
        [SerializeField, Range(0f, 100f)] private float moveSpeed;
        [SerializeField] private Color[] playerColor;

        // Components
        [SerializeField] private Rigidbody2D rb;

        public override void OnNetworkSpawn()
        {
            // Find how many players are in the game
            Paddle[] paddles = FindObjectsOfType<Paddle>();

            if (paddles.Length == 1)
            {
                transform.position = new Vector3(-8f, 0f, 0f);
                GetComponent<SpriteRenderer>().color = playerColor[0];
            }
            else if (paddles.Length == 2)
            {
                transform.position = new Vector3(8f, 0f, 0f);
                GetComponent<SpriteRenderer>().color = playerColor[1];
            }
            else
            {
                transform.position = new Vector3(0f, 10f, 0f);
                Debug.LogWarning("An extra player attempted to join, paddle was spawned off screen.");
            }
        }

        private void FixedUpdate()
        {
            rb.velocity = moveSpeed * Input.GetAxisRaw("Vertical") * Vector2.up;
        }
    }
}