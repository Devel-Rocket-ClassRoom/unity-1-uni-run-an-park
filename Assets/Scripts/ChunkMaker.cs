using UnityEngine;

public class ChunkMaker : MonoBehaviour
{
    private GameObject[] ChunkPool;
    private int[] _createdTime;
    private int _createdCount = 0;
    private int _count;
    public GameObject[] Chunk;
    private int currentChunkCount = 0;

    public float xPos = 10f;

    private float makeInterval;
    private float currentMakeInterval = 0;


    private void Start()
    {
        _count = Chunk.Length;
        ChunkPool = new GameObject[_count];
        _createdTime = new int[_count];
        makeInterval = 7.5f / GameManager.Instance.scrollSpeed;

        for (int i = 0; i < ChunkPool.Length; i++)
        {
            _createdTime[i] = -7;
            ChunkPool[i] = Instantiate(Chunk[i]);
            ChunkPool[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (GameManager.Instance.isGameOver) return;

        currentMakeInterval -= Time.deltaTime;

        if (currentMakeInterval < 0)
        {
            currentMakeInterval = makeInterval;
            MakeChunk();
        }
    }

    private void MakeChunk()
    {
        int randomChunk;

        do
        {
            randomChunk = Random.Range(0, _count);
        }
        while (!CheckChunk(randomChunk));

        _createdTime[randomChunk] = _createdCount++;

        ChunkPool[randomChunk].transform.position = new Vector2(xPos, -5);
        ChunkPool[randomChunk].SetActive(false);
        ChunkPool[randomChunk].SetActive(true);
    }

    private bool CheckChunk(int index)
    {
        if (_createdTime[index] >= _createdCount - 4)
        {
            return false;
        }

        return true;
    }
}
