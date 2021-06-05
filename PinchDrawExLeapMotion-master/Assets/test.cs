using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;


public class test : MonoBehaviour
{
    Controller controller;
    List<Vector3> finger_list = new List<Vector3>();
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;

    public GameObject Text;
    public Text end_text;
    public GameObject under_canvas;
    public UnityEngine.UI.Image GuageImage;
    public UnityEngine.UI.Image bar_Image;

    public UnityEngine.UI.Image circle_one;
    public UnityEngine.UI.Image circle_two;
    public UnityEngine.UI.Image circle_three;

    private float GaugeTimer = 0f;
    private float bar_Timer = 0f;

    private float one_Timer = 0f;
    private float two_Timer = 0f;
    private float three_Timer = 0f;

    private float selectTimer = 0f;

    bool gate = true;
    bool sel_gate = true;
    int bar_gate = 0;




    // Start is called before the first frame update
    void Start()
    {
        

        controller = new Controller();
        finger_list.Add(one.transform.position);
        finger_list.Add(two.transform.position);
        finger_list.Add(three.transform.position);
        finger_list.Add(four.transform.position);
        finger_list.Add(five.transform.position);

        
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = controller.Frame();
        List<Hand> hands = frame.Hands;
        List<Finger> fingers = hands[0].Fingers;


        if (fingers[0].IsExtended == false) one.transform.position = finger_list[0] - new Vector3(-0.8f, 0f, 0.3f);
        else one.transform.position = finger_list[0];

        if (fingers[1].IsExtended == false) two.transform.position = finger_list[1] - new Vector3(0f, 0.8f, 0.3f);
        else two.transform.position = finger_list[1];

        if (fingers[2].IsExtended == false) three.transform.position = finger_list[2] - new Vector3(0f, 0.8f, 0.3f);
        else three.transform.position = finger_list[2];

        if (fingers[3].IsExtended == false) four.transform.position = finger_list[3] - new Vector3(0f, 0.8f, 0.3f);
        else four.transform.position = finger_list[3];

        if (fingers[4].IsExtended == false) five.transform.position = finger_list[4] - new Vector3(0f, 0.8f, 0.3f);
        else five.transform.position = finger_list[4];


        GuageImage.fillAmount = GaugeTimer;
        bar_Image.fillAmount = bar_Timer;


        if (fingers[0].IsExtended == false &&
            fingers[1].IsExtended == false &&
            fingers[2].IsExtended == false &&
            fingers[3].IsExtended == false &&
            fingers[4].IsExtended == false &&
            gate == true)
        {
            GaugeTimer += 4.0f / 10.0f * Time.deltaTime;
            if (GaugeTimer >= 1)
            {
                GaugeTimer = 0;
                Text.SetActive(true);
                under_canvas.SetActive(true);
                gate = false;
            }
        }
        else GaugeTimer = 0f;

       
        if (gate == false)
        {
            if (fingers[0].IsExtended == true &&
                
                bar_gate == 0) bar_gate = 1;

            if (fingers[0].IsExtended == false &&
                
                bar_gate == 1)
            {
                bar_gate = 0;
                if (bar_Timer < 1f) bar_Timer += 0.5f / 10.0f;

            }
        }

        circle_one.fillAmount = one_Timer;
        circle_two.fillAmount = two_Timer;
        circle_three.fillAmount = three_Timer;

        if (fingers[0].IsExtended == false &&
            fingers[1].IsExtended == true &&
            fingers[2].IsExtended == false &&
            fingers[3].IsExtended == false &&
            fingers[4].IsExtended == false &&
            sel_gate == true)
        {
            one_Timer += 4.0f / 10.0f * Time.deltaTime;
            if (one_Timer >= 1)
            {
                one_Timer = 0;
                end_text.text = "첫번째를 선택했어요!";
                sel_gate = false;
            }
        }
        else one_Timer = 0f;

        if (fingers[0].IsExtended == false &&
            fingers[1].IsExtended == true &&
            fingers[2].IsExtended == true &&
            fingers[3].IsExtended == false &&
            fingers[4].IsExtended == false &&
            sel_gate == true)
        {
            two_Timer += 4.0f / 10.0f * Time.deltaTime;
            if (two_Timer >= 1)
            {
                two_Timer = 0;
                end_text.text = "두번째를 선택했어요!";
                sel_gate = false;
            }
        }
        else two_Timer = 0f;

        if (fingers[0].IsExtended == false &&
            fingers[1].IsExtended == true &&
            fingers[2].IsExtended == true &&
            fingers[3].IsExtended == true &&
            fingers[4].IsExtended == false &&
            sel_gate == true)
        {
            three_Timer += 4.0f / 10.0f * Time.deltaTime;
            if (three_Timer >= 1)
            {
                three_Timer = 0;
                end_text.text = "세번째를 선택했어요!";
                sel_gate = false;
            }
        }
        else three_Timer = 0f;


    }
}
