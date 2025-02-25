using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Obiekt, kt�ry kamera ma �ledzi�
    public float followSpeed = 5f;  // Szybko�� ruchu kamery
    public Vector2 deadZoneSize = new Vector2(2f, 2f); // Rozmiar martwej strefy (kwadrat)

    public Vector3 targetPosition; // Pozycja, do kt�rej kamera ma si� porusza�

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

        Vector3 delta = target.position - transform.position; // R�nica mi�dzy kamer� a targetem DELTA - na skilky peresunutys

        // Sprawdzamy, czy target opu�ci� martw� stref�
        if (Mathf.Abs(delta.x) > deadZoneSize.x || Mathf.Abs(delta.y) > deadZoneSize.y)
        {
            // Je�li target wyjdzie poza martw� stref�, kamera zaczyna go �ledzi�
            targetPosition = new Vector3(target.position.x, target.position.y, -10f);
        }
        else
        {
            // Je�li target si� zatrzyma�, kamera wraca do jego centrum
            //targetPosition = new Vector3(target.position.x, target.position.y, -10f);
        }

        // P�ynne przemieszczanie kamery w kierunku targetPosition
        transform.position = Vector3.Lerp(transform.position, targetPosition, MathF.Pow(followSpeed * Time.deltaTime, 1));
    }
}

/*
    OPIS DZIA�ANIA KODU:

    1. `Transform target`: Obiekt, kt�ry kamera ma �ledzi�.
    2. `followSpeed`: Kontroluje szybko�� ruchu kamery.
    3. `deadZoneSize`: Wielko�� martwej strefy (obszar, w kt�rym kamera si� nie rusza).
    4. `targetPosition`: Pozycja, do kt�rej kamera d��y.

    - **Start():** Kamera zaczyna na pozycji targeta.
    - **Update():**
      - Je�li target jest w martwej strefie, kamera nie rusza si�.
      - Gdy target wyjdzie poza martw� stref�, kamera zaczyna go �ledzi�.
      - Je�li target si� zatrzyma, kamera wraca do jego �rodka.
    - **Lerp()** zapewnia p�ynny ruch kamery.

    Efekt: Target **zawsze jest w centrum kamery**, ale kamera rusza si� tylko wtedy, gdy gracz opu�ci martw� stref�.
*/
