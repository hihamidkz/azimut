using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Set : MonoBehaviour
{

    public GameObject Photo1;
    public GameObject Anim1;
    public GameObject Anim2;
    public GameObject Logo;
    public GameObject ScrollView, VertScrollView;

    public GameObject Tar1, Tar2;

    public Button InfoButton;
    public Button MoreInfo;
    public Button ExitButton;
    public Button Photo;
    public Button Close_Vertical;
    public Button Close_Horizontal;

    void Start()
    {
        ScrollView.SetActive(false);
		VertScrollView.SetActive(false);

		Close_Horizontal.gameObject.SetActive (false);
		Close_Vertical.gameObject.SetActive (false);
        Photo1.SetActive(false);
        Anim1.SetActive(false);
        Anim2.SetActive(false);
        Button btn = InfoButton.GetComponent<Button>();
        Button exb = ExitButton.GetComponent<Button>();
        btn.onClick.AddListener(Animate);
        exb.onClick.AddListener(OnExitClick);
    }

    void Animate()
    {
        GlobalVar.Exit = false;

        InfoButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
        MoreInfo.gameObject.SetActive(false);
        Photo.gameObject.SetActive(false);
        Logo.SetActive(false);
        Tar1.SetActive(false);
        Tar2.SetActive(false);

        if (Screen.height < Screen.width)
        {
			Anim2.SetActive(true);
			Close_Horizontal.gameObject.SetActive(true);
			ScrollView.SetActive(true);
		} else if (Screen.height > Screen.width) {
			Anim1.SetActive (true);
			Close_Vertical.gameObject.SetActive(true);
			VertScrollView.SetActive(true);
        }
    }

    void OnExitClick()
    {
        Application.Quit();
    }

    void Update()
    {
		Debug.Log (Photo.transform.localPosition);

        if (GlobalVar.Exit)
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();

        if (Anim2.activeSelf == true && Screen.height > Screen.width)
        {
            Anim1.SetActive(true);
			VertScrollView.SetActive (true);
            Close_Vertical.gameObject.SetActive(true);
            Close_Horizontal.gameObject.SetActive(false);
            ScrollView.SetActive(false);
            Anim2.SetActive(false);
        }
        else if (Anim1.activeSelf == true && Screen.height < Screen.width)
        {
            Anim2.SetActive(true);
            ScrollView.SetActive(true);
            Close_Horizontal.gameObject.SetActive(true);
            Anim1.SetActive(false);
			VertScrollView.SetActive (false);
            Close_Vertical.gameObject.SetActive(false);
        }

        if (Anim1.activeSelf == true || Anim2.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Anim1.SetActive(false);
                Anim2.SetActive(false);
                ScrollView.SetActive(false);
				VertScrollView.SetActive(false);
                Close_Vertical.gameObject.SetActive(false);
                Close_Horizontal.gameObject.SetActive(false);
                ExitButton.gameObject.SetActive(true);
                MoreInfo.gameObject.SetActive(true);
                Photo.gameObject.SetActive(true);
                Logo.SetActive(true);
                Tar1.SetActive(true);
                Tar2.SetActive(true);
            }
        }
        else if (Logo.activeSelf == true)
            InfoButton.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        if (Logo.activeSelf)
            GlobalVar.Exit = true;
    }
}
