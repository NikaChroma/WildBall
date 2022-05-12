using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    private Rigidbody playerRigidbody;
    private Vector3 movement; 

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector3(-horizontal, 0, -vertical);

    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        playerRigidbody.AddForce(movement.normalized * speed);
    }
}
