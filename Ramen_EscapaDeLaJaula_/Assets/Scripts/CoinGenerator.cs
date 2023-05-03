using System.Collections;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public GameObject coinPrefab; // referencia al prefab de la moneda
    public float maxTime = 60f; // tiempo máximo entre cada generación de monedas
    public Vector2 minXZ; // la posición mínima en la zona de generación aleatoria en los ejes X y Z
    public Vector2 maxXZ; // la posición máxima en la zona de generación aleatoria en los ejes X y Z
    private float timer = 0f; // temporizador para controlar el tiempo

    // función que se llama en cada frame
    void Update() {

        // actualizamos el temporizador
        timer += Time.deltaTime;

        // si ha pasado el tiempo máximo, generamos una moneda
        if (timer >= maxTime) {

            // reiniciamos el temporizador
            timer = 0f;

            // generamos la posición aleatoria de la moneda dentro de la zona de generación
            Vector3 coinPosition = new Vector3(transform.position.x + Random.Range(minXZ.x, maxXZ.x), transform.position.y, transform.position.z + Random.Range(minXZ.y, maxXZ.y));

            // creamos la moneda en la posición aleatoria
            GameObject coin = Instantiate(coinPrefab, coinPosition, Quaternion.identity);

            // hacemos que la moneda sea hija del objeto generador
            coin.transform.parent = transform;

            // destruimos la moneda después de 10 segundos
            Destroy(coin, 10f);
            
        }
    }
}