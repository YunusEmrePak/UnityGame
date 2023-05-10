using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerMovementController : MonoBehaviour
{
    public static PlayerMovementController instance;

    [SerializeField] private PlayerInputController playerInputController;
    [SerializeField] private float forwardMovementSpeed;
    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] public float horizontalLimitValue;
    [SerializeField] public GameObject FailScreen;
    [SerializeField] public GameObject StartScreen;
    [SerializeField] public GameObject PauseScreen;
    [SerializeField] public GameObject ShopScreen;
    [SerializeField] public GameObject SettingsScreen;
    [SerializeField] public GameObject AboutUsScreen;
    [SerializeField] public GameObject coinEffect;
    [SerializeField] public GameObject ShopBackground;
    [SerializeField] public GameObject FinishScreen;
    [SerializeField] public GameObject Score;
    [SerializeField] public GameObject PauseButton;
    [SerializeField] public CinemachineVirtualCamera forwardVirtualCamera;
    [SerializeField] private float cameraRotationSpeed = 3f;

    private Quaternion targetCameraRotation;

    public AudioSource CollectDiamond;
    public AudioSource GameOver;

    public Rigidbody _rb;

    public Animator playerAnimator;

    public GameObject player;

    private float newPositionX;
    private float newPositionZ;
    public string currentDirection = "z";
    private string direction;
    
    public bool isStarted;
    public bool isFinished;

    void Start() {
        Physics.gravity = new Vector3(0, -100, 0);
        _rb = GetComponent<Rigidbody>();
        playerAnimator = player.GetComponent<Animator>();
        horizontalLimitValue = transform.position.x;
        targetCameraRotation = forwardVirtualCamera.transform.rotation;
    }

    void Awake() {
        instance = this;
        FailScreen.SetActive(false);
        PauseScreen.SetActive(false);
        StartScreen.SetActive(true);
        SettingsScreen.SetActive(false);
        AboutUsScreen.SetActive(false);
        isStarted = false;
        isFinished = false;
    }
    
    private void Update()
    {
        RotateCameraSmoothly();
    }

    void FixedUpdate()
    {
        SetPlayerForwardMovement();
        SetPlayerHorizontalMovement();
    }

    private void SetPlayerForwardMovement()
    {   
        if (!isFinished) {
            if (isStarted) {
                if(currentDirection == "x"  && direction == "right") {
                    Vector3 forwardMovement = new Vector3(forwardMovementSpeed, _rb.velocity.y, 0);
                    _rb.velocity = forwardMovement;
                }
                else if(currentDirection == "x"  && direction == "left") {
                    Vector3 forwardMovement = new Vector3(-forwardMovementSpeed, _rb.velocity.y, 0);
                    _rb.velocity = forwardMovement;
                }
                else if(currentDirection == "z") {
                    Vector3 forwardMovement = new Vector3(0, _rb.velocity.y, forwardMovementSpeed);
                    _rb.velocity = forwardMovement;
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Diamond") {
            ScoreManager.instance.IncreaseScore();
            other.gameObject.SetActive(false);
            CollectDiamond.Play();
        }
        
    }

    private void SetPlayerHorizontalMovement()
    {
        if(currentDirection == "z") {
            newPositionX = transform.position.x + playerInputController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
            newPositionX = Mathf.Clamp(newPositionX, horizontalLimitValue - 7f, horizontalLimitValue + 7f);
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }
        else if(currentDirection == "x" && direction == "right") {
            newPositionZ = transform.position.z + (-playerInputController.HorizontalValue) * horizontalMovementSpeed * Time.fixedDeltaTime;
            newPositionZ = Mathf.Clamp(newPositionZ, horizontalLimitValue - 7f, horizontalLimitValue + 7f);
            transform.position = new Vector3(transform.position.x, transform.position.y, newPositionZ);
        }
        else if(currentDirection == "x" && direction == "left") {
            newPositionZ = transform.position.z + playerInputController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
            newPositionZ = Mathf.Clamp(newPositionZ, horizontalLimitValue - 7f, horizontalLimitValue + 7f);
            transform.position = new Vector3(transform.position.x, transform.position.y, newPositionZ);
        }
    }

    public void FinishTheGame() {
        PlayerMovementController.instance.FinishScreen.SetActive(true);
        PlayerLevelController.instance.LoadNextLevel();
        ScoreManager.instance.AddLastScore();
        isFinished = true;
    }

    public void ResumeTheGame() {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
    }

    public void PauseTheGame() {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
    }
    
    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void RotateCamera(string dir)
    {
        direction = dir;
        if (dir == "right" && currentDirection == "z")
        {
            targetCameraRotation = Quaternion.Euler(25, -14, 0);
            horizontalLimitValue = transform.position.x;
        }
        else if (dir == "right" && currentDirection == "x")
        {
            targetCameraRotation = Quaternion.Euler(25, 75, 0);
            horizontalLimitValue = transform.position.z;
        }
        else if (dir == "left" && currentDirection == "x")
        {
            targetCameraRotation = Quaternion.Euler(25, -100, 0);
            horizontalLimitValue = transform.position.z;
        }
        else if (dir == "left" && currentDirection == "z")
        {
            targetCameraRotation = Quaternion.Euler(25, -10, 0);
            horizontalLimitValue = transform.position.x;
        }
    }

    private void RotateCameraSmoothly()
    {
        if (targetCameraRotation != default(Quaternion) && forwardVirtualCamera.transform.rotation != targetCameraRotation)
        {
            forwardVirtualCamera.transform.rotation = Quaternion.Lerp(forwardVirtualCamera.transform.rotation, targetCameraRotation, cameraRotationSpeed * Time.deltaTime * 1.2f);
        }
    }

}
