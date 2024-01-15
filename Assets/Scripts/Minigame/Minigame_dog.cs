using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Minigame_dog : MonoBehaviour
{

    public static EventHandler<int> DieEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Dead!");

            if (DieEvent != null)
                DieEvent(this, 0);
        }
    }

    [SerializeField] private Transform unit;
    [SerializeField] private Transform dir;
    [SerializeField] private float moveSpeed = 1f;
    private float remainMoveRange;
    private float moveCooldown;

    public void Init(bool first = false)
    {
        Vector3 randomPos = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0f);
        randomPos.Normalize();
        dir.localPosition = randomPos;

        float angle = Mathf.Atan2(randomPos.y, randomPos.x) * Mathf.Rad2Deg;
        unit.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (first)
        {
            remainMoveRange = 0f;
            moveCooldown = UnityEngine.Random.Range(0.5f, 1f);
        }
        else
        {
            remainMoveRange = UnityEngine.Random.Range(0.5f, 2f);
            moveCooldown = UnityEngine.Random.Range(0f, 1f);
        }
    }

    private void Update()
    {
        if (remainMoveRange <= 0f)
        {
            if (moveCooldown > 0f)
            {
                moveCooldown += -1f * Time.deltaTime;
                return;
            }
            else
            {
                Init();
                return;
            }
        }

        transform.position += moveSpeed * Time.deltaTime * dir.localPosition;
        remainMoveRange += -1f * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) >= MinigameManager.Instance.rect.x || Mathf.Abs(transform.position.y) >= MinigameManager.Instance.rect.y)
        {
            Vector3 toZero = -1f * transform.position;
            toZero.Normalize();
            transform.position += 0.01f * toZero;
            remainMoveRange = 0f;
        }
    }
}
