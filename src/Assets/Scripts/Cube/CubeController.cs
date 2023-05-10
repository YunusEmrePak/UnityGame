using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public static CubeController instance;

    [SerializeField] private PlayerStackController playerStackController;

    private Vector3 direction = Vector3.back;
    public Collider triggerCollider;

    public AudioSource DecreaseBlock;
    public AudioSource CollectCube;

    public bool isStack = false;
    
    void Start()
    {
        playerStackController = GameObject.FindObjectOfType<PlayerStackController>();
        triggerCollider = GetComponent<Collider>();
    }

    void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isStack && (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Collectible")))
        {
            isStack = true;
            playerStackController.IncreaseBlockStack(gameObject);
            triggerCollider.isTrigger = false;
            SetDirection();
            CollectCube.Play();
        }

    }

    private void SetDirection()
    {
        direction = Vector3.forward;
    }

}
