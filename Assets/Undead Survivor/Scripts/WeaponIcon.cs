using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponIcon : MonoBehaviour
{
    public Sprite[] weaponIcons;
    
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = weaponIcons[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeWeaponIcon(int index)
    {
        if (index<=5)
        {
            image.sprite = weaponIcons[index];
        }
    }
}
