using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class Pistol : MonoBehaviour
{
    public GameObject objectToCreate;
    public int bulletCount = 0; 
    // Update is called once per frame
   

     
    public void Shoot (InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            GameObject createdObject = Instantiate(objectToCreate, transform.position, transform.rotation);
            createdObject.GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);
            
        }
        
    }
}
