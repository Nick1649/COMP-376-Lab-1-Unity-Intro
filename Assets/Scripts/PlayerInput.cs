using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    public float movementSpeed;
    public float lookSpeed;
    float timer = 0;
    bool moved = false;

    void Start ()
    {
        // Optional...
    }

    void Update ()
    {
        // Obtain input information (See "Horizontal" and "Vertical" in the Input Manager)
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");

        // Check for inputs
        if(!Mathf.Approximately(vertical, 0.0f) || !Mathf.Approximately(horizontal, 0.0f))
        {
            Vector3 direction = new Vector3(horizontal, 0.0f, vertical);
            direction = Vector3.ClampMagnitude(direction, 1.0f);
            
            // TODO: Translate the game object in world space
            transform.Translate(direction * Time.deltaTime * movementSpeed, Space.World);

            // TODO: Rotate the game object
            float step = lookSpeed * Time.deltaTime;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, step);

            // TODO: Reset idle timer to zero
            timer = 0;
            moved = true;
        }

        if (timer > 2 && moved)
        {
            transform.Rotate(0, 360.0f * Time.deltaTime, 0);
        }

        timer += Time.deltaTime;

        // ALTERNATIVE
        /*
        if(Input.GetKey (KeyCode.W))
        {

        }
        if(Input.GetKey (KeyCode.S))
        {

        }
        if(Input.GetKey (KeyCode.A))
        {

        }
        if(Input.GetKey (KeyCode.D))
        {

        }
        */
    }
}
