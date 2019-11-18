using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommander : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerCommander instance;
    public GameObject cursorPrefab;
    private GameObject unit1;
    private GameObject unit2;
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

        unit1 = Instantiate(cursorPrefab, transform.position + new Vector3(-0.5f, 0.0f), Quaternion.identity);
        unit1.GetComponentInChildren<SpriteRenderer>().color = new Color(0.0f, 0.8f, 1.0f);
        unit2 = Instantiate(cursorPrefab, transform.position + new Vector3(0.5f, 0.0f), Quaternion.identity);
        unit2.GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 0.68f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
            unit1.GetComponent<Movement>().SetMovementAxisValues(Input.GetAxisRaw("Horizontal1"), Input.GetAxisRaw("Vertical1"));//WASD for unit1 movement
            unit2.GetComponent<Movement>().SetMovementAxisValues(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));//numpad 8456 or IJKL for unit2 movement

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (unit1.CompareTag("Cursor"))
            {
                GameObject result = unit1.GetComponent<Cursor>().SelectUnder();

                if (result && result != unit2)
                {
                    if (result.CompareTag("Player"))
                    {
                        selectUnit(true, result);
                    }
                }
            }
            else
            {
                deselectUnit(true, false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.U))
        {
            if (unit2.CompareTag("Cursor"))
            {
                GameObject result = unit2.GetComponent<Cursor>().SelectUnder();

                if (result && result != unit1)
                {
                    if (result.CompareTag("Player"))
                    {
                        selectUnit(false, result);
                    }
                }
            }
            else
            {
                deselectUnit(false, false);
            }
        }
    }

    private void selectUnit(bool isUnit1, GameObject unitObject)
    {
        if(isUnit1)
        {
            GameObject old = unit1;
            unit1 = unitObject;
            Destroy(old);
            unit1.GetComponent<PlayerUnit>().ID = 1;
            unit1.GetComponentInChildren<SpriteRenderer>().color = new Color(0.0f, 0.8f, 1.0f);
            if (unit2.CompareTag("Player"))
            {
                play = true;
            }
        }
        else
        {
            GameObject old = unit2;
            unit2 = unitObject;
            Destroy(old);
            unit2.GetComponent<PlayerUnit>().ID = 2;
            unit2.GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 0.68f, 0.0f);
            if (unit1.CompareTag("Player"))
            {
                play = true;
            }
        }
    }

    private void deselectUnit(bool isUnit1, bool destroyUnit)
    {
        if(isUnit1)
        {
            GameObject old = unit1;
            unit1 = Instantiate(cursorPrefab, old.transform.position, Quaternion.identity);
            unit1.GetComponentInChildren<SpriteRenderer>().color = new Color(0.0f, 0.8f, 1.0f);
            if (destroyUnit)
            {
                Destroy(old);
            }
            else
            {
                old.GetComponent<PlayerUnit>().ID = 0;
                old.GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
            }
            play = false;
        }
        else
        {
            GameObject old = unit2;
            unit2 = Instantiate(cursorPrefab, old.transform.position, Quaternion.identity);
            unit2.GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 0.68f, 0.0f);
            if (destroyUnit)
            {
                Destroy(old);
            }
            else
            {
                old.GetComponent<PlayerUnit>().ID = 0;
                old.GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
            }
            play = false;
        }
    }

    public void unitDeath(bool isUnit1)
    {
        deselectUnit(isUnit1, true);
    }
}
