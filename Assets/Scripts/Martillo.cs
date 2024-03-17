using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Martillo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Roca"))
        {
            //Le manda al gamemanager el game object al que le va a aplicar el destroy
            GameManager.instance.collectable = collision.GameObject();
            //llama funci�n activa destroy
            Collectable.instance.activaDestry();
            Debug.Log("activaDestroy");
            //funci�n para sumar un pickup
            GameManager.instance.AddCoins(1);

        }
    }
}
