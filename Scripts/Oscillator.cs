using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f; // thoi gian 1 chu ki
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) {return;}
        float cycle = Time.time/ period; //So chu ki di dc trong 1 khoang thoi gian
        const float tau = Mathf.PI * 2; // gia tri radian cua 1 chu ki: 2pi
        float rawSinWave = Mathf.Sin(cycle * tau); // tinh gia tri sin cua so chu ki di dc -1 < x < 1
        movementFactor = (rawSinWave + 1f) / 2f; // thay doi gia tri thanh 0 - 1 cua rawSinWave cho de nhin
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
