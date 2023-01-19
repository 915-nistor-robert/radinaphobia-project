using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// unity 3d camera relative movement https://forum.unity.com/threads/moving-character-relative-to-camera.383086/
public class PlayerMovement : MonoBehaviour
{
    public float speedMeUp = 1f;
    
    private Camera _camera;

    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //reading the input:
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");
         
        //assuming we only using the single camera:

        //camera forward and right vectors:
        var camTransform = _camera.transform;
        var forward = camTransform.forward;
        var right = camTransform.right;
 
        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
 
        //this is the direction in the world space we want to move:
        var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;
 
        //now we can apply the movement:
        transform.Translate(desiredMoveDirection * (speedMeUp * Time.deltaTime));
    }
}
