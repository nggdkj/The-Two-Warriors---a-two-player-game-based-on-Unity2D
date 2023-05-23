using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject GameOverPanel;
    public GameObject GoOn;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void ShowGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }
    public void ShowGoOn()
    {
        GoOn.SetActive(true);
    }
}
