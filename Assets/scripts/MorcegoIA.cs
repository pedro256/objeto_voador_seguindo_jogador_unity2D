using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoIA : MonoBehaviour
{

    public Transform batHome;
    public Transform bat;
    public Transform player;
    private Vector3 positionPlayerLost;
    private Vector3 positionPlayerFind;

    public float speed;
    private float startTime;
    private float journeyLenght;
    public bool lostPlayer = true;
    public bool canFly = false;


    void Start()
    {
        bat = GetComponent<Transform>();
        batHome = bat.transform.parent;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        positionPlayerLost = batHome.position;
        BacktoHome();

    }

    void Update()
    {
        if(canFly){
            if(lostPlayer){

                float dist = (Time.time - startTime)*speed;
                float journey = dist/journeyLenght;

                if(bat.position == batHome.position){
                    canFly = false;
                }
                bat.position = Vector3.Lerp(positionPlayerLost,batHome.position,journey);
            }else{
                bat.position = Vector3.Lerp(bat.position, player.position,0.025f);

            }
        }
    }
    public void BacktoHome(){
        startTime = Time.time;
        positionPlayerLost = bat.position;
        journeyLenght = Vector3.Distance(positionPlayerLost,batHome.position);

    }
}
