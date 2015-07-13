using UnityEngine;
using System.Collections;

public class GrassScript : MonoBehaviour {
    public bool IsActive = false;
    bool Inited = false;

    void Init()
    {
        print(1);


    }
	
	void Update () {
        if (IsActive)
        {
            if (!Inited)
            {
                Inited = true;
                Init();
            }
        }
        else
        {
            Inited = false;
        }
	}
}
