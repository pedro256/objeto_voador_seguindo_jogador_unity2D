using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatRadarScript : MonoBehaviour
{
    private MorcegoIA morcegoIA;

    void Start()
    {
        morcegoIA = (MorcegoIA)GetComponentInParent(typeof(MorcegoIA));
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            morcegoIA.lostPlayer = false;
            morcegoIA.canFly = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.tag == "Player"){
            morcegoIA.BacktoHome();
            morcegoIA.lostPlayer = true;
            morcegoIA.canFly = true;
        }

    }
}
