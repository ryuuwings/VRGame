using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VRGaze : MonoBehaviour { 
    public Image imgGaze;
    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;
    bool grabbed = false;
    bool throwed = true;
    public int distanceOfRay = 10;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray,out _hit, distanceOfRay)){
            if(imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Ball")&& !grabbed)
            {
                throwed = false;
                grabbed = true;
                _hit.transform.gameObject.GetComponent<PlayerGrab>().grab();
            }
            if(imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Teleport"))
            { 
                _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Destroyable") && grabbed)
            {
                _hit.transform.gameObject.GetComponent<PlayerGrab>().throwBall();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Start"))
            {
                SceneManager.LoadScene("SceneGame");
            }
            if(imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Exit"))
            {
                Application.Quit();
            }
        }
    }

    public void GVROn()
    {
        gvrStatus = true;
    }
    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}
