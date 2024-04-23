using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleplayer
{
    public class Paddle : MonoBehaviour
    {
        // Player information
        [SerializeField, Range(0f, 100f)] private float moveSpeed;
        [SerializeField] private Color playerColor;

        // Components
        [SerializeField] private Rigidbody2D rb;

        private void FixedUpdate()
        {
            rb.velocity = moveSpeed * Input.GetAxisRaw("Vertical") * Vector2.up;
        }
    }
}
