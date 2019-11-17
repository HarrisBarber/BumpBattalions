using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommander : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerCommander instance;
    public GameObject cursorPrefab;
    private GameObject unit1;
    public bool play = false;

    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        unit1 = Instantiate(cursorPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        unit1.GetComponent<Movement>().SetMovementAxisValues(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (unit1.CompareTag("Cursor"))
            {
                GameObject result = unit1.GetComponent<Cursor>().SelectUnder();

                if (result)
                {
                    if (result.CompareTag("Player"))
                    {
                        GameObject old = unit1;
                        unit1 = result;
                        Destroy(old);
                        play = true;
                    }
                }
            }
            else
            {
                GameObject old = unit1;
                unit1 = Instantiate(cursorPrefab, old.transform);
                play = false;
            }
        }
    }
}
