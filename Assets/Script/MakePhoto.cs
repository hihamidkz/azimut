using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class MakePhoto : MonoBehaviour {

	public Button button;

	public GameObject[] Objects;

	private Texture2D TD;

	void Start() {
		button.onClick.AddListener (MakeScreenShot);
	}

	void MakeScreenShot() {
		StartCoroutine (DoSomething ());
	}

	IEnumerator DoSomething() {
		foreach (GameObject Object in Objects)
			Object.GetComponent<Image>().color = new Color(255, 255, 255, 0);
		yield return new WaitForEndOfFrame ();

		TD = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
		TD.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
		TD.Apply ();

		foreach (GameObject Object in Objects)
			Object.GetComponent<Image>().color = new Color(255, 255, 255, 255);

		yield return new WaitForEndOfFrame ();

		byte[] bytes = TD.EncodeToPNG ();
		Object.Destroy (TD);

		int i;

		if (!Directory.Exists("/storage/emulated/0/DCIM/Азимут-Н"))
			Directory.CreateDirectory("/storage/emulated/0/DCIM/Азимут-Н");

		for (i = 0;; i++) {
			if (!File.Exists ("/storage/emulated/0/DCIM/Азимут-Н/Saved-" + i + ".png")) {
				File.WriteAllBytes ("/storage/emulated/0/DCIM/Азимут-Н/Saved-" + i + ".png", bytes);
				break;
			}
		}
	}

}
