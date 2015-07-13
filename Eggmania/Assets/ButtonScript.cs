using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
    private GameObject MainCamera;
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }
    void OnMouseDown()
    {
        if (this.name == "PlayButton")
        {
            MainCamera.transform.position = new Vector3(2500, 0, -10f);
            MainCamera.GetComponent<MenuResolutionScript>().SceneName = "Play";
            GameObject.Find("Grass").GetComponent<GrassScript>().IsActive = true;
        }
        if (this.name == "WriteAReviewButton")
        {


        }
        if (this.name == "QuitButton")
        {
            Application.Quit();
        }
    }

	
	void Update () {
	
	}
}
