using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class motion : MonoBehaviour
{
    Controller controller;
    float HandPalmPitch;
    float HandPalmRoll;
    float HandPalmYam;

    
   


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        controller = new Controller();
        Frame frame = controller.Frame();
        List<Hand> hands = frame.Hands;
        //if (frame.Hands.Count > 0)
        //{
        //    Hand fristHand = hands[0];
        //}
        /////////////////////
        //List<Finger> fingers = hands[0].Fingers;
        //Vector direction = fingers[0].Direction;
        //Debug.Log("direction : " + direction);
        /////////////////////
        float Grabstrength = hands[0].GrabStrength;
        Debug.Log("Grabstrength : " + Grabstrength);
        //////////////////////




        HandPalmPitch = hands[0].PalmNormal.Pitch;
        HandPalmRoll = hands[0].PalmNormal.Roll;
        HandPalmYam = hands[0].PalmNormal.Yaw;
        


        //Debug.Log("Pitch : " + HandPalmPitch);
        //Debug.Log("Roll : " + HandPalmRoll);
        //Debug.Log("Yam : " + HandPalmYam);
        

        if (HandPalmPitch > -1.5f)
        {
            //Debug.Log("앞");
            this.transform.Translate(0, 0, 1 * Time.deltaTime);
        }
        else if (HandPalmPitch < -1.5f)
        {
            //Debug.Log("뒤");
            this.transform.Translate(0, 0, -1 * Time.deltaTime);
        }
    }
}
