using UnityEngine;

public class TeleportTarget : MonoBehaviour
{
  [Tooltip("Time the player must look at the object before teleporting (in seconds)")]
  public float gazeTime = 1f;

  private float gazeTimer = 0f;
  private bool isGazedAt = false;
  private Transform playerTransform;

  void Start()
  {
    playerTransform = GameObject.Find("Player").transform;
  }

  public void OnPointerEnter()
  {
      isGazedAt = true;
      gazeTimer = 0f;
  }

  public void OnPointerExit()
  {
    isGazedAt = false;
    gazeTimer = 0f;
  }

  void Update()
  {
    if (!isGazedAt)
      return;

    gazeTimer += Time.deltaTime;
      
    if (gazeTimer >= gazeTime)
    {
      TeleportPlayer();
      isGazedAt = false;
    }
  }

  private void TeleportPlayer()
  {
    Vector3 newPosition = transform.position;
    playerTransform.position = new Vector3(newPosition.x, newPosition.y + 2f, newPosition.z);
  }
}