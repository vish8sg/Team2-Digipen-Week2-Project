using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{

    [SerializeField] Transform center = null;
    [SerializeField] float angularAcceleration = 10f;
    [SerializeField] float maxAngularSpeed = 50f;

    float radius = 0f;

    float angularSpeed = 0f;
    float angle = 0f;

    private void Start()
    {
        if (center == null) { return; }
        radius = Vector3.Distance(center.position, transform.position);
        angle = Vector3.Angle(center.position, transform.position);
        angle = Mathf.Deg2Rad * angle;
        Debug.Log(angle);
    }

    private void Update()
    {
        HandleInput();

        angle += angularSpeed * Time.deltaTime;


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
    }

}
