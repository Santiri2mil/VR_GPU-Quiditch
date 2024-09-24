using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSample : MonoBehaviour
{
    //Patron de Observador: Todas las clases interesadas en escuchar lo que dice esta clase
    public delegate void TriggerEvent();
    public TriggerEvent OnTriggerEvent;
    public void LaunchEvent()
    {
        //Transmitit
        if(OnTriggerEvent!=null)
        {
            OnTriggerEvent.Invoke();
        }
        
    }

}
