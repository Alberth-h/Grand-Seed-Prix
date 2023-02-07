using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _cam;
    [SerializeField] private Animator _animator;
    
    [SerializeField] private float _groundCheckRadius = 0.1f;
    [SerializeField] public float speed = 12;
    [SerializeField] private float _turnSpeed = 1500f;
    [SerializeField] private float _jumpForce = 1000f;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private GravityBody _gravityBody;
    [SerializeField]private GameObject joystick;
    private GameObject boton;
    private bool ispressed = false;
    private Button btn;
    private AudioSource audioData;
    
    [SerializeField]private GameObject wasted;
    
    [SerializeField]private GameObject win;
    [SerializeField]private GameObject btnExitGame;
    
    [SerializeField]private GameObject panel;
    [SerializeField]private GameObject _cameraHolder;
    [SerializeField] private Vector3 _camoffset;
    
    void Start()
    {
        if (!IsOwner) return;
        _rigidbody = transform.GetComponent<Rigidbody>();
        _gravityBody = transform.GetComponent<GravityBody>();
       joystick = transform.Find("CameraHolder/Main Camera/Canvas/Fixed Joystick").gameObject;
       boton = transform.Find("CameraHolder/Main Camera/Canvas/Jump").gameObject;

       btn = boton.GetComponent<Button>();
        btn.onClick.AddListener(Jump);
    }

    void Update()
    {
        //_direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        _direction = new Vector3(joystick.GetComponent<Joystick>().Horizontal, 0f, joystick.GetComponent<Joystick>().Vertical).normalized;
        bool isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask);
        _animator.SetBool("isJumping", !isGrounded);
        if (ispressed && isGrounded)
        {
            _rigidbody.AddForce(-_gravityBody.GravityDirection * _jumpForce, ForceMode.Impulse);
            ispressed = false;
        }
        
    }
    
    void FixedUpdate()
    {
        if (!IsOwner) return;
        bool isRunning = _direction.magnitude > 0.1f;
        
        if (isRunning)
        {
            Vector3 direction = transform.forward * _direction.z;
            _rigidbody.MovePosition(_rigidbody.position + direction * (speed * Time.fixedDeltaTime));
            
            Quaternion rightDirection = Quaternion.Euler(0f, _direction.x * (_turnSpeed * Time.fixedDeltaTime), 0f);
            Quaternion newRotation = Quaternion.Slerp(_rigidbody.rotation, _rigidbody.rotation * rightDirection, Time.fixedDeltaTime * 3f);;
            _rigidbody.MoveRotation(newRotation);
        }

        _animator.SetBool("isRunning", isRunning);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!IsOwner) return;
        if (collision.gameObject.tag == "Limit")
        {
            transform.position = new Vector3(0, 0, 0);
        }
        if (collision.gameObject.tag == "Meta")
        {
            audioData = GetComponent<AudioSource>();
            audioData.Play();
            win.SetActive(true);
            btnExitGame.SetActive(true);
            boton.SetActive(false);
            panel.SetActive(true);
            joystick.SetActive(false);
            transform.position = new Vector3(0, 0, 0);
            speed = 0;
            _jumpForce = 0;
            _cameraHolder.transform.position = new Vector3(0, -0.5f, 20);
            _cameraHolder.transform.rotation = Quaternion.Euler(new Vector3(90,180,90));
            
            this._animator.SetBool("isWin", true);
            
            Debug.Log("ganaste");
        }
        if (collision.gameObject.tag == "Bala")
        {
            //if (!IsOwner) return;
            //Destroy(gameObject);
            this._animator.SetBool("isDead", true);
            speed = 0;
            _jumpForce = 0;
            wasted.SetActive(true);
            panel.SetActive(true);
            boton.SetActive(false);
            joystick.SetActive(false);
        }
    }

    public void Jump(){
        ispressed = true;
    }
}
