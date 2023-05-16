using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Animator _animator;
    private int _minDistance;
    private int _maxDistance;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _minDistance = 10;
        _maxDistance = 20;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collector"))
        {
            _animator.SetBool("IsCollected", true);
        }
    }

    public void Disappeared()
    {
        System.Random random = new();
        int randomDistance = random.Next(_minDistance, _maxDistance + 1);

        switch(random.Next(1, 5))
        {
            case 1: this.transform.position += Vector3.forward * randomDistance; break;
            case 2: this.transform.position += Vector3.back * randomDistance; break;
            case 3: this.transform.position += Vector3.left * randomDistance; break;
            case 4: this.transform.position += Vector3.right * randomDistance; break;
        }

        DisplayScript.coinCount += 1;

        _animator.SetBool("IsCollected", false);
    }
}
