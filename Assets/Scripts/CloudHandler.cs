using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CloudHandler : MonoBehaviour
{

    [SerializeField] private SpriteRenderer[] cloudSprites;
    [SerializeField] private int numberOfClouds;

    [SerializeField] private int xLimit;
    [SerializeField] private int yLimit;
    [SerializeField] private float spread;

    private SpriteRenderer[] clouds;
    private float[] speeds;

    private Vector3 frameMove;

    void Awake()
    {
        clouds = new SpriteRenderer[numberOfClouds];
        speeds = new float[numberOfClouds];

        int cloudMaxIndex = cloudSprites.Length - 1;
        int index;
        Vector3 position;

        for (int i = 0; i < numberOfClouds; i++)
        {
            index = Random.Range(0, cloudMaxIndex);
            position = new Vector3(Random.Range(-1.0f * xLimit, xLimit), RandomFromDistribution.RandomNormalDistribution(yLimit, yLimit/spread), 0.0f);
            clouds[i] = Instantiate(cloudSprites[index], position, Quaternion.identity);
            speeds[i] = Random.Range(-10.0f, 10.0f);
        }
    }

    void Update()
    {
        for (int i = 0; i < numberOfClouds; i++)
        {
            frameMove = speeds[i] * Vector3.right *Time.deltaTime;
            GameObject curent = clouds[i].gameObject;
            curent.transform.Translate(frameMove);

            Vector3 afterMove = curent.transform.position;

            if (Mathf.Abs(afterMove.x) >= xLimit) {
                afterMove.x *= -1.0f;
                curent.transform.SetPositionAndRotation(afterMove, Quaternion.identity);
            }
        }
    }
}
