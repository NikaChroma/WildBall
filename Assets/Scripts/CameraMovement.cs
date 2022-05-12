using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - PlayerTransform.position;
    }
    private void FixedUpdate()
    {
        transform.position = PlayerTransform.position + offset;
    }
}
