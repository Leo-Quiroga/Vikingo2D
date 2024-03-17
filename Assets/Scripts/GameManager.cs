using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int currentCoins;
    public Text textCollectable;
    public GameObject collectable;

    

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        AddCoins(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(int suma)
    {
        currentCoins += suma;
        textCollectable.text = "" + currentCoins;
        Debug.Log(currentCoins);
    }

    public void DestroyCollectable()
    {
        Destroy(collectable);
    }
}
