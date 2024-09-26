using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Fly : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed, rotateSpeed, plusSpeed, heightSpeed;
    [SerializeField] private bool isFlying;
    private float axisValue, axisValue2;
    // Start is called before the first frame update
    public void FlyBroom(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            isFlying = true;
        }
        else
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
    private void Update()
    {
        float finalSpeed;
        if(isFlying)
        {

            finalSpeed = speed + plusSpeed;
        }
        else
        {
            finalSpeed = speed;
        }
        //rb.MovePosition(transform.position + transform.forward * finalSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * finalSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * axisValue * heightSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * axisValue2 * rotateSpeed * Time.deltaTime);
        
    }
}
