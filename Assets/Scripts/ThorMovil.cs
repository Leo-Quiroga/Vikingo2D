using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ThorMovil : MonoBehaviour
{
    public Transform[] puntosMovimiento;
    public float velocidadMovimiento;
    private int siguientePlataforma;
    private bool ordenPlataformas = true;

    public GameObject prefab;

    public float intervaloTiempo = 1f; // Variable para controlar el intervalo de tiempo en segundos

    private void Start()
    {
        // Iniciar la corutina cuando se inicie el objeto
        StartCoroutine(EjecutarCadaTiempo());

    }
    private void Update()
    {
        if (ordenPlataformas && siguientePlataforma + 1 >= puntosMovimiento.Length)
        {
            ordenPlataformas = false;
        }
        if (!ordenPlataformas && siguientePlataforma <= 0)
        {
            ordenPlataformas = true;
        }
        if (Vector2.Distance(transform.position, puntosMovimiento[siguientePlataforma].position) < 0.1f)
        {
            if (ordenPlataformas)
            {
                siguientePlataforma += 1;
            }
            else
            {
                siguientePlataforma -= 1;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguientePlataforma].position, velocidadMovimiento * Time.deltaTime);
    }

   
    IEnumerator EjecutarCadaTiempo()
    {
        while (true) // Bucle infinito para que se ejecute permanentemente
        {

            // Esperar el intervalo de tiempo especificado antes de continuar
            yield return new WaitForSeconds(intervaloTiempo);

            // se instancia el prefab cada cierto tiempo
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}

