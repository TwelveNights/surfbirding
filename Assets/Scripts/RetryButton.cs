using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour {

	private Button retryButton;

	void Start() {
		retryButton = GetComponent<Button>();
		retryButton.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene("Eddie Zhou");
	}
}
