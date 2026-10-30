using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaculos;

    [Header("Tiempos de spawn")]
    public float tiempoMin = 0.7f;  // Se siente mucho más frenético si baja a 0.7 o 0.8
    public float tiempoMax = 2.2f;

    [Header("Variación de Altura (Opcional)")]
    public bool variarAltura = false; // Tildalo si querés que cambie de altura
    public float alturaMin = 0f;
    public float alturaMax = 1.5f;

    private int ultimoIndice = -1;

    void Start()
    {
        StartCoroutine(SpawnRutina());
    }

    IEnumerator SpawnRutina()
    {
        while (GameManager.instance == null || !GameManager.instance.juegoTerminado)
        {
           
            float espera = Random.Range(tiempoMin, tiempoMax);
            yield return new WaitForSeconds(espera);

            if (GameManager.instance == null || !GameManager.instance.juegoTerminado)
            {
                if (obstaculos.Length > 0)
                {
                    
                    int randomIndex;
                    do
                    {
                        randomIndex = Random.Range(0, obstaculos.Length);
                    } while (obstaculos.Length > 1 && randomIndex == ultimoIndice);

                    ultimoIndice = randomIndex;

                  
                    Vector3 posicionSpawn = transform.position;
                    if (variarAltura)
                    {
                        float yOffset = Random.Range(alturaMin, alturaMax);
                        posicionSpawn += new Vector3(0, yOffset, 0);
                    }

                    Instantiate(obstaculos[randomIndex], posicionSpawn, Quaternion.identity);
                }
            }
        }
    }
}