using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject Not_Activity_Title = Resources.Load("Prefabs/Line Object") as GameObject;
        //GameObject Activity_Title = Resources.Load("") as GameObject;

        if (Not_Activity_Title == null)// || Activity_Title == null
        {
            Debug.Log("Prefabs Contains null");
            return;
        }

        // 프리팹을 게임화면상에서 복사한 후 좌표를 설정하여 배치한다.
        GameObject n_title_Object = Instantiate(Not_Activity_Title);
        n_title_Object.transform.position = new Vector3(-0.5f, 0.11f);
        n_title_Object.transform.localScale -= new Vector3(0.7f,0.7f);

       /* GameObject title_object = Instantiate(Activity_Title);
        title_object.transform.position = new Vector3(1.0f, 0.0f);*/
    }
	
	
}
