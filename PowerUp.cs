using UnityEngine;

public class PowerUp : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip coin;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroom,
        Starpower,
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Coin:
                audioSource.PlayOneShot(coin);
                GameManager.Instance.AddCoin();
                break;

            case Type.ExtraLife:
                GameManager.Instance.AddLife();
                break;

            case Type.MagicMushroom:
                player.GetComponent<Player>().Grow();
                break;

            case Type.Starpower:
                player.GetComponent<Player>().Starpower();
                break;
        }

        Destroy(gameObject);
    }

}
