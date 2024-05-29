using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DiceRoll : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] private float maxRandomForceValue, startRollingForce;
    [SerializeField] private string diceType; // "dice6" ou "dice10"

    private int rollCount = 0;
    private const int maxRolls = 2; // Maximum number of allowed rolls

    private float forceX, forceY, forceZ;
    public string diceFaceNum;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if (body != null)
        {
            if (Input.GetKeyDown(KeyCode.Space) && rollCount < maxRolls)
            {
                RollDice();
                rollCount++;
            }
        }
    }

    private void RollDice()
    {
        body.isKinematic = false;

        forceX = Random.Range(0, maxRandomForceValue);
        forceY = Random.Range(0, maxRandomForceValue);
        forceZ = Random.Range(0, maxRandomForceValue);

        body.AddForce(Vector3.up * startRollingForce);
        body.AddTorque(forceX, forceY, forceZ);
    }

    private void Initialize()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;
        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
    }

    public string GetDiceType()
    {
        return diceType;
    }
}
