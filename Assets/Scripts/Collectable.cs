using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public static Collectable instance;

    private void Awake()
    {
        instance = this;
    }

    public void activaDestry()
    {
       GameManager.instance.DestroyCollectable();
       
        Debug.Log("sCRIP ROCA");
    }
    
}
