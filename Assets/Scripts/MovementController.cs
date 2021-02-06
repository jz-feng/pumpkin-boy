using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PumpkinBoy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {

        public GameObject weapon;
        public float speed;
        private Animator animator;
        private Rigidbody2D rigidbody2d;
        private Vector2 facing;
        private Vector2 velocity;

        void Awake()
        {
            animator = GetComponent<Animator>();
            rigidbody2d = GetComponent<Rigidbody2D>();
            weapon.SetActive(false);

            facing = Vector2.down;
        }

        void Update()
        {
            animator.SetFloat("DirectionX", (int)facing.x);
            animator.SetFloat("DirectionY", (int)facing.y);

            animator.SetBool("IsMoving", velocity != Vector2.zero);
        }

        void FixedUpdate()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            velocity = new Vector2(x, y).normalized;
            rigidbody2d.MovePosition(rigidbody2d.position + velocity * speed * Time.deltaTime);
            UpdateFacingDirection(velocity);


            bool space = Input.GetKey(KeyCode.Space);
            if (space)
            {
                weapon.SetActive(true);
            }
            else
            {
                weapon.SetActive(false);
            }
        }

        private void UpdateFacingDirection(Vector2 velocity)
        {
            if (velocity == Vector2.down || velocity == Vector2.up)
            {
                facing = velocity;
            }
            else if (velocity.x < 0)
            {
                facing = Vector2.left;
            }
            else if (velocity.x > 0)
            {
                facing = Vector2.right;
            }
        }
    }
}
