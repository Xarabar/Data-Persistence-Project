using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartUIHandler : MonoBehaviour
{
    public TextMeshProUGUI nameInput;

    public void StartGame()
    {
        SetName();
        SceneManager.LoadScene(1);
    }

    private void SetName()
    {
        if(DataPersistenceManager.instance != null)
        {
            DataPersistenceManager.instance.SetPlayerName(nameInput.text);
        }
    }
}
