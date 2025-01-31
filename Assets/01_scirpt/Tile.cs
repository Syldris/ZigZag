using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private float falldownTime = 2; // Ÿ���� �Ʒ��� �������� �ð�
    private Rigidbody rigidbody; // Ÿ�� �߶� ������ ���� Rigidbody
    private Tilespawner tileSpawner = null; // Ÿ�� ����� �޼ҵ� ȣ���� ���� TileSpawner

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Setup(Tilespawner tileSpawner)
    {
        this.tileSpawner = tileSpawner;
    }

    private void OnCollisionExit(Collision collision)
    {
        // �÷��̾ Ÿ���� ��� �������� �Ʒ��� ��������
        if(collision.transform.CompareTag("Player"))
        {
            StartCoroutine(FallDownAndRespawnTile());
        }
    }

    private IEnumerator FallDownAndRespawnTile()
    {
        yield return new WaitForSeconds(0.1f);

        // ������ ����ǵ��� ����( �߷��� �޾� �Ʒ��� ��������)
        rigidbody.isKinematic = false;

        yield return new WaitForSeconds(falldownTime);

        // ������ ������� �ʵ��� ����
        rigidbody.isKinematic = true;

        // ó������ �����Ǿ� �ִ� StartGround, FirstTile�� ������ TiileSpawner�� ���ؼ� ������ Ÿ�ϵ��� ����
        if(tileSpawner != null)
        {
            tileSpawner.SpawnTile(this.transform);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
