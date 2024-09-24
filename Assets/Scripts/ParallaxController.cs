using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float sizeOfSprite, backgroundMoveSpeed;
    private float spriteStartPosition;

    void Start()
    {
        cam = Camera.main;
        sizeOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
        spriteStartPosition = transform.position.x;
    }

    void Update()
    {
        var cameraPos = -cam.transform.position.x;
        var temp = cameraPos * (1-backgroundMoveSpeed);
        var distance = cameraPos * backgroundMoveSpeed;

        var newPosition = new Vector3(spriteStartPosition + distance, transform.position.y, transform.position.z);

        transform.position = newPosition;

        if (temp > spriteStartPosition + (sizeOfSprite / 2))
        {
            spriteStartPosition += sizeOfSprite;
        }  
        else if (temp < spriteStartPosition + (sizeOfSprite / 2))
        {
            spriteStartPosition -= sizeOfSprite;
        }
    }
}