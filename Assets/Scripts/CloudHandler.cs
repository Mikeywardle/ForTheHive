using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CloudHandler : MonoBehaviour
{

    public SpriteRenderer[] cloudSprites;
    public int numberOfClouds;

    private SpriteRenderer[] clouds;
    private bool[] movingLefts;
    private float[] speeds;

    public int xLimit;
    public int yLimit;

    private Vector3 frameMove;

    void Start()
    {
        clouds = new SpriteRenderer[numberOfClouds];
        movingLefts = new bool[numberOfClouds];
        speeds = new float[numberOfClouds];

        int cloudMaxIndex = cloudSprites.Length - 1;
        int index;
        float dir;
        Vector3 position;

        for (int i = 0; i < numberOfClouds; i++)
        {
            index = Random.Range(0, cloudMaxIndex);
            position = new Vector3(Random.Range(-1.0f * xLimit, xLimit), Random.Range(1.0f, yLimit), 0.0f);
            clouds[i] = Instantiate(cloudSprites[index], position, Quaternion.identity);

            dir = Random.Range(-1.0f, 1.0f);
            movingLefts[i] = dir>= 0.0f;

            speeds[i] = Random.Range(1.0f, 10.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numberOfClouds; i++)
        {
            if(movingLefts[i])
                frameMove = Vector3.left;
            else
                frameMove = Vector3.right;

            frameMove = frameMove * speeds[i] * Time.deltaTime *Mathf.Sin(Time.fixedTime);
            clouds[i].gameObject.transform.Translate(frameMove);
        }
    }
}
