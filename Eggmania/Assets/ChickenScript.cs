using UnityEngine;
using System.Collections;

public class ChickenScript : MonoBehaviour {
    private GameObject MainCamera;
	void Start () {
        this.GetComponent<Animator>().Play("StillStay");
        MainCamera = GameObject.Find("Main Camera");
	}
	
	void Update () {
        if (MainCamera.GetComponent<MenuResolutionScript>().SceneName == "Play")
        {
            if (this.name == "ChickenLeftDown")
            {
                this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 15f, Screen.height / 2.8f, 1.8f));
            }
            if (this.name == "ChickenLeftUp")
            {
                this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 15f, Screen.height / 1.9f, 2));
            }
            if (this.name == "ChickenRightDown")
            {
                this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - Screen.width / 15f, Screen.height / 2.8f, 1.8f));
            }
            if (this.name == "ChickenRightUp")
            {
                this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - Screen.width / 15f,Screen.height / 1.9f, 2));
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Animator>().Play("ChickenAnimation");
            
        }
    }
}
