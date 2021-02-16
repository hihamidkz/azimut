using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchOnText : MonoBehaviour {

	public GameObject Model;
	public GameObject ObjPanel;
	public GameObject Logo;
	public GameObject Button1, Button2, Button3, Button4;
	public GameObject Text_3D, Anim;

	public GameObject[] Targets;

	public Slider Slider;

	private bool Push = false;
	private bool Scaling = false;

	private float prevVal;
	private Vector3 StartPos;
	private Vector3 StartScale;
	private Quaternion StartRot;

	private int Orientation = 0;

	private float PY1, PY2;

	void Start() {
		PY1 = -309.3f;
		PY2 = -149.3f;
		StartPos = Model.transform.localPosition;
		StartScale = Model.transform.localScale;
		StartRot = Model.transform.localRotation;
		ObjPanel.SetActive (false);
	}

	void OnMouseDown() {
		if (Logo.activeSelf == true && !Scaling) {
			GlobalVar.Exit = false;

			foreach (GameObject Target in Targets)
				Target.SetActive(false);

			Text_3D.GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 0);
			Anim.GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 0);
			ObjPanel.SetActive (true);

			if (Screen.height < Screen.width) {
				Model.transform.localPosition = StartPos + new Vector3 (0, 20, 10);
				Button4.transform.localPosition = new Vector3(339.1f, -149.3f, 0);;
			}

			Logo.SetActive (false);
			Button1.SetActive (false);
			Button2.SetActive (false);
			Button3.SetActive (false);
			//Button4.SetActive (false);
			Push = true;
		}
	}

	void Update() {
		Debug.Log (Button4.transform.localPosition.ToString ());

		if (Push) {
			if (Input.touchCount == 2) {
				Scaling = true;
				Touch touchZero = Input.GetTouch (0);
				Touch touchOne = Input.GetTouch (1);

				Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

				float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

				float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;

				float tX = Model.transform.localScale.x - deltaMagDiff * 0.01f;
				float tY = Model.transform.localScale.y - deltaMagDiff * 0.01f;
				float tZ = Model.transform.localScale.z - deltaMagDiff * 0.01f;

				Vector3 newScale = new Vector3 (tX, tY, tZ);

				if (newScale.x > StartScale.x)
					Model.transform.localScale = newScale;
			}

			if (Screen.height < Screen.width) {
				Slider.GetComponent<RectTransform> ().localPosition = new Vector3 (0, 155);
				Button4.transform.localPosition = new Vector3(339.1f, -149.3f, 0);
				if (Orientation == 0) {
					Model.transform.localPosition = StartPos + new Vector3(10, 20, 10);
					Model.transform.localRotation = StartRot;
					Model.transform.localScale = StartScale /*+ new Vector3 (0.9f, 0.9f, 0.9f)*/;
				}
				Orientation = 1;
			} else if (Screen.height > Screen.width) {
				Slider.GetComponent<RectTransform> ().localPosition = new Vector3 (0, 255);
				Button4.transform.localPosition = new Vector3 (0, 192, 0);
				if (Orientation == 1) {
					Model.transform.localPosition = StartPos;
					Model.transform.localRotation = StartRot;
					Model.transform.localScale = StartScale;
				}
				Orientation = 0;
			}

			//Закрыть при нажатии кнопки "назад"
			if (Input.GetKeyDown(KeyCode.Escape)) {
				Model.transform.localPosition = StartPos;
				Model.transform.localRotation = StartRot;
				Model.transform.localScale = StartScale;
				ObjPanel.SetActive (false);
				Logo.SetActive (true);
				Button1.SetActive (true);
				Button2.SetActive (true);
				Button3.SetActive (true);
				if (Screen.height < Screen.width)
					Button4.transform.localPosition = new Vector3 (0, PY2, 0);
				else
					Button4.transform.localPosition = new Vector3 (0, PY1, 0);
				Push = false;
				foreach (GameObject Target in Targets)
					Target.SetActive (true);

				Text_3D.GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 255);
				Anim.GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 255);
			}

			Scaling = false;
		} else {
			if (Screen.height < Screen.width)
				Orientation = 1;
			else
				Orientation = 0;
		}
	}

	void LateUpdate() {
		if (Logo.activeSelf)
			GlobalVar.Exit = true;
	}
}
