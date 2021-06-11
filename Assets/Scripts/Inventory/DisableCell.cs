using UnityEngine;

public class DisableCell : MonoBehaviour
{
    [SerializeField] private float _timeToDisable = 2f;

    private float _currentTime;

    private void Start()
    {
        _currentTime = _timeToDisable;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0f)
        {
            _currentTime = 0f;

            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
