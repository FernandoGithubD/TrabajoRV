using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    Rigidbody miRigidBody;
    public float velocidad = 5.0f; // Velocidad del movimiento
    public float saltoFuerza = 200.0f; // Fuerza del salto
    private bool enSuelo = true; // Variable para verificar si el jugador está en el suelo

    // Start is called before the first frame update
    void Start()
    {
        miRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        // Calcula el vector de movimiento
        Vector3 movimiento = new Vector3(horizontal, 0, vertical) * (velocidad * 0.0001f);

        // Aplica la fuerza al Rigidbody para mover al personaje
        miRigidBody.AddForce(movimiento);

        // Salto
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            miRigidBody.AddForce(Vector3.up * saltoFuerza);
            enSuelo = false; // El jugador ya no está en el suelo
        }
    }

    // Detecta si el personaje está en el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true; // El jugador está en el suelo
        }
    }
}
