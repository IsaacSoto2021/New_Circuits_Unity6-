using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    private Rigidbody rb;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        moveSpeed = PlayerData.Instance._moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = -Input.GetAxisRaw("Vertical");
        float moveZ = Input.GetAxisRaw("Horizontal");

        // movement = new Vector3(moveX, 0f, moveZ).normalized;

    }

    void FixedUpdate()
    {
        Vector3 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        rb.linearVelocity = ctx.ReadValue<Vector2>() * moveSpeed;
    }

}
