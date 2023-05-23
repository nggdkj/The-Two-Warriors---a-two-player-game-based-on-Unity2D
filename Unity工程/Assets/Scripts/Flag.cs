using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public static Flag pan;
    public bool flag1 = false;
    public bool flag2 = false;
    // Start is called before the first frame update
    void Start()
    {
        pan = this;
    }
    // Update is called once per frame
    public void Judge1()
    {
        flag1 = true;
    }
    public void Judge2()
    {
        flag2 = true;
    }
    public void Judge()
    {
        if(flag1==true && flag2==true)
        {
            GameController.Instance.ShowGoOn();
        }
    }
}
