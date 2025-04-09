using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting_NewInput : MonoBehaviour {
    public GameObject prefab;
    public GameObject shootPoint;
    public AudioSource shootSound;
    public int bulletsAmount;
    public float fireRate;
    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void OnFire(InputValue value) {
        animator.SetBool("Shooting", value.isPressed);
        if (value.isPressed) {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
        else {
            CancelInvoke();
        }
    }

    private void Shoot() {
        if (bulletsAmount > 0 && Time.timeScale > 0) {
            bulletsAmount--;
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
            shootSound.Play();
        }
    }
}