using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRings : MonoBehaviour
{

    
    public HUDManager pointScore;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
    
        
            pointScore.UpdateBulletCount();
        
    }
}
