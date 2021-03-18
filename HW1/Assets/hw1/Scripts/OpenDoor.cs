using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

	public float smooth = 2.0f;
	public float DoorOpenAngle = 90.0f;

	private Vector3 defaultRotation;
	private Vector3 openRotation;
	private bool open;
	private bool enter;

	// Use this for initialization
	void Start ()
    {
		
			defaultRotation = transform.eulerAngles;
			openRotation = new Vector3 (defaultRotation.x, defaultRotation.y + DoorOpenAngle, defaultRotation.z);
		}
	
	// Update is called once per frame
	void Update ()
    {
		if (open)
        {
			transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, openRotation, Time.deltaTime * smooth);
		} else
        {
			transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, defaultRotation, Time.deltaTime * smooth);
		}

		open = enter;
}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			enter = true;
		}
	}

    void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player") {
			enter = false;
		}
	}
}