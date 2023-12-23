using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image Fill;
    public static HealthBarUI Instance;

    private void Awake()
    {
        Instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFill(int currentHP, int maxHP)
    {
        Fill.fillAmount = (float)currentHP/(float)maxHP;    
    }
}
