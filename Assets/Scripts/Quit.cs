using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{

    public Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.Quit();
    }

    void Destroy()
    {
        button.onClick.RemoveListener(TaskOnClick);
    }
}
