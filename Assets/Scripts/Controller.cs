using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{

    public GameObject robot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // cause diver to climb the ladder
        if (Input.GetKeyDown("c"))
        {

        }

        // cause diver to jump into water
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key pressed");
            var position = robot.transform.position;
            position.x = -1.70f;
            position.y = 4f;
            position.z = -10f;

            var velocity = robot.GetComponent<Rigidbody>().velocity;
            velocity.y = 0;
            robot.GetComponent<Rigidbody>().velocity = velocity;
            robot.transform.position = position;
            
        }

        // increase amplitude of the wave
        if (Input.GetKeyDown(KeyCode.A))
        {
            CSWave.IncreaseAmplitude();
        }

        // decrease amplitude of the wave
        if (Input.GetKeyDown("a"))
        {
            CSWave.DecreaseAmplitude();
        }

        // increase wavelength
        if (Input.GetKeyDown(KeyCode.L))
        {
            CSWave.IncreaseWavelength();
        }

        // decrease wavelength
        if (Input.GetKeyDown("l"))
        {
            CSWave.DecreaseWavelength();
        }

        // increase speed
        if (Input.GetKeyDown(KeyCode.V))
        {
            CSWave.IncreaseSpeed();
        }

        // increase speed
        if (Input.GetKeyDown("v"))
        {
            CSWave.DecreaseSpeed();
        }
    }
}
