using UnityEngine;
using System.Collections;

public class ArrowButtonScript : MonoBehaviour
{
    public GameObject DownLeftFox;
    public GameObject DownRightFox;
    public GameObject UpLeftFox;
    public GameObject UpRightFox;
    private System.Collections.Generic.List<GameObject> Foxes;
    void SetUnvisibleAll()
    {
        foreach (var item in Foxes)
        {
            item.SetActive(false);
        }
    }
    void Start()
    {
        Foxes = new System.Collections.Generic.List<GameObject>();
        Foxes.AddRange(new[] { DownLeftFox, DownRightFox, UpLeftFox, UpRightFox });
        SetUnvisibleAll();
        DownRightFox.SetActive(true);
    }
    void OnMouseDown()
    {
        SetUnvisibleAll();
        if (this.name == "ArrowDownLeft")
        {
            DownLeftFox.SetActive(true);
        }
        else if (this.name == "ArrowDownRight")
        {
            DownRightFox.SetActive(true);
        }
        else if (this.name == "ArrowUpLeft")
        {
            UpLeftFox.SetActive(true);
        }
        else if (this.name == "ArrowUpRight")
        {
            UpRightFox.SetActive(true);
        }
    }
}
