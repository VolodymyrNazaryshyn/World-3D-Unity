using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _moveVector;
    private float _moveSpeed = 6000f;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float factor = _moveSpeed * Time.deltaTime;
        float ix = Input.GetAxis("Horizontal") * factor;
        float iy = Input.GetAxis("Vertical") * factor;
        _moveVector = new Vector3(ix, 0, iy);
        _characterController.SimpleMove(_moveVector);
    }
}
