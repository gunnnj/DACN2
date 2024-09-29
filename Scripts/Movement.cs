using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] ParticleSystem rightThruster;
    [SerializeField] ParticleSystem leftThruster;
    [SerializeField] ParticleSystem booster;
    [SerializeField] float thrustSpeed = 100f;
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] AudioClip mainEngine;
    Rigidbody rb;
    AudioSource audioSource;
    CollisionHandler collisionHandler;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        collisionHandler = GetComponent<CollisionHandler>();
    }
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust() {
        if(Input.GetKey(KeyCode.Space)){
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        booster.Play();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }
    void StopThrusting()
    {
        audioSource.Stop();
    }

    void ProcessRotation() {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            RotateRight();
        }
    }
    private void RotateLeft()
    {
        rightThruster.Play();
        ApplyRotation(rotateSpeed);
    }
    private void RotateRight()
    {
        leftThruster.Play();
        ApplyRotation(-rotateSpeed);
    }
    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
