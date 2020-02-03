using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Move Instance { set; get; }

    [Header("Image")]
    public float Speed;
    public float BoostSeconds;
    public float BoostMagnitude;

    public bool Boost;

    private Rigidbody RigidBody;

    Vector3 direction = new Vector3(1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void Update()
    {
        var speed = RigidBody.velocity.magnitude;
        print(speed);
    }


    private void MoveCharacter()
    {
        if (!Boost && RigidBody.velocity.magnitude > 30)
            return;

        RigidBody.AddForce(direction * Speed, ForceMode.Force);
    }

    public IEnumerator BoostCharacter()
    { 
        var localBoostTimer = BoostSeconds;
        Boost = true;

        for (int i = 0; i < localBoostTimer; i++)
        {         
            while (localBoostTimer >= 0)
            {
                RigidBody.AddForce(direction * BoostMagnitude, ForceMode.Impulse);
                localBoostTimer -= Time.smoothDeltaTime;
                yield return null;
            }
        }

        Boost = false;
    }
}
