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
        Debug.Log("havuza d�nd�m");
    }

    private void OnEnable()
    {
        Debug.Log("Havuzdan ��kt�m");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
