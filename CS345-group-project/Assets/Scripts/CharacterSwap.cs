using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    private bool _swapped;
    private int _index = 0;
    private GameObject _curObject;

    public GameObject _FPSController;
    public List<GameObject> _objects;
    // Start is called before the first frame update
    void Start()
    {
        _curObject = null;
        _swapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_swapped)
            {
                Destroy(_curObject);
                _FPSController.SetActive(true);
                _swapped = false;
            }
            else
            {
                _curObject = (GameObject) Instantiate(_objects[_index], new Vector3(_FPSController.transform.position.x,_FPSController.transform.position.y - .5f,_FPSController.transform.position.z), Quaternion.identity);
                _FPSController.SetActive(false);
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
