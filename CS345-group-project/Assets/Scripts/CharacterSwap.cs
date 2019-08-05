using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    private bool _swapped;

    public GameObject _FPSController;
    public GameObject _cylinder;
    public GameObject _cube;
    // Start is called before the first frame update
    void Start()
    {
        _FPSController.SetActive(true);
        _cylinder.SetActive(false);
        _cube.SetActive(false);
        _swapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_swapped)
            {
                swapObjects(_cylinder, _FPSController);
                _swapped = false;
            }
            else
            {
                _cylinder.transform.position = new Vector3(_FPSController.transform.position.x,_FPSController.transform.position.y - .5f,_FPSController.transform.position.z);
                swapObjects(_FPSController, _cylinder);
                _swapped = true;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_swapped)
            {
                swapObjects(_cube, _FPSController);
                _swapped = false;
            }
            else
            {
                _cube.transform.position = new Vector3(_FPSController.transform.position.x, _FPSController.transform.position.y - .5f, _FPSController.transform.position.z);
                swapObjects(_FPSController, _cube);
                _swapped = true;

            }
        }
    }

    void swapObjects(GameObject curObject, GameObject nextObject)
    {
        curObject.SetActive(false);
        nextObject.SetActive(true);
    }

}
