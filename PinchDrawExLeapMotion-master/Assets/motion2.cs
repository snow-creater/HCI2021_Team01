using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class motion2 : MonoBehaviour
{
    Controller controller;
    List<float> mo = new List<float>();
    public GameObject cube;
    //bool DTtime = false;
    float HandPalmPitch;
    int num = 0;

    int gate = 1;

    void Start()
    {
        mo.Clear();
        controller = new Controller();
    }

    void Update()
    {
        if (controller.IsConnected)
        {
            Frame frame = controller.Frame(); //The latest frame
            Frame previous = controller.Frame(1); //The previous frame
            for (int h = 0; h < frame.Hands.Count; h++)
            {
                Hand leapHand = frame.Hands[0];
                Hand previous_leapHand = previous.Hands[0];
                Vector handOrigin = leapHand.PalmPosition;
                Vector previoushandOrigin = previous_leapHand.PalmPosition;
                HandPalmPitch = leapHand.PalmNormal.Pitch;

                Debug.Log(leapHand.PalmVelocity.x);
                if (System.Math.Abs(handOrigin.x - previoushandOrigin.x) > 5 && System.Math.Abs(leapHand.PalmVelocity.x) > 30)
                {
                    //Debug.Log("휘두름");
                    mo.Add(1);
                    int lastcount = mo.Count;
                    if (mo[lastcount - 2] != mo[lastcount - 1])
                    {
                        if (cube.activeSelf == true)
                        {
                            //Debug.Log("사라지게");
                            cube.SetActive(false);
                        }
                        else
                        {
                            //Debug.Log("생기게");
                            cube.SetActive(true);
                        }
                    }
                }
                else
                {
                    mo.Add(0);
                }


                List<Hand> hands = frame.Hands;
                float Grabstrength = hands[0].GrabStrength;
                Debug.Log(Grabstrength);

                if (Grabstrength >= 1.0f && gate == 1)
                {
                    Color[] co = new Color[3];
                    co[0] = Color.red;
                    co[1] = Color.blue;
                    co[2] = Color.green;
                    cube.GetComponent<MeshRenderer>().material.color = co[num % 3];
                    num++;
                    gate = 0;
                }
                else if (Grabstrength <= 0.6f && gate == 0)
                {
                    gate = 1;
                }

                Vector velocity = hands[0].PalmVelocity;
                //Debug.Log(velocity);

            }
        }

        

    }


}
