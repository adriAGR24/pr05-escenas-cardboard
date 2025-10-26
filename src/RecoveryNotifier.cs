using UnityEngine;

public class RecoveryNotifier : MonoBehaviour
{
  public delegate void Recover();
  public event Recover OnPlayerGaze;

  public void OnPointerEnter()
  {
    OnPlayerGaze();
  }
}
