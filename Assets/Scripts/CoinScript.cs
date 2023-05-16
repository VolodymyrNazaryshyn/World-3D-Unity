using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collector"))
        {
            // Debug.Log("Collected");
            _animator.SetBool("IsCollected", true);
        }
    }

    public void Disappeared()
    {
        // Debug.Log("Disappeared");
        this.transform.position += Vector3.forward * 10;
        _animator.SetBool("IsCollected", false);
    }
}
