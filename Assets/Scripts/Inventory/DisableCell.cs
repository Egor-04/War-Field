using UnityEngine;

public class DisableCell : MonoBehaviour
{
    [SerializeField] private float _timeToDisable = 2f;

    private float _currentTime;

    private void Update()
    {
        if (gameObject.activeSelf && _currentTime <= 0f)
        {
            _currentTime = _timeToDisable;
        }

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