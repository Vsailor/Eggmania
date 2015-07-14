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
            //GameObject.Find("Grass").GetComponent<GrassScript>().IsActive = true;
            MainCamera.GetComponent<EggsScript>().IsActive = true;
        }
        if (this.name == "PlayAgainButton")
        {
            MainCamera.transform.position = new Vector3(2500, 0, -10f);
            MainCamera.GetComponent<MenuResolutionScript>().SceneName = "Play";
            MainCamera.GetComponent<EggsScript>().IsActive = true;
            for (int i = 1; i <= 3; i++)
            {
                GameObject.Find("Health" + i).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (this.name == "Quit" || this.name == "QuitButton")
        {
            Application.Quit();
        }
        if (this.name == "WriteAReviewButton")
        {
            

        }
    }

	
	void Update () {
	
	}
}
