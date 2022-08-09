using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _startDirection;
    [SerializeField] private float _minSpeed = 3;

    private Vector2 _startPosition;

    private bool _isExplosive;

    [Header("Music")]
    [SerializeField] private AudioSource _audioSource;

    #endregion


    #region Properties

    public Vector3 StartBallSize { get; private set; }

    #endregion


    private void Awake()
    {
        _startPosition = transform.position;
        StartBallSize = transform.localScale;
    }

    private void Start()
    {
        if (GameManager.Instance.NeedAutoPlay)
            GameManager.Instance.StartBall();
    }

    private void Update()
    {
        CheckSpeed();
    }

    private void CheckSpeed()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
            if (ball._rb.velocity.magnitude < _minSpeed)
                ball._rb.velocity = _rb.velocity.normalized * _minSpeed;
    }


    #region Private methods

    private static void DestroyBlockByExplosive(Collider2D[] colliders)
    {
        foreach (Collider2D collider in colliders)
        {
            Block blockToExplode = collider.GetComponent<Block>();
            blockToExplode.DestroyBlock();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, (Vector3) _startDirection + transform.position);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _audioSource.Play();
        if (_isExplosive & col.gameObject.CompareTag(Tags.Block))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.8f, 9);

            DestroyBlockByExplosive(colliders);
        }
    }

    #endregion


    #region Public methods

    public void StartMove()
    {
        _rb.velocity = _startDirection;
    }

    public void MoveWithPad()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = Pad.Instance.PadPositionX;
        transform.position = currentPosition;
    }

    public void ChangeSpeed(float speedMultiplier)
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
        {
            Vector2 velocity = ball._rb.velocity;
            float velocityMagnitude = velocity.magnitude;
            velocityMagnitude *= speedMultiplier;

            if (velocityMagnitude < _minSpeed)
                velocityMagnitude = _minSpeed;

            ball._rb.velocity = velocity.normalized * velocityMagnitude;
        }
    }

    public void ChangeSize(float size)
    {
        float currentSizeBall = gameObject.transform.localScale.x;
        if (currentSizeBall == size * StartBallSize.x)
            return;
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
            ball.transform.localScale *= size;
    }

    public void RestartPosition()
    {
        transform.position = _startPosition;
    }

    public void SnapBallToPad()
    {
        PauseManager.Instance.StopTime();
        RestartPosition();
        GameManager.Instance.ReturnBallAndPad();
    }

    public void DoubleBall(GameObject ball)
    {
        Instantiate(ball, ball.transform.position, Quaternion.identity);
        CheckSpeed();
    }

    public void ChangeSprite(Sprite newSprite, SpriteRenderer ballSpriteRenderer)
    {
        //ballSpriteRenderer.sprite = newSprite;
    }

    public void ExplosiveBall(float radius, LayerMask layerMask)
    {
        _isExplosive = true;
    }

    #endregion
}