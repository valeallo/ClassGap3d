using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text score_text;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerData data = SaveSystem.Load();
        if (data != null)
        {
            score_text.text = data.score.ToString();
        }
        else
        {
            score_text.text = "0000";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
