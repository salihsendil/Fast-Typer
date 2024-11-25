using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] WordListImporter _wordListImporter;
    private int _wordLength = 2;
    int _lastIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (_wordListImporter)
        {
            _lastIndex = _wordListImporter.GetCustomLengthLastIndex(_wordLength);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_wordListImporter)
            {
                int random = Random.Range(0, _wordListImporter.GetCustomLengthLastIndex(_wordLength));
                Debug.Log(_wordListImporter.WordsList[random]._word);
            }
        }
    }
}
