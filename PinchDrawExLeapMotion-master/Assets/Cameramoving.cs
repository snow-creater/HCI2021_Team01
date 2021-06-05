using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramoving : MonoBehaviour
{

    float speed = 10;
    public bool isMouse = false;

    void Update()
    {
        Camera_Getkey(); // 키보드로 control
        Camera_Mouse(); // 마우스로 control
        Camera_Scrollwheel(); // 스크롤 control
    }

    void Camera_Getkey()
    {
        if (Input.GetKey(KeyCode.W)) // W를 누르고 있을 때
        {   // 앞뒤로 이동한다. (Forward, Down)
            transform.Translate(Vector3.up * speed * Time.deltaTime); // 로컬좌표 적용
            // transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World); // 월드좌표
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) // D를 누르고 있을 때
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    void Camera_Mouse()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 숫자 1을 누르면 on/off
        {
            isMouse = !isMouse; // false ==> true, true ==> false
        }

        if (!isMouse) return;
        if (Input.mousePosition.y >= Screen.height - 10) // 마우스가 스크린 위 가장자리에 닿으면
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.mousePosition.y < 10) // 마우스가 스크린 위 가장자리에 닿으면
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.mousePosition.x < 10)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.mousePosition.x >= Screen.width - 10)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    void Camera_Scrollwheel()
    {
        // 코드가 공식처럼 사용되고 있다.
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * Time.deltaTime;
        transform.position = pos;
    }
}
