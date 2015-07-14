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
                this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 15f, Screen.height / 3f, 2));
            }
            if (this.name == "ChickenLeftUp")
            {
                this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 15f, Screen.height / 2f, 2));
            }
            if (this.name == "ChickenRightDown")
            {
                this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - Screen.width / 15f, Screen.height / 3f, 2));
            }
            if (this.name == "ChickenRightUp")
            {
                this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - Screen.width / 15f,Screen.height / 2f, 2));
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Animator>().Play("ChickenAnimation");
            
        }
    }
}
