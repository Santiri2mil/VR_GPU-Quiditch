using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI textInScene, timer;
    public int pointCount = 0;
    public Cronometro timing;
  
    public void UpdateText ()
    {
        pointCount++;
        textInScene.text = pointCount.ToString();
    }

    
    // Start is called before the first frame update
    public void UpdateBulletCount(int points)
    {
        pointCount+=points;
        textInScene.text = pointCount.ToString();
    }
     
   

}
