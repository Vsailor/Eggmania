using UnityEngine;
using System.Collections;

class Egg
{
    public string Name;
    public int Number;
    public GameObject EggObject;
    public bool ToDestroy = false;
    public Egg(string name)
    {
        Name = name;
        Number = 0;
        EggObject = GameObject.Find(name + Number);
    }
    public void ChickenAnimation()
    {
        if (Name == "LeftDownEgg")
        {
            GameObject.Find("ChickenLeftDown").GetComponent<Animator>().Play("ChickenAnimation");
        }
        else if (Name == "RightDownEgg")
        {
            GameObject.Find("ChickenRightDown").GetComponent<Animator>().Play("ChickenAnimation");
        }
        else if (Name == "RightUpEgg")
        {
            GameObject.Find("ChickenRightUp").GetComponent<Animator>().Play("ChickenAnimation");
        }
        else if (Name == "LeftUpEgg")
        {
            GameObject.Find("ChickenLeftUp").GetComponent<Animator>().Play("ChickenAnimation");
        }
    }
    public int Move()
    {
        if (Number != 0)
        {
            EggObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        Number++;
        if (Number == 7)
        {
            EggObject = GameObject.Find(Name + "Broken");
            EggObject.GetComponent<SpriteRenderer>().enabled = true;
            for (int i = 1; i <= 3; i++)
            {
                var obj = GameObject.Find("Health" + i);
                if (!obj.GetComponent<SpriteRenderer>().enabled)
                {
                    obj.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                }
                if (i == 3)
                {
                    System.IO.File.WriteAllText(Application.persistentDataPath + @"\Score", GameObject.Find("ScoreAmount").GetComponent<TextMesh>().text);
                    return -1;
                }
            }
            ChickenAnimation();
            return 1;
        }
        if (Number == 8 && (Name[0] == 'L' || Name[0] == 'R'))
        {
            if (Name[0] == 'L')
            {
                Number = 1;
                Name = "SmallChickenLeft";
                EggObject = GameObject.Find(Name + Number);
            }
            else if (Name[0] == 'R')
            {
                Number = 1;
                Name = "SmallChickenRight";
                EggObject = GameObject.Find(Name + Number);
            }
        }
        else if (Number >= 5 && (Name[0] == 'S'))
        {
            ToDestroy = true;
            return 1;
        }
        EggObject = GameObject.Find(Name + Number);
        EggObject.GetComponent<SpriteRenderer>().enabled = true;
        return 1;
    }
}

public class EggsScript : MonoBehaviour
{
    public GameObject DownLeftFox;
    public GameObject DownRightFox;
    public GameObject UpLeftFox;
    public GameObject UpRightFox;
    public bool IsActive = false;
    public int Step = 0;
    public float OldTime;
    public float Timer = 0;
    public float StartPlayingTime;
    private bool Inited = false;
    private float Interval = 1.3f;
    private int MaxEggsOnScreen = 3;
    private System.Collections.Generic.List<Egg> Eggs;
    private System.Random Rand;
    private GameObject ScoreAmount;

    void MoveEgg()
    {
        if (Step % Rand.Next(1, 5) == 0 && Eggs.Count<=MaxEggsOnScreen)
        {
            var rand = Rand.Next(1, 5);
            if (rand == 1)
            {
                Eggs.Add(new Egg("LeftDownEgg"));
            }
            if (rand == 2)
            {
                Eggs.Add(new Egg("RightDownEgg"));
            }
            if (rand == 3)
            {
                Eggs.Add(new Egg("LeftUpEgg"));
            }
            if (rand == 4)
            {
                Eggs.Add(new Egg("RightUpEgg"));
            }
        }
        for (int i = 0; i < Eggs.Count; i++)
        {
            if (Eggs[i].ToDestroy)
            {
                Eggs.RemoveAt(i);
            }
        }
        
        for (int i=0; i<Eggs.Count; i++)
        { 
            if (Eggs[i].Number == 5)
            {
                if ((Eggs[i].Name == "LeftDownEgg" && DownLeftFox.activeInHierarchy)
                    || (Eggs[i].Name == "RightDownEgg" && DownRightFox.activeInHierarchy)
                    || (Eggs[i].Name == "LeftUpEgg" && UpLeftFox.activeInHierarchy)
                    || (Eggs[i].Name == "RightUpEgg" && UpRightFox.activeInHierarchy))
                {
                    Eggs[i].EggObject.GetComponent<SpriteRenderer>().enabled = false;
                    Eggs.RemoveAt(i);
                    var score = ScoreAmount.GetComponent<TextMesh>();
                    score.text = (int.Parse(score.text) + 1).ToString();
                    if (int.Parse(score.text) % 10 == 0)
                    {
                        Interval *= 0.9f;
                    }
                }

            }
            if (i < Eggs.Count)
            {
                if (Eggs[i].Move() == -1)
                {
                    this.IsActive = false;
                    var MainCamera = GameObject.Find("Main Camera");
                    MainCamera.transform.position = new Vector3(-2500f, MainCamera.transform.position.y, MainCamera.transform.position.z);
                    MainCamera.GetComponent<MenuResolutionScript>().SceneName = "EndScreen";
                    // End
                }
                
            }
        }

    }

    private void Init()
    {
        if (Eggs != null)
        {
            foreach (var item in Eggs)
            {
                item.EggObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        Eggs = new System.Collections.Generic.List<Egg>();
        for (int i = 1; i <= 6; i++)
        {
            GameObject.Find("LeftDownEgg" + i).GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("LeftUpEgg" + i).GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("RightDownEgg" + i).GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("RightUpEgg" + i).GetComponent<SpriteRenderer>().enabled = false;
            if (i <= 4)
            {
                GameObject.Find("SmallChickenLeft" + i).GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("SmallChickenRight" + i).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        GameObject.Find("LeftDownEggBroken").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("RightDownEggBroken").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("LeftUpEggBroken").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("RightUpEggBroken").GetComponent<SpriteRenderer>().enabled = false;
        Rand = new System.Random();
        StartPlayingTime = Time.timeSinceLevelLoad;
        OldTime = 0;
        ScoreAmount = GameObject.Find("ScoreAmount");
        ScoreAmount.GetComponent<TextMesh>().text = "0";
    }
    void SetTimer()
    {
        var timer = GameObject.Find("Timer").GetComponent<TextMesh>();
        var secondsNow = (int)(Timer);
        var minutes = secondsNow / 60;
        if (minutes.ToString().Length == 1)
        {
            timer.text = "0" + minutes.ToString();
        }
        else
        {
            timer.text = minutes.ToString();
        }
        var seconds = secondsNow - minutes * 60;
        if (seconds.ToString().Length == 1)
        {
            timer.text += ":0" + seconds.ToString();
        }
        else
        {
            timer.text += ":" + seconds.ToString();
        }
    }
    void Update()
    {
        if (IsActive)
        {
            if (!Inited)
            {
                Init();
                Step = 0;
                Inited = true;
            }

            Timer = Time.timeSinceLevelLoad - StartPlayingTime;
            SetTimer();
            if (Timer - OldTime > Interval)
            {
                MoveEgg();
                Step++;
                OldTime = Timer;
            }
        }
        else
        {
            Inited = false;
        }
    }
}
