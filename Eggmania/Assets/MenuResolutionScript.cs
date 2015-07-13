using UnityEngine;
using System.Collections;

public class MenuResolutionScript : MonoBehaviour {
    public string SceneName = "MainMenu";
    public GameObject MainMenuBackGround;
    public GameObject PlayBackground;
    public GameObject Grass;
    public bool IsActive = true;
    private GameObject MainCamera;
    System.Collections.Generic.List<GameObject> ToResizeGameObjects;
    void SetLocalScale(float x, float y, float z)
    {
        foreach (var item in ToResizeGameObjects)
        {
            item.transform.localScale = new Vector3(x, y, z);
        }
    }
    void Start()
    {
        ToResizeGameObjects = new System.Collections.Generic.List<GameObject>();
        ToResizeGameObjects.AddRange(new[] { MainMenuBackGround, PlayBackground, Grass });
        MainCamera = GameObject.Find("Main Camera");
    }
    void OnGUI()
    {
        if (IsActive)
        {
            var resolution = string.Empty;
            try
            {
                resolution = (Screen.width * 1.0 / Screen.height * 1.0).ToString().Substring(0, 4);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                resolution = (Screen.width * 1.0 / Screen.height * 1.0).ToString();
            }
            if (resolution == "1.70" || resolution == "1.7")
            {
                SetLocalScale(1.44f, 1.27f, 1f);
            }
            else if (resolution == "1.78")
            {
                SetLocalScale(1.51f, 1.27f, 1f);
            }
            else if (resolution == "1.77")
            {
                SetLocalScale(1.51f, 1.27f, 1f);
            }
            else if (resolution == "1.66")
            {
                SetLocalScale(1.41f, 1.27f, 1f);
            }
            else if (resolution == "1.5" || resolution == "1.50")
            {
                SetLocalScale(1.27f, 1.27f, 1f);
            }
            else if (resolution == "1.60" || resolution == "1.6" || resolution == "1.59")
            {
                SetLocalScale(1.36f, 1.27f, 1f);
            }
            else if (resolution == "1.25")
            {
                SetLocalScale(1.06f, 1.27f, 1f);
            }
            else if (resolution == "1.33")
            {
                SetLocalScale(1.13f, 1.27f, 1f);
            }
        }
    }
    void Update()
    {
        if (SceneName == "MainMenu")
        {
            MainCamera.GetComponent<Camera>().orthographicSize = 4.27f;
        }
        if (SceneName == "Play")
        {
            MainCamera.GetComponent<Camera>().orthographicSize = 6.86f;
        }
    }
}
