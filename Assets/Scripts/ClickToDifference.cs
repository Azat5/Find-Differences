using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickToDifference : MonoBehaviour
{
    public static byte numberOfDifferences, numberOfErrors;
    public Text differencesFound, errorsFound;
    public GameObject ok;
    public AudioSource correct;

    private void Start()
    {
        numberOfDifferences = 0;
        numberOfErrors = 0;
    }

    private void Update()
    {
        differencesFound.text = string.Empty + numberOfDifferences;
        errorsFound.text = string.Empty + numberOfErrors;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider.gameObject.tag == "differences")
            {
                correct.Play();
                numberOfDifferences++;
                hit.collider.gameObject.tag = "Untagged";
                GameObject.Find(hit.collider.gameObject.name).tag = "Untagged";
                Instantiate(ok, hit.point, Quaternion.identity);
            }
        }

        if (numberOfDifferences == 5 && !correct.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            numberOfDifferences = 0;
            numberOfErrors = 0;
        }
    }
}