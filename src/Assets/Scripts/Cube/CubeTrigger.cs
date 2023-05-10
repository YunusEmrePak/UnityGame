using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeTrigger : MonoBehaviour
{
    public Collider triggerCollider;

    void Start() {
        triggerCollider = GetComponent<Collider>();
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Collectible"))
        {
            triggerCollider.isTrigger = false;
            PlayerStackController.instance.DecreaseBlock(other.gameObject);
            CubeController.instance.DecreaseBlock.Play();
        }
        else if (other.gameObject.CompareTag("Character"))
        {
            triggerCollider.isTrigger = false;
            PlayerMovementController.instance.GameOver.Play();
            PlayerMovementController.instance.FailScreen.SetActive(true);
            PlayerMovementController.instance.playerAnimator.SetBool("isDead", true);
            PlayerMovementController.instance.playerAnimator.SetBool("isMoving", false);
            StartCoroutine(DelayAfterFinish());
        }
    }

    IEnumerator DelayAfterFinish()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
    }
}
