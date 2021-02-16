using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseAnim : MonoBehaviour {

	public GameObject Anim1;
	public GameObject Anim2;
	public GameObject ScrollView, VertScrollView;
	public Button btn1, btn2, btn3, btn4;
	public GameObject Logo;

	public GameObject Tar1, Tar2;

	public Button Close;

	void Start() {
		Button btn = Close.GetComponent<Button> ();
		btn.onClick.AddListener (OnClose);
	}

	void OnClose() {
		Anim1.SetActive (false);
		Anim2.SetActive (false);
		ScrollView.SetActive (false);
		VertScrollView.SetActive (false);
		btn1.gameObject.SetActive (true);
		btn2.gameObject.SetActive (true);
		btn3.gameObject.SetActive (true);
		btn4.gameObject.SetActive (true);
		Logo.SetActive (true);
		Tar1.SetActive (true);
		Tar2.SetActive (true);
		Close.gameObject.SetActive (false);
	}
}
