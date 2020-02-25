using UnityEngine;

public abstract class Pauseable : MonoBehaviour
{
    public virtual void Start()
    {
        PauseManager.Instance.Register(this);
    }

    public abstract void Pause();

    public abstract void UnPause();
}
