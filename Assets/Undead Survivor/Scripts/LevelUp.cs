using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    
    public Sprite sprite;

    public Text text;
    
    private Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        image = transform.GetChild(0).GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
