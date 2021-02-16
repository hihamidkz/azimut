using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishRotate : MonoBehaviour {

	public Slider Slider;

	private float prevVal;

	void Start () {
		prevVal = 0;

		Slider.onValueChanged.AddListener (OnValueChanged);
	}

	void OnValueChanged (float val) {
		gameObject.transform.RotateAround (gameObject.GetComponent<Renderer>().bounds.center, Vector3.down, Slider.value - prevVal);

		prevVal = Slider.value;
	}
}
