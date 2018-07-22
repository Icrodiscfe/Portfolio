using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour {
	
	public GameObject CameraFocusObject, Horizontal, CameraParentObject;


	public float ZoomSpeed = 2.0f;
	public float HorizontalSpeed = 100.0F;
	public float VerticalSpeed = 100.0F;

	Camera camera;

	// Use this for initialization
	void Start ()
    {
		camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
		Horizontal.transform.position = CameraFocusObject.transform.position;
		CameraParentObject.transform.position = CameraFocusObject.transform.position;
		float mouseScrollWheel = Input.GetAxis ("Mouse ScrollWheel");
		camera.transform.Translate (0f, 0f, mouseScrollWheel * ZoomSpeed);
		Cursor.lockState = CursorLockMode.None;

		if(Input.GetKey(KeyCode.Mouse0))
        {
			Cursor.lockState = CursorLockMode.Locked;
			float h = HorizontalSpeed * Input.GetAxis("Mouse X");
			float v = VerticalSpeed * Input.GetAxis("Mouse Y");
			transform.RotateAround(CameraFocusObject.transform.position, Vector3.up, Input.GetAxis("Mouse X") * HorizontalSpeed * Time.deltaTime);
			Horizontal.transform.RotateAround(CameraFocusObject.transform.position, Vector3.up, Input.GetAxis("Mouse X") * HorizontalSpeed * Time.deltaTime);
			transform.RotateAround(Horizontal.transform.position, Horizontal.transform.right, -Input.GetAxis("Mouse Y") * VerticalSpeed * Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.Mouse1))
        {
			Cursor.lockState = CursorLockMode.Locked;
			float h = HorizontalSpeed * Input.GetAxis("Mouse X");
			float v = VerticalSpeed * Input.GetAxis("Mouse Y");
			transform.RotateAround(CameraFocusObject.transform.position, Vector3.up, Input.GetAxis("Mouse X") * HorizontalSpeed * Time.deltaTime);
			Horizontal.transform.RotateAround(CameraFocusObject.transform.position, Vector3.up, Input.GetAxis("Mouse X") * HorizontalSpeed * Time.deltaTime);
			transform.RotateAround(Horizontal.transform.position, Horizontal.transform.right, -Input.GetAxis("Mouse Y") * VerticalSpeed * Time.deltaTime);

			CameraFocusObject.transform.rotation = new Quaternion(CameraFocusObject.transform.rotation.x, transform.rotation.y,
				CameraFocusObject.transform.rotation.z, transform.rotation.w);
		}
	}
}
