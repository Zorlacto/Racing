using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    TopDownCarController _topDownCarController;

    private void Awake()
    {
        _topDownCarController = GetComponent<TopDownCarController>();
    }


    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Horizontal");

        _topDownCarController.SetInputVector(inputVector);
    }
}
