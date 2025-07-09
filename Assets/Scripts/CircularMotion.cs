using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CircularMotion : MonoBehaviour
{

    [SerializeField] Transform center = null;
    [SerializeField] float angularAcceleration = 10f;
    [SerializeField] float maxAngularSpeed = 50f;
    [SerializeField] bool toggleMouseInput = false;

    float radius = 0f;

    float angularSpeed = 0f;
    float angle = 0f;
    float desiredAngle = 0f;

    private void Start()
    {
        if (center == null) { return; }
        radius = Vector3.Distance(center.position, transform.position);
    }

    private void Update()
    {
        if (!toggleMouseInput) 
        { 
            HandleInput(); 
        }
        else
        {
            HandleMouseInput();
        }

        //angle += angularSpeed * Time.deltaTime;


        //Calculate new positon on circle
        Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
        transform.position = (Vector2) center.position + offset;

        //Rotate to face tangent direction - (rotations are complicated so used chatgpt)
        Vector2 tangent = new Vector2(-Mathf.Sin(angle), Mathf.Cos(angle)) * Mathf.Sign(angularSpeed);
        float angleDeg = Mathf.Atan2(tangent.y, tangent.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angularSpeed -= angularAcceleration * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            angularSpeed += angularAcceleration * Time.deltaTime;
        } else
        {
            angularSpeed = Mathf.MoveTowards(angularSpeed, 0f, angularAcceleration *  Time.deltaTime);
        }

        angularSpeed = Mathf.Clamp(angularSpeed, -maxAngularSpeed, maxAngularSpeed);
        angle += angularSpeed * Time.deltaTime;
    }

    private void HandleMouseInput()
    {
        //Gets the mouse position in screen space, converts the screen space position to world position, and normalizes the vector
        Vector3 mousePosition = Input.mousePosition;
        Vector2 mouseWorldPosition = (Vector2) Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.Normalize();

        //calculates the angle between the center and the mouse position in radians
        //desiredAngle = Mathf.Acos(Vector2.Dot(mouseWorldPosition, center.right));
        desiredAngle = Mathf.Atan2(mouseWorldPosition.y, mouseWorldPosition.x);
        Debug.Log(desiredAngle);


        //angle = Mathf.MoveTowards(angle, desiredAngle, 5f * Time.deltaTime);
        angle = desiredAngle;
    }

}
