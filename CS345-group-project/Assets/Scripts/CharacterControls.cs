using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControls : MonoBehaviour
{

    private int _index = 0;
    private GameObject _curObject;
    private bool _swapped;
    public GameObject _FPSController;
    public List<GameObject> _objects;
    public GameObject AlienUI;
    public GameObject MimicUI;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _curObject = null;
        _swapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_swapped)
            {
                Destroy(_curObject);
                _FPSController.SetActive(true);
                AlienUI.SetActive(true);
                MimicUI.SetActive(false);
                _swapped = false;
            }
            else
            {
                _curObject = (GameObject) Instantiate(_objects[_index], new Vector3(_FPSController.transform.position.x,_objects[_index].transform.position.y,_FPSController.transform.position.z), _objects[_index].transform.rotation);
                _FPSController.SetActive(false);
                AlienUI.SetActive(false);
                MimicUI.SetActive(true);
                _swapped = true;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(!_swapped)
            {
                _index++;
                if(_index >= _objects.Count)
                {
                    _index = 0;
                }
                _curObject = _objects[_index];
            }
        }
    }

}
