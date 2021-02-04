using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{

    public GameObject weapon;
    public float speed;
    private Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        weapon.SetActive(false);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rigidbody2d.MovePosition(position + new Vector2(x, y) * speed * Time.deltaTime);

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
}
