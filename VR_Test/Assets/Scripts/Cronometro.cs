using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Cronometro : MonoBehaviour
{
    // Start is called before the first frame update
    
    public TextMeshProUGUI tiempoText;
    private float tiempo; // Tiempo acumulado
    private bool corriendo = false; // Indica si el cronómetro está corriendo

    // Al iniciar el juego
    void Start()
    {
        tiempo = 0f; // Inicializamos el tiempo
        ActualizarTiempoText();
        IniciarCronometro();
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Si el cronómetro está corriendo, acumulamos tiempo
        if (corriendo)
        {
            tiempo += Time.deltaTime;
            ActualizarTiempoText();
        }
    }

    // Método para iniciar el cronómetro
    public void IniciarCronometro()
    {
        corriendo = true;
    }

    // Método para detener el cronómetro
    public void DetenerCronometro()
    {
        corriendo = false;
    }

    // Método para reiniciar el cronómetro
    public void ReiniciarCronometro()
    {
        tiempo = 0f;
        ActualizarTiempoText();
    }

    // Actualiza el texto en pantalla
    void ActualizarTiempoText()
    {
        // Formateamos el tiempo en minutos y segundos
        int minutos = Mathf.FloorToInt(tiempo / 60F);
        int segundos = Mathf.FloorToInt(tiempo % 60F);
        int milisegundos = Mathf.FloorToInt((tiempo * 100F) % 100F);

        tiempoText.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);
    }
}
