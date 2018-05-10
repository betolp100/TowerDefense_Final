using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyNode : MonoBehaviour {

    protected static DontDestroyNode instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }



}
