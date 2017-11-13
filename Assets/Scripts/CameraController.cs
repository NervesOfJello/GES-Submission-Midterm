using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //various variables

    //keep track of the player
    [SerializeField]
    Transform objectToFollow;

    [SerializeField]
    float cameraFollowSpeed = 5;

    [SerializeField]
    float xOffset;

    [SerializeField]
    float yOffset;

    float zOffset = -1;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //for the future, change the x offset from positive to negative along with direction
        //where to put the camera
        Vector3 newPosition = new Vector3(objectToFollow.position.x + xOffset, objectToFollow.position.y + yOffset, zOffset);


        //set camera's position to the new position using lateral interpolation to follow, not lock on
        transform.position = Vector3.Lerp(transform.position, newPosition, cameraFollowSpeed * Time.deltaTime);
	}
}
