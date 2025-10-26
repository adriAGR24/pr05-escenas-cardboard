using UnityEngine;

public class CollectibleController : MonoBehaviour
{
  public float speed = 2f;

  private GameObject recoveryObject;
  private RecoveryNotifier notifier;
  private bool collected = false;
  private bool recover = false;

  void Start()
  {
    recoveryObject = GameObject.FindWithTag("Recovery Object");
    notifier = recoveryObject.GetComponent<RecoveryNotifier>();
    notifier.OnPlayerGaze += Recover;
  }

  void Update()
  {
    if (recover)
    {
      Vector3 direction = (recoveryObject.transform.position - transform.position).normalized;
      transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
  }

  public void OnPointerEnter()
  {
    GameObject player = GameObject.Find("Player");

    float distance = Vector3.Distance(player.transform.position, transform.position);

    if (distance < 15 && !recover)
    {
      collected = true;
      gameObject.SetActive(false);
    }
  }

  void Recover()
  {
    if (collected)
    {
      recover = true;
      gameObject.SetActive(true);
    }
  }
}