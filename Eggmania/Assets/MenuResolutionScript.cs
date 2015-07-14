using UnityEngine;
using System.Collections;

public class MenuResolutionScript : MonoBehaviour
{
    public string SceneName = "MainMenu";
    public GameObject LeftEggs;
    public GameObject RightEggs;
    public GameObject MainMenuBackGround;
    public GameObject PlayBackground;
    public GameObject LeftArrows;
    public GameObject RightArrows;
    public GameObject FoxesLeft;
    public GameObject FoxesRight;
    //public GameObject Grass;
    public GameObject Bg2;
    public GameObject Bg3;
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
    void SetChickenBackgrounds(float x, float y, float z)
    {
        Bg2.transform.localScale = new Vector3(x, y, z);
        Bg3.transform.localScale = new Vector3(x, y, z);
    }
    void Start()
    {
        ToResizeGameObjects = new System.Collections.Generic.List<GameObject>();
        ToResizeGameObjects.AddRange(new[] { MainMenuBackGround, PlayBackground });
        MainCamera = GameObject.Find("Main Camera");
    }
    void SetSmallChickensPositions()
    {
        var leftDownEggBrokenPos = GameObject.Find("LeftDownEggBroken").transform.position;
        var leftWidth = leftDownEggBrokenPos.x - Camera.main.ScreenToWorldPoint(this.transform.localScale).x;
        var rightDownEggBrokenPos = GameObject.Find("RightDownEggBroken").transform.position;
        var space = leftWidth / 4.5f;
        for (int i = 1; i <= 4; i++)
        {
            var item = GameObject.Find("SmallChickenLeft" + i);
            item.transform.position = new Vector3(leftDownEggBrokenPos.x - space * i, item.transform.position.y, item.transform.position.z);
            var item2 = GameObject.Find("SmallChickenRight" + i);
            item2.transform.position = new Vector3(rightDownEggBrokenPos.x + space * i, item2.transform.position.y, item2.transform.position.z);
        }

    }
    void SetArrowsPositions(float left, float right)
    {
        LeftArrows.transform.position = new Vector3(left, LeftArrows.transform.position.y, LeftArrows.transform.position.z);
        RightArrows.transform.position = new Vector3(right, RightArrows.transform.position.y, RightArrows.transform.position.z);
    }
    void SetFoxesPositions(float left, float right)
    {
        FoxesLeft.transform.position = new Vector3(left, FoxesLeft.transform.position.y, FoxesLeft.transform.position.z);
        FoxesRight.transform.position = new Vector3(right, FoxesRight.transform.position.y, FoxesRight.transform.position.z);
    }

    void SetEggsPositions(float left, float right)
    {
        LeftEggs.transform.position = new Vector3(left, LeftEggs.transform.position.y, LeftEggs.transform.position.z);
        RightEggs.transform.position = new Vector3(right, RightEggs.transform.position.y, RightEggs.transform.position.z);
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
                SetChickenBackgrounds(1.24f, 1f, 1f);
                SetEggsPositions(2493.5f, 2496.2f);
                SetArrowsPositions(2498.4f, 2502.6f);
                SetFoxesPositions(2499.47f, 2502.26f);
            }
            else if (resolution == "1.78")
            {
                SetLocalScale(1.51f, 1.27f, 1f);
                SetChickenBackgrounds(1.28f, 1f, 1f);
            }
            else if (resolution == "1.77")
            {
                SetLocalScale(1.51f, 1.27f, 1f);
                SetChickenBackgrounds(1.28f, 1f, 1f);
                SetEggsPositions(2493.2f, 2496.5f);
                SetArrowsPositions(2498.01f, 2502.9f);
                SetFoxesPositions(2499.21f, 2502.53f);
            }
            else if (resolution == "1.66")
            {
                SetLocalScale(1.41f, 1.27f, 1f);
                SetChickenBackgrounds(1.21f, 1f, 1f);
                SetEggsPositions(2493.7f, 2495.9f);
                SetArrowsPositions(2498.63f, 2502.25f);
                SetFoxesPositions(2499.68f, 2501.9f);
            }
            else if (resolution == "1.5" || resolution == "1.50" || resolution == "1.49")
            {
                SetLocalScale(1.27f, 1.27f, 1f);
                SetChickenBackgrounds(1.1f, 1f, 1f);
                SetEggsPositions(2494.3f, 2495.4f);
                SetArrowsPositions(2499.5f, 2501.3f);
                SetFoxesPositions(2500.28f, 2501.41f);
            }
            else if (resolution == "1.60" || resolution == "1.6" || resolution == "1.59")
            {
                SetLocalScale(1.36f, 1.27f, 1f);
                SetChickenBackgrounds(1.17f, 1f, 1f);
                SetEggsPositions(2493.9f, 2495.7f);
                SetArrowsPositions(2499f, 2501.93f);
                SetFoxesPositions(2499.87f, 2501.73f);
            }
            else if (resolution == "1.25")
            {
                SetLocalScale(1.06f, 1.27f, 1f);
            }
            else if (resolution == "1.33")
            {
                SetLocalScale(1.13f, 1.27f, 1f);
            }
            SetSmallChickensPositions();
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
