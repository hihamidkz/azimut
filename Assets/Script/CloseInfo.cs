using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseInfo : MonoBehaviour {

	public GameObject But1, But2, But3, But4;
	public GameObject Logo;
	public GameObject InfoPanel;
	public GameObject AboutAppVert;
	public GameObject AboutAppHoriz;
	public GameObject Tar1, Tar2;

	public Button CloseAboutAppHoriz;
	public Button Close;

	private bool Inform = false;

	void Start() {
		InfoPanel.SetActive(false);
		AboutAppVert.SetActive(false);
		AboutAppHoriz.SetActive(false);

		Button CloseVert = Close.GetComponent<Button> ();
		Button CloseHoriz = CloseAboutAppHoriz.GetComponent<Button> ();
		Button Inf = But1.GetComponent<Button> ();
		CloseVert.onClick.AddListener (OnClose);
		CloseHoriz.onClick.AddListener (OnClose);
		Inf.onClick.AddListener (Info);

		Close.gameObject.SetActive (false);
		CloseAboutAppHoriz.gameObject.SetActive (false);
	}

	void Info()
	{
		Inform = true;
		GlobalVar.Exit = false;

		But1.gameObject.SetActive(false);
		But2.gameObject.SetActive(false);
		But3.gameObject.SetActive(false);
		But4.gameObject.SetActive(false);
		Logo.SetActive(false);
		Tar1.SetActive(false);
		Tar2.SetActive(false);

		InfoPanel.SetActive(true);

		if (Screen.height > Screen.width) {
			AboutAppVert.SetActive (true);
			AboutAppHoriz.SetActive (false);
			InfoPanel.transform.GetChild(0).gameObject.SetActive(true);
			InfoPanel.transform.GetChild(1).gameObject.SetActive(false);
			Close.gameObject.SetActive(true);
			CloseAboutAppHoriz.gameObject.SetActive (false);
		} else {
			AboutAppHoriz.SetActive (true);
			AboutAppVert.SetActive (false);
			InfoPanel.transform.GetChild(1).gameObject.SetActive(true);
			InfoPanel.transform.GetChild(0).gameObject.SetActive(false);
			CloseAboutAppHoriz.gameObject.SetActive (true);
			Close.gameObject.SetActive(false);
		}
	}

	void OnClose() {
		InfoPanel.SetActive (false);
		AboutAppVert.SetActive (false);
		AboutAppHoriz.SetActive (false);
		Close.gameObject.SetActive (false);
		CloseAboutAppHoriz.gameObject.SetActive (false);

		But1.SetActive (true);
		But2.SetActive (true);
		But3.SetActive (true);
		But4.SetActive (true);
		Logo.SetActive (true);
		Tar1.SetActive (true);
		Tar2.SetActive (true);
		Inform = false;
	}

	void Update() {
		if (Inform) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				InfoPanel.SetActive (false);
				AboutAppVert.SetActive (false);
				AboutAppHoriz.SetActive (false);
				Close.gameObject.SetActive (false);
				CloseAboutAppHoriz.gameObject.SetActive (false);

				But1.SetActive (true);
				But2.SetActive (true);
				But3.SetActive (true);
				But4.SetActive (true);
				Logo.SetActive (true);
				Tar1.SetActive (true);
				Tar2.SetActive (true);
				Inform = false;
			}

			if (Screen.height < Screen.width && AboutAppVert.activeSelf) {
				AboutAppHoriz.SetActive (true);
				AboutAppVert.SetActive (false);
				InfoPanel.transform.GetChild (1).gameObject.SetActive (true);
				InfoPanel.transform.GetChild (0).gameObject.SetActive (false);
				CloseAboutAppHoriz.gameObject.SetActive (true);
				Close.gameObject.SetActive (false);
			} else if (Screen.height > Screen.width && AboutAppHoriz.activeSelf) {
				AboutAppVert.SetActive (true);
				AboutAppHoriz.SetActive (false);
				InfoPanel.transform.GetChild(0).gameObject.SetActive(true);
				InfoPanel.transform.GetChild(1).gameObject.SetActive(false);
				Close.gameObject.SetActive(true);
				CloseAboutAppHoriz.gameObject.SetActive (false);
			}
		}
	}
}
