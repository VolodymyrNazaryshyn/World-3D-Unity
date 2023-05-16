using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _animator;
    private Vector3 _moveVector;
    private float _moveSpeed = 2000f;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float factor = _moveSpeed * Time.deltaTime;
        float ix = Input.GetAxis("Horizontal");
        float iy = Input.GetAxis("Vertical");

        // _moveVector = new Vector3(ix, 0, iy); // в мировом пространстве
        _moveVector = 
            this.transform.forward * iy  // составляющая "вперед" - вертикальное управление
            + this.transform.right * ix; // вправо - горизонтальное управление
        
        if (_moveVector.magnitude > 1)
        {
            _moveVector = _moveVector.normalized;
        }
        _moveVector *= factor;
        if (_moveVector.magnitude > _characterController.minMoveDistance)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                _animator.SetInteger("MoveState", 2);
                _moveVector *= factor * 2;
            }
            else
            {
                _animator.SetInteger("MoveState", 1);
            }
        }
        else
        {
            _animator.SetInteger("MoveState", 0);
        }
        _characterController.SimpleMove(_moveVector);
    }
}