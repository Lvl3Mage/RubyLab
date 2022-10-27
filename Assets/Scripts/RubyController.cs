using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float lerpSpeed;
    Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        targetPos += new Vector2(hAxis, vAxis) * Speed * Time.deltaTime;

        transform.position = Vector2.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }
}