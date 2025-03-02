using UnityEngine;

public class EnemyFuzzy : BaseEntity, IDamageable, IEnemy
{
    public ColliderWrapper damageCollider;
    public BaseEntityLine line;
    public LayerMask targetLayer;
    public float moveSpeed = 5f;
    private int currentTargetIndex = 0;
    private Vector2 currentTarget;
    private int increment = 1;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        line.OnLineUpdate += OnLineUpdate;
        damageCollider.OnTrigger += OnTrigger;
    }
    void OnDisable()
    {
        line.OnLineUpdate -= OnLineUpdate;
        damageCollider.OnTrigger -= OnTrigger;
    }

    void Update()
    {
        if (line.GetPointCount() == 0) return;

        MoveTowardsNextPoint();
    }
    private void OnLineUpdate(){
        currentTarget = line.GetPoint(0);
        currentTargetIndex = 0;
        transform.position = currentTarget;
        line.gameObject.SetActive(false);
    }
    private void OnTrigger(Collider2D other){
        if((other.gameObject.layer & (1 << targetLayer)) != 0){
            Debug.Log("Damage!");
        }
    }
    private void MoveTowardsNextPoint()
    {
        Vector3 direction = (currentTarget - (Vector2)transform.position).normalized;
        float step = rb.linearVelocity.magnitude * Time.deltaTime;

        if (Vector3.Distance(transform.position, currentTarget) <= step)
        {
            transform.position = currentTarget;

            PickNextPoint();
        }
        else
        {
            rb.linearVelocity = direction * moveSpeed;
        }
    }

    private void PickNextPoint(){
        if (currentTargetIndex >= line.GetPointCount()-1)
        {
            if(line.loop){
                currentTargetIndex = 0;
            } else {
                increment = -1;
                currentTargetIndex += increment;
            }
        }
        else if( currentTargetIndex <= 0) {
            increment = 1;
            currentTargetIndex += increment;
        } else {
            currentTargetIndex += increment;
        }

        currentTarget = line.GetPoint(currentTargetIndex);
    }

    public void TakeDamage()
    {
        
    }
}
