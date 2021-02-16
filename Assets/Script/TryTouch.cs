using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Vuforia;

public class TryTouch : MonoBehaviour, ITrackableEventHandler
{

    public GameObject Photo1;
    public GameObject Panel;
    public GameObject Logo;
    public GameObject Button1, Button2, Button3, btn4;
    public GameObject Kontur, Hand;

    private TrackableBehaviour mTrack;

    public GameObject[] Targets;
    public GameObject MyTarget;

    public Sprite Photo;

    private bool Push = false;
    private bool Change = false;
    private bool Tracking = false;

    private int orientation = 1;
    private float minX = 0.9803922f, minY = 0.9803922f;
    private float maxX = 3.0f, maxY = 3.0f;
    private float posX, posY, posZ;

    void Start()
    {
        mTrack = MyTarget.GetComponent<TrackableBehaviour>();
        if (mTrack)
            mTrack.RegisterTrackableEventHandler(this);
        posX = Photo1.transform.localPosition.x;
        posY = Photo1.transform.localPosition.y;
        posZ = Photo1.transform.localPosition.z;
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED)
            Tracking = true;
        else
            Tracking = false;
    }

    //Нажатие на контур
    void OnMouseDown()
    {
        bool Allow = Mathf.Abs(transform.position.x - Button1.transform.position.x) > 15 || Mathf.Abs(transform.position.y - Button1.transform.position.y) > 15;

        if (Allow && Tracking)
        {
            GlobalVar.Exit = false;

            foreach (GameObject Target in Targets)
                Target.SetActive(false);

            Kontur.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            Hand.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);

            Photo1.GetComponent<UnityEngine.UI.Image>().sprite = Photo;
            Logo.SetActive(false);
            Button1.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);
            btn4.SetActive(false);
            Photo1.SetActive(true);

            if (Screen.height < Screen.width)
            {
                Photo1.transform.localScale = new Vector3(0.91f, 1.29f, 0.9803922f);
                Photo1.transform.localPosition = new Vector3(posX, posY, posZ);
            }
            else
            {
                Photo1.transform.localScale = new Vector3(0.91f, 0.9803922f, 0.9803922f);
                Photo1.transform.localPosition = new Vector3(posX, posY, posZ);
            }

            Panel.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 255);
            Push = true;
        }
    }

    void Update()
    {
        float tX, tY, tZ;

        if (Push)
        {
            if (Screen.height < Screen.width && orientation == 1)
            {
                minY = 1.29f;
                Photo1.transform.localScale = new Vector3(0.91f, 1.29f, 0.9803922f);
                Photo1.transform.localPosition = new Vector3(posX, posY, posZ);
                orientation = 0;
            }
            else if (Screen.height > Screen.width && orientation == 0)
            {
                minY = 0.9803922f;
                Photo1.transform.localScale = new Vector3(0.91f, 0.9803922f, 0.9803922f);
                Photo1.transform.localPosition = new Vector3(posX, posY, posZ);
                orientation = 1;
            }

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                //if (Change) {
                Photo1.transform.Translate(new Vector3(touch.deltaPosition.x * 0.1f, touch.deltaPosition.y * 0.1f, 0));
                //}
            }
            else if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;

                tX = Photo1.transform.localScale.x - deltaMagDiff * 0.002f;
                tY = Photo1.transform.localScale.y - deltaMagDiff * 0.002f;
                tZ = Photo1.transform.localScale.z;
                if (tX > minX && tY > minY && tX < maxX && tY < maxY)
                {
                    Photo1.transform.localScale = new Vector3(tX, tY, tZ);

                    Change = true;
                }
                else
                    Change = false;
            }

            //Закрыть при нажатии кнопки "назад"
            if (Input.GetKeyDown(KeyCode.Escape))
            {
				Photo1.SetActive(false);
				Panel.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0);

                foreach (GameObject Target in Targets)
                    Target.SetActive(true);

                Kontur.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                Hand.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

                Logo.SetActive(true);
                Button1.SetActive(true);
                Button2.SetActive(true);
                Button3.SetActive(true);
                btn4.SetActive(true);
                
                Push = false;
                Change = false;
            }
        }
    }

    void LateUpdate()
    {
        if (Logo.activeSelf)
            GlobalVar.Exit = true;
    }
}
