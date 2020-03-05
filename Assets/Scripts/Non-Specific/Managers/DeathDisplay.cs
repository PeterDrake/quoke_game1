using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manager class for killing the player and displaying death screen 
/// </summary>
public class DeathDisplay : UIElement
{ 
    public GameObject toggle;
    public Text deathText;
    private bool dead;
   
    public void Start()
    {
       pauseOnOpen = true;
       forceOpen = true;
       locked = true;
       toggle.SetActive(false);
    }
    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Activate(string text)
    { 
        deathText.text = text;
        UIManager.Instance.SetAsActive(this);
    }
    public override void Open()
    {
        toggle.SetActive(true);
    }

    public override void Close()
    {
        toggle.SetActive(false);
    }
}
