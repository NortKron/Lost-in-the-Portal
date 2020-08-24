using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Pause menu
    public GameObject panelMenuPause;

    // Inventory window
    public GameObject panelInventory;

    public GameObject panelLabelDeath;

    public GameObject panelTalk;
    public GameObject panelDialogWindow;
    public GameObject panelPlayerGUI;

    private bool isPause = false;
    private bool isOpenInventory = false;
    //bool isDied = false;

    //GameObject player;
    public Player player;

    private List<string> dialog;

    private ControllerState controllerState = ControllerState.PlayerController;
    enum ControllerState
    {
        PlayerController,
        InventoryController,
        DialogController,
        MenuController
    }

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        switch (controllerState)
        {
            case ControllerState.PlayerController:
                // PlayerController
                PlayerController();
                break;

            case ControllerState.InventoryController:
                InventoryController();
                break;

            case ControllerState.DialogController:
                DialogController();
                break;

            case ControllerState.MenuController:
                MenuController();
                break;

            default:
                break;
        }
    }

    private void PlayerController()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            controllerState = ControllerState.MenuController;
            OnPause();
        }

        if (player.isDied) return;

        if (Input.GetKeyDown(KeyCode.I))
        {
            controllerState = ControllerState.InventoryController;
            OnInventory();
        }        

        if (Input.GetButtonDown("Jump"))
        {
            player.SendMessage("Jump");

        }
        else if (Input.GetButton("Horizontal"))
        {
            player.SendMessage("Walk");
        }
        else
        {
            player.SendMessage("Idle");
        }

        if (Input.GetKeyDown(KeyCode.F) && panelTalk.activeSelf)
        {
            Debug.Log("GetKeyDown F");

            controllerState = ControllerState.DialogController;
            ShowDialogWindow();
            FindObjectOfType<DialogManager>().StartDialog(dialog);
        }
    }

    private void InventoryController()
    {
        if (Input.GetKeyDown(KeyCode.I) 
            || Input.GetButtonDown("Cancel"))
        {
            controllerState = ControllerState.PlayerController;
            OnInventory();
        }
    }

    private void DialogController()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            controllerState = ControllerState.PlayerController;
            ShowDialogWindow();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<DialogManager>().DisplayNextSentences();
        }
    }

    private void MenuController()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            controllerState = ControllerState.PlayerController;
            OnPause();
        }
    }

    public void OnPause()
    {
        Time.timeScale = isPause ? 1 : 0;
        isPause = !isPause;

        Cursor.visible = isPause;
        panelMenuPause.SetActive(isPause);
        panelPlayerGUI.SetActive(!isPause);
    }

    public void OnInventory()
    {
        //Debug.Log("Open Inventory");

        Time.timeScale = isOpenInventory ? 1 : 0;
        isOpenInventory = !isOpenInventory;

        Cursor.visible = isOpenInventory;
        panelInventory.SetActive(isOpenInventory);
    }

    public void ShowPanelTalk()
    {
        panelTalk.SetActive(!panelTalk.activeSelf);
    }

    public void ShowDialogWindow()
    {
        Debug.Log("ShowDialogWindow");
        panelDialogWindow.SetActive(!panelDialogWindow.activeSelf);
    }

    public void GetDialog(List<string> sentences)
    {
        dialog = sentences;
        //Debug.Log("Get Dialog, lines = " + dialog.Count);
    }

    public void EndDialog()
    {
        controllerState = ControllerState.PlayerController;
        ShowDialogWindow();
        //GameObject.FindGameObjectsWithTag("GameController")[0].SendMessage("ShowDialogWindow");
    }

}
