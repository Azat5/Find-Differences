using System.Collections.Generic;
using UnityEngine;

public class ClickToImage : MonoBehaviour
{
    public GameObject error;
    public AudioSource incorrect;
    private GameObject currentGameObject;
    private Stack<GameObject> stack = new Stack<GameObject>();

    private void Update()
    {
        stack.Push(currentGameObject);

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(stack.Pop());

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider.gameObject == gameObject)
            {
                incorrect.Play();
                ClickToDifference.numberOfErrors++;
                currentGameObject = Instantiate(error, hit.point, Quaternion.identity) as GameObject;
            }
        }
    }
}