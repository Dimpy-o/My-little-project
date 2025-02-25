using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Obiekt, który kamera ma œledziæ
    public float followSpeed = 5f;  // Szybkoœæ ruchu kamery
    public Vector2 deadZoneSize = new Vector2(2f, 2f); // Rozmiar martwej strefy (kwadrat)

    public Vector3 targetPosition; // Pozycja, do której kamera ma siê poruszaæ

    void Start()
    {
        if (target != null)
        {
            targetPosition = target.position;  // Kamera startuje na pozycji targeta
        }
    }

    void Update()
    {
        if (target == null) return; // Sprawdzenie, czy target istnieje

        Vector3 delta = target.position - transform.position; // Ró¿nica miêdzy kamer¹ a targetem DELTA - na skilky peresunutys

        // Sprawdzamy, czy target opuœci³ martw¹ strefê
        if (Mathf.Abs(delta.x) > deadZoneSize.x || Mathf.Abs(delta.y) > deadZoneSize.y)
        {
            // Jeœli target wyjdzie poza martw¹ strefê, kamera zaczyna go œledziæ
            targetPosition = new Vector3(target.position.x, target.position.y, -10f);
        }
        else
        {
            // Jeœli target siê zatrzyma³, kamera wraca do jego centrum
            //targetPosition = new Vector3(target.position.x, target.position.y, -10f);
        }

        // P³ynne przemieszczanie kamery w kierunku targetPosition
        transform.position = Vector3.Lerp(transform.position, targetPosition, MathF.Pow(followSpeed * Time.deltaTime, 1));
    }
}

/*
    OPIS DZIA£ANIA KODU:

    1. `Transform target`: Obiekt, który kamera ma œledziæ.
    2. `followSpeed`: Kontroluje szybkoœæ ruchu kamery.
    3. `deadZoneSize`: Wielkoœæ martwej strefy (obszar, w którym kamera siê nie rusza).
    4. `targetPosition`: Pozycja, do której kamera d¹¿y.

    - **Start():** Kamera zaczyna na pozycji targeta.
    - **Update():**
      - Jeœli target jest w martwej strefie, kamera nie rusza siê.
      - Gdy target wyjdzie poza martw¹ strefê, kamera zaczyna go œledziæ.
      - Jeœli target siê zatrzyma, kamera wraca do jego œrodka.
    - **Lerp()** zapewnia p³ynny ruch kamery.

    Efekt: Target **zawsze jest w centrum kamery**, ale kamera rusza siê tylko wtedy, gdy gracz opuœci martw¹ strefê.
*/
