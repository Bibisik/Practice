using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundHelper : MonoBehaviour
{

    [SerializeField]private float speed = 0;
    private float pos = 0;
    private RawImage image;
    
	void Start ()
    {
        image = GetComponent<RawImage>();
	}
	
	
    void Update ()
    {
        pos += speed;
        if (pos > 1.0F)
            pos -= 1.0F;

        image.uvRect = new Rect(pos, 0, 1, 1);
    }   


}
