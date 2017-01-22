using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Instruct_Button : MonoBehaviour
{

    public Button instruction_button;

    void Start()
    {
        instruction_button = GetComponent<Button>();
        instruction_button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Instructions");
    }
}
