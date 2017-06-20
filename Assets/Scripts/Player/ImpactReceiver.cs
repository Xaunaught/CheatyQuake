using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactReceiver : MonoBehaviour
{
    public float mass = 1;
    Vector3 impact = Vector3.zero;
    private CharacterController characterController;
    public float lerpSpeed = 5;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (impact.magnitude > 0.2f)
            characterController.Move(impact * Time.deltaTime);
        impact = Vector3.Lerp(impact, Vector3.zero, lerpSpeed * Time.deltaTime);
    }

    public void AddImpact(Vector3 direction, float force)
    {
        direction.Normalize();
        if (direction.y < 0) direction.y = -direction.y; //reflect down force on the ground
        impact += direction.normalized * force / mass;
    }
}
