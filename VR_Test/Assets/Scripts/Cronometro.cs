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
    private bool corriendo = false; // Indica si el cron�metro est� corriendo

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
        // Si el cron�metro est� corriendo, acumulamos tiempo
        if (corriendo)
        {
            tiempo += Time.deltaTime;
            ActualizarTiempoText();
        }
    }

    // M�todo para iniciar el cron�metro
    public void IniciarCronometro()
    {
        corriendo = true;
    }

    // M�todo para detener el cron�metro
    public void DetenerCronometro()
    {
        corriendo = false;
    }

    // M�todo para reiniciar el cron�metro
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
