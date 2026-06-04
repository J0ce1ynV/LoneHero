using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    //untuk simpan data game
    private int itemsCollected = 0;
    private int playerHp = 10;
    public int MaxItems = 4;

    public TMP_Text Health;
    public TMP_Text Item;
    public TMP_Text Progress;
    public Button WinButton;
    public Button LossButton;

    void Start()
    {
        Item.text = "Items: " + itemsCollected;
        Health.text = "Health: " + playerHp;

        if(WinButton != null)
            WinButton.gameObject.SetActive(false);
        if (LossButton != null) 
            LossButton.gameObject.SetActive(false);
    }

    public int Items
    {
        get { return itemsCollected; }
        set
        {
            itemsCollected = value;
            Item.text = "Items: " + itemsCollected;

            if(itemsCollected >= MaxItems)
            {
                Progress.text = "You've found all the items!";
                if(WinButton != null)
                    WinButton.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                int remaining = MaxItems - itemsCollected;
                Progress.text = "Item found, only " + remaining + "more to go!";
            }
        }
    }

    public int HP
    {
        get {return playerHp;}
        set
        {
            playerHp = value;
            Health.text = "Health: " + playerHp;
            Debug.LogFormat("Lives: {0}", playerHp);

            if (playerHp <= 0)
            {
                Debug.Log("Loss condition");
                if (LossButton != null)
                {
                    LossButton.gameObject.SetActive(true);
                    Debug.Log("SHOW BUTTON");
                }
                UpdateScene("You want another life with that?"); 
            }
            else
            {
                Progress.text = "Ouch... that's got hurt.";
            }
        }
    }

    public void UpdateScene(string updatedText)
    {
        Progress.text = updatedText;
        Time.timeScale = 0f; // Pause game
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
