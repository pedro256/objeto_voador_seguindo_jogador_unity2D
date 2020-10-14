using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Transform camera;

    void Update()
    {
        //camera segue o player no eixo x
        camera.position = Vector3.Lerp(camera.position, new Vector3(player.position.x,player.position.y,camera.position.z),1f);
    }
}
