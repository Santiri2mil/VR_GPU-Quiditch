using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRings : MonoBehaviour
{
    private int scorePoints;
    public bool extraRing;
    
    public HUDManager pointScore;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(extraRing)
        {
            scorePoints = 20;
        }
        else
        {
            scorePoints = 10;
        }
        pointScore.UpdatePointCount(scorePoints);
        Debug.Log("Point");
    }

}
