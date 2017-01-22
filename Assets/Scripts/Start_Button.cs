using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Start_Button : MonoBehaviour {
    public Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
		SceneManager.LoadScene("WaveGame");
    }

    void Destroy()
    {
        button.onClick.RemoveListener(TaskOnClick);
    }
}
