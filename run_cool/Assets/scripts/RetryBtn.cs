using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//按钮增加侦听事件
		Button button=gameObject.GetComponent<Button>() as Button;
		button.onClick.AddListener (OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//重新载入场景
	void OnClick(){
		SceneManager.LoadScene ("Scene_1"); 
	}
}
