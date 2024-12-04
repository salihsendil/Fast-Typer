using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private TMP_Text _wordText;
    private Vector3 _targetPos;
    private float _speed = 0.3f;

    //Getters - Setters
    public string WordText { get => _wordText.text; }

    void Awake()
    {
        _wordText = GetComponentInChildren<TMP_Text>();
        _targetPos = Player.Instance.transform.position;
        //Debug.Log("Spawn Oldum");
    }

    private void OnDisable()
    {
        //Debug.Log("havuza döndüm");
        Debug.Log(Time.deltaTime);
    }

    private void OnEnable()
    {
        _wordText.text = WordManager.Instance.GetRandomWord();
        _speed += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (_targetPos - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
