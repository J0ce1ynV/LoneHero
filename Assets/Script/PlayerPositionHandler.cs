using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{
    public void Start()
    {

    }

    #region SaveLoad
    public TransformData playerPositionData;

    public void LoadPosition()
    {
        //untuk load
        transform.position = playerPositionData.position; 
    }
    public void SavePosition(Vector2 newPosition)
    {
        playerPositionData.position = newPosition;
    }
    private void ChangePlayerPos(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    #region Condition
    Vector2 playerCurrentPos;
    Vector2 currentCheckpointPos;

    public void onCheckPoint(GameObject col)
    {
        Vector2 newCheckpointPos = col.transform.position;
        currentCheckpointPos = newCheckpointPos;
        SavePosition(newCheckpointPos);
    }

    public void OnEnemy()
    {
        ChangePlayerPos(currentCheckpointPos);
    }
    /*
    public void onFinish(int newLevelUnlocked)
    {
        GameManager.Instance.ChangeScene(0);
        GameManager.Instance.ChangeLevel(newLevelUnlocked);
    }
    */
    //public void OnFinish()
    //{
    //    GameManager.Instance.ChangeLevel(1);
    //    GameManager.Instance.ChangeScene(0);
    //}

    public void OnFinish()
    {
        GameManager.Instance.ChangeLevel(GameManager.Instance.levelCurrent + 1);
        GameManager.Instance.ChangeScene(0);
    }

    #endregion Condition


    #endregion SaveLoad
}
