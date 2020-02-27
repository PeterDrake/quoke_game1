using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manager class for killing the player and displaying death screen 
/// </summary>
public class DeathManager : UIElement
{ 
    public GameObject toggle;
    public Text deathText;

    public static DeathManager Instance;
    private bool dead;
   
   public void Start()
   {
       pauseOnOpen = true;
       forceOpen = true;
       locked = true;
       if (Instance == null) Instance = this;
       else Destroy(this);
   }

   public void PlayerDeath(string textOnDeath)
    {
        if (dead) return;
        Logger.Instance.Log("Player killed by: "+textOnDeath);
        dead = true;
        deathText.text = textOnDeath;
        UIManager.Instance.SetAsActive(this);
    }

    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
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
