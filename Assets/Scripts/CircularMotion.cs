using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CircularMotion : MonoBehaviour
{
    [Tooltip("Turn Speed in Degrees Per Second")]
    [SerializeField] float turnSpeed = 150f;

    private void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        //Gets the mouse position in screen space, converts the screen space position to world position, and normalizes the vector
        Vector3 mousePosition = Input.mousePosition;
        Vector2 mouseWorldPosition = (Vector2) Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.Normalize();
        Vector2 rightVector = -transform.right;

        float dot = Vector2.Dot(rightVector, mouseWorldPosition);
        Debug.DrawLine(transform.position, mouseWorldPosition, Color.red);
        Debug.DrawLine(transform.position, rightVector, Color.blue);

        //Compute rotation this frame
        float rotationThisFrame = 0f;
        if (dot < 0f)
        {
            rotationThisFrame = -turnSpeed * Time.deltaTime;
        }
        else if (dot > 0f)
        {
            rotationThisFrame = turnSpeed * Time.deltaTime;
        }

        //Uses the rotation that we computed and applies it to the transform
        Quaternion rotator = Quaternion.AngleAxis(rotationThisFrame, Vector3.forward);
        transform.rotation = transform.rotation * rotator;
    }


}
