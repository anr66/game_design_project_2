using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSWave : MonoBehaviour
{

    public static int score_counter = 0;
    public GameObject robot;
    float time;

    // Amplitude
    static float A = 1;

    // Wavelength
    static float w = 1;

    // Velocity/Speed
    static float V = 1;

    // Use this for initialization
    void Start()
    {
        score_counter = 0;
    }

    // Update is called once per frame
    //void Update()
   // {
     //   //time += Time.deltaTime;
     //   time = DateTime.Now.Millisecond;
    //}

    /*

    y(r, t) = A e-r-at cos(2π (r-Vt) /λ);
    r = sqrt((x-x0)*(x-x0)+ (z-z0)*(z-z0))
    P0(x0, y0, z0) : center of the wave
    A: amplitude of the wave
    V: velocity of the wave
    λ: wave length of the wave
    a: speed of decaying
    t = current time – time of impact(t0)

    */



    private void OnTriggerEnter(Collider other)
    {

        float current_time = time;

        var milliseconds = DateTime.Now.Millisecond;

        // increment the score
        score_counter++;


        // get the point of impact
        Vector3 contact = robot.transform.position;

        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] verts = mesh.vertices;

        Vector3 plane_position = this.transform.position;
        Vector3 plane_vel = this.GetComponent<Rigidbody>().velocity;

        Debug.Log(contact.x);
        Debug.Log(contact.y);
        Debug.Log(contact.z);

        float t = milliseconds - time;
        float r = Mathf.Sqrt((contact.x) * (contact.x) + (contact.z) * (contact.z));
        float e = 2.71f;
        float a = 1.5f;
        float f = (-1 * r) - (a * t);
        float V = 1.5f;
        float w = 1f;


        for (var v = 0; v < verts.Length; v++)
        {
            
            verts[v].y = (Mathf.Pow(e * A, f) * Mathf.Cos((2 * Mathf.PI) * (r - V * t) / w));
            //verts[v].y = Mathf.Sin(Time.deltaTime);
            

            mesh.vertices = verts;

           
            
   
            //plane_vel.y = Mathf.Pow(e * A, f) * Mathf.Cos((2 * Mathf.PI) * (r - V * t) / w);
           
        }


        mesh.vertices = verts;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();





        /*
        //Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        //Vector3[] verts = mesh.vertices;
        for (var v = 0; v < verts.Length; v++)
        {
            verts[v].y = UnityEngine.Random.Range(0, 50);
        }
        mesh.vertices = verts;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        */
        
        
    }

    public static void IncreaseAmplitude()
    {
        A += 1;
    }

    public static void DecreaseAmplitude()
    {
        A -= 1;
    }

    public static void IncreaseWavelength()
    {
        w += 1;
    }

    public static void DecreaseWavelength()
    {
        w -= 1;
    }

    public static void IncreaseSpeed()
    {
        V += 1;
    }

    public static void DecreaseSpeed()
    {
        V -= 1;
    }
}