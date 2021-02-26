using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UIHandler : MonoBehaviour
{
    private static bool _hidden = false;
    private static int _index;
    [SerializeField] GameObject[] _reactions;

    [SerializeField] private GameObject _controls;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var go in _reactions)
        {
            go.SetActive(false);
        }

        _reactions[0].SetActive(true);
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _hidden = true;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _hidden = !_hidden;
        }

        if (_index >= _reactions.Length)
        {
            return;
        }
        
        if (_hidden)
        {
            _controls.SetActive(false);
            _reactions[_index].SetActive(false);
        }
        else
        {
            _controls.SetActive(true);
            _reactions[_index].SetActive(true);
        }
    }

    public static void ShowHint()
    {
        _hidden = false;
        _index++;
    }
}
