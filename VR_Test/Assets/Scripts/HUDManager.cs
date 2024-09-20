using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI textInScene;
    public int bulletCount = 0;
    
    public void UpdateText ()
    {
        bulletCount++;
        textInScene.text = bulletCount.ToString();
    }

    
    // Start is called before the first frame update
    public void UpdateBulletCount()
    {
        bulletCount++;
        textInScene.text = bulletCount.ToString();
    }
     

}
