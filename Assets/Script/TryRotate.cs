using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryRotate : MonoBehaviour {

	void OnMouseDrag() {
		float rotX = Input.GetAxis ("Mouse X") * Mathf.Deg2Rad;
		float rotY = Input.GetAxis ("Mouse Y") * Mathf.Deg2Rad;

		transform.Rotate (new Vector3(rotY * 30, -rotX * 30));
	}
}
