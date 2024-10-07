using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Desactiva la bala al colisionar con cualquier objeto
        gameObject.SetActive(false);
    }
}
