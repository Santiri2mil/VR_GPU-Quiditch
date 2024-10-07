using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Fly : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed, rotateSpeed, plusSpeed, heightSpeed;
    public bool isFlying,startsFlying, isGrounded, acelerar;
    private float axisValue, axisValue2;
    [SerializeField] private Collider foots;


    // Se activa cuando el objeto entra en contacto con el suelo
    private void OnTriggerEnter(Collider other)
    {   
        isGrounded = true;
    }

    // Se activa cuando el objeto sale del contacto con el suelo
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;   
    }
    // Start is called before the first frame update
    public void AcelerateFly(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && isFlying)
        {
            acelerar = true;
            
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            acelerar = false;
          
        }
       
    }
    public void FlyBroom(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started  )
        {
            isFlying = true;
            startsFlying = false;
            if(isGrounded && startsFlying)//Brincar a la escoba si estamos en el suelo
            {
                rb.AddForce(transform.forward * 5, ForceMode.Impulse);
                rb.AddForce(transform.up * 5, ForceMode.Impulse);
            }
                
        }
        if (context.phase == InputActionPhase.Performed && isGrounded)
        {
            isFlying = true;
            
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            isFlying = false;
            
        }

    }
    // Método que será llamado por el Input System
    public void HeightControl(InputAction.CallbackContext context)
    {
        // Leer el valor del 1D Axis (float)
        axisValue = context.ReadValue<float>();

        // Aplicar el movimiento basado en el valor del eje
        Debug.Log("Axis Value: " + axisValue);
    }

    public void Rotation(InputAction.CallbackContext context)
    {
        // Leer el valor del 1D Axis (float)
        axisValue2 = context.ReadValue<float>();

        // Aplicar el movimiento basado en el valor del eje
        Debug.Log("Axis Value: " + axisValue);
    }
    private void Start()
    {
        isFlying = false;
        startsFlying = false;
        acelerar = false;
    }
    private void Update()
    {
        FlyLogic();
        //Detección de movimiento arriba, abajo y girar
        if(isFlying)
        {
            
            transform.Translate(Vector3.up * axisValue * heightSpeed * Time.deltaTime);//cambiar altura
        }
        transform.Rotate(Vector3.up * axisValue2 * rotateSpeed * Time.deltaTime);//Rotar
        
    }
    public void FlyLogic()
    {
        float finalSpeed;
        if (isFlying)
        {
            if (acelerar)
            {
                finalSpeed = speed + plusSpeed;
            }
            else
            {
                finalSpeed = speed;
            }
            //rb.MovePosition(transform.position + transform.forward * finalSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * finalSpeed * Time.deltaTime);
            
        }
        else
        {
            rb.AddForce(transform.up * -6.81f, ForceMode.Acceleration);//Gravedad
        }
        if (isGrounded)
        {
            startsFlying = true;
        }
      

    }

}
