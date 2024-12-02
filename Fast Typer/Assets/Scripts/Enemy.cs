using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log("Spawn Oldum");
    }

    private void OnDisable()
    {
        Debug.Log("havuza döndüm");
    }

    private void OnEnable()
    {
        Debug.Log("Havuzdan çýktým");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
