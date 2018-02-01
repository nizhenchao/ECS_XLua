using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LoaderThread : MonoBehaviour
{
    private static LoaderThread instance;
    public static LoaderThread Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

}

