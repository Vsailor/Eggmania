using UnityEngine;
using System.Collections;

public class ChickenScript : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
        if (this.name == "ChickenLeftDown")
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 15f, Screen.height / 2 + Screen.height / 30f, 2));
        }
        if (this.name == "ChickenLeftUp")
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 15f, Screen.height - Screen.height / 6f, 2));
        }
        if (this.name == "ChickenRightDown")
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - Screen.width / 15f, Screen.height / 2 + Screen.height / 30f, 2));
        }
        if (this.name == "ChickenRightUp")
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - Screen.width / 15f, Screen.height - Screen.height/6f, 2));
        }
    }
}
