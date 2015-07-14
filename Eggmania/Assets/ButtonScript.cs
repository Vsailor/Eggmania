using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
    private GameObject MainCamera;
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }
    void SaveScores()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + @"\MaxScore"))
        {
            var maxScore = System.IO.File.ReadAllText(Application.persistentDataPath + @"\MaxScore");
            if (int.Parse(maxScore) < int.Parse(GameObject.Find("ScoreAmount").GetComponent<TextMesh>().text))
            {
                System.IO.File.WriteAllText(Application.persistentDataPath + @"\MaxScore", GameObject.Find("ScoreAmount").GetComponent<TextMesh>().text);
            }
        }
        else
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + @"\MaxScore", GameObject.Find("ScoreAmount").GetComponent<TextMesh>().text);
        }
    }
    void OnMouseDown()
    {
        if (this.name == "PlayButton")
        {
            MainCamera.transform.position = new Vector3(5000f, 0, -10f);
        }
        if (this.name == "Instruction")
        {
            MainCamera.transform.position = new Vector3(2500, 0, -10f);
            MainCamera.GetComponent<MenuResolutionScript>().SceneName = "Play";
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

        if (this.name == "QuitButton")
        {

            Application.Quit();
        }
        if (this.name == "Quit")
        {
            SaveScores();
            Application.Quit();
        }
        if (this.name == "WriteAReviewButton")
        {
            

        }
    }

	
	void Update () {
	
	}
}
