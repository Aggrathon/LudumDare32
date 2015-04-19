using UnityEngine;

public class GamestateManager : MonoBehaviour {

    public GameObject DeadScreen;
    public GameObject menu;

    void OnEnable()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            if (DeadScreen.activeSelf)
                Restart();
            else
                Pause();
        }
    }


    public void Die()
    {
        DeadScreen.SetActive(true);
    }

    public void EnterBattleShip()
    {
        Pause();
    }

    public void EnterFighterShip()
    {
        Pause();
    }

    public void Pause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            menu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Time.timeScale = 0f;
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Restart()
    {
        Application.LoadLevel(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
