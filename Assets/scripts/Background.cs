using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Material mat;
    private GameObject player;
    public float speed = 1;
    private float position =0;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        var vel = player.GetComponent<Rigidbody2D>().velocity.x;
        if(vel !=0){
            var side = player.transform.localScale.x;
            position += speed*side;
            mat.mainTextureOffset = new Vector2(position,0);

        }
    }
}
