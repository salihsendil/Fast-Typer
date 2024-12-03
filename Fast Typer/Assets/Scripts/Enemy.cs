using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private TMP_Text _wordText;
    private float _speed = 0.3f;


    //Getters - Setters
    public string WordText { get => _wordText.text; }

    void Awake()
    {
        _wordText = GetComponentInChildren<TMP_Text>();
        //Debug.Log("Spawn Oldum");
    }

    private void OnDisable()
    {
        //Debug.Log("havuza döndüm");
    }

    private void OnEnable()
    {
        _wordText.text = WordManager.Instance.GetRandomWord();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 Player.Instance.transform.position, 
                                                 _speed * Time.deltaTime);
        _speed += Time.deltaTime;
    }
}
