using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleUI : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject GamePanel;
    public Text c1;
    public Text c2;
    public Text c3;
    //public Text c4;

    #region Singleton

    private static PuzzleUI _instance = null;

    public static PuzzleUI Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PuzzleUI>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instance;
        }
    }
    #endregion

    private void Update()
    {
        c1.text = Interaction.Instance.Counter1.ToString();
        c2.text = Interaction.Instance.Counter2.ToString();
        c3.text = Interaction.Instance.Counter3.ToString();
        //c4.text = Interaction.Instance.Counter4.ToString();
    }

    public void Puzzle()
    {
        GamePanel.SetActive(false);
        enableFPS(false);
        puzzle.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitPuzzle()
    {
        GamePanel.SetActive(true);
        puzzle.SetActive(false);
        enableFPS(true);
        Time.timeScale = 1f;
    }

    public void C1Up()
    {
        Interaction.Instance.Counter1Up();
    }

    public void C2Up()
    {
        Interaction.Instance.Counter2Up();
    }

    public void C3Up()
    {
        Interaction.Instance.Counter3Up();
    }
    
    public void C1Down()
    {
        Interaction.Instance.Counter1Down();
    }
    
    public void C2Down()
    {
        Interaction.Instance.Counter2Down();
    }
    
    public void C3Down()
    {
        Interaction.Instance.Counter3Down();
    }

    public void Submit ()
    {
        Interaction.Instance.CheckPuzzle();
    }

    void enableFPS(bool enable)
    {
        GameObject fpsObj = GameObject.Find("FPSController");
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsScript = fpsObj.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

        if (enable)
        {
            //Enable FPS script
            fpsScript.enabled = true;
        }
        else
        {
            //Disable FPS script
            fpsScript.enabled = false;
            //Unlock Mouse and make it visible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
