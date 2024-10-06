using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FPSController : MonoBehaviour
{
    Vector3 movementVector;
    float turnValue;
    float lookValue;
    Rigidbody rb;

    [SerializeField]
    GameObject cameraPivot;

    [SerializeField]
    float movementSpeed = 10;

    [SerializeField]
    float rotationSpeed = 90;

    [SerializeField]
    float maxCameraAngle = 45;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = movementVector * movementSpeed + Vector3.up * rb.velocity.y;
        transform.Rotate(0, turnValue * rotationSpeed * Time.deltaTime, 0);
        cameraPivot.transform.localRotation = Quaternion.Euler(lookValue * maxCameraAngle, 0, 0);
    }

    public void OnMove(InputAction.CallbackContext c)
    {
        Vector2 moveValue = c.ReadValue<Vector2>();
        movementVector = (transform.forward * moveValue.y + transform.right * moveValue.x);
        if (movementVector.magnitude > 1) movementVector = movementVector.normalized;
    }

    public void OnTurn(InputAction.CallbackContext c)
    {
        turnValue = c.ReadValue<float>();
    }

    public void OnLookAdditive(InputAction.CallbackContext c)
    {
        print(c.ReadValue<float>());

        lookValue = Mathf.Clamp(lookValue - (c.ReadValue<float>() / 100f), -1, 1);
    }

    public void OnLook(InputAction.CallbackContext c)
    {
        lookValue = -c.ReadValue<float>();
    }
}
