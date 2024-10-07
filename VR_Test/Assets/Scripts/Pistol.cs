using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : MonoBehaviour
{
    public GameObject objectToCreate; // Prefab de la bala
    public int poolSize = 10; // Tamaño del pool de objetos
    public float launchSpeed = 20f; // Velocidad de la bala
    public float tiempoEntreDisparos = 0.5f; // Medio segundo entre disparos

    private float tiempoUltimoDisparo = 0f; // Tiempo del último disparo
    private List<GameObject> objectPool; // Lista para el pool de balas
    private int currentIndex = 0; // Índice para recorrer el pool

    void Start()
    {
        // Verificar si el prefab está asignado
        if (objectToCreate == null)
        {
            Debug.LogError("Error: El prefab 'objectToCreate' no está asignado en el Inspector.");
            return;
        }

        // Inicializa el pool con el tamaño especificado
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            // Crea los objetos (balas) y los desactiva inicialmente
            GameObject obj = Instantiate(objectToCreate);

            if (obj == null)
            {
                Debug.LogError("Error: Falló la creación de la bala desde el prefab.");
                return;
            }

            obj.SetActive(false); // Desactiva las balas hasta que se necesiten
            Debug.Log("Bala instanciada y desactivada: " + obj.name);

            objectPool.Add(obj); // Añade la bala al pool
        }

        Debug.Log("Pool inicializado correctamente con " + poolSize + " balas.");
    }


    // Método para disparar
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && PuedeDisparar())
        {
            Debug.Log("Intentando disparar...");

            // Obtiene una bala del pool
            GameObject bullet = GetPooledObject();

            if (bullet != null)
            {
                // Activa la bala y la posiciona correctamente
                bullet.SetActive(true);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;

                // Reinicia la velocidad del Rigidbody (en caso de que haya sido usado antes)
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = Vector3.zero; // Reinicia la velocidad
                    bulletRigidbody.angularVelocity = Vector3.zero; // Reinicia cualquier rotación acumulada

                    // Añade la fuerza para dispararla
                    bulletRigidbody.AddForce(transform.forward * launchSpeed, ForceMode.Impulse);
                }
                else
                {
                    Debug.LogError("Error: El objeto del pool no tiene un Rigidbody.");
                }

                // Actualiza el tiempo del último disparo
                tiempoUltimoDisparo = Time.time;
                Debug.Log("Disparo realizado correctamente.");
            }
            else
            {
                Debug.LogWarning("No hay balas disponibles en el pool.");
            }
        }
    }

    // Método para obtener un objeto del pool
    GameObject GetPooledObject()
    {
        // Recorre el pool y devuelve el primer objeto inactivo
        for (int i = 0; i < poolSize; i++)
        {
            int index = (currentIndex + i) % poolSize; // Usa un índice cíclico
            if (!objectPool[index].activeInHierarchy)
            {
                currentIndex = (index + 1) % poolSize; // Actualiza el índice para la siguiente vez
                return objectPool[index]; // Retorna el objeto inactivo
            }
        }

        // Si no hay objetos disponibles, retorna null
        Debug.LogWarning("No hay objetos disponibles en el pool.");
        return null;
    }

    // Verifica si ha pasado suficiente tiempo para permitir un nuevo disparo
    private bool PuedeDisparar()
    {
        bool puedeDisparar = Time.time >= tiempoUltimoDisparo + tiempoEntreDisparos;
        if (!puedeDisparar)
        {
            Debug.LogWarning("No se puede disparar todavía. Debes esperar.");
        }
        return puedeDisparar;
    }
}
