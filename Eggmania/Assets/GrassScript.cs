using UnityEngine;
using System.Collections;

public class GrassScript : MonoBehaviour {
    public bool IsActive = false;
    bool Inited = false;

    void Init()
    {

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
