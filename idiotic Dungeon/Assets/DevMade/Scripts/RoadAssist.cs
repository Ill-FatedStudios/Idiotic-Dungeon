using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadAssist : MonoBehaviour
{

    public Transform TargetPosition;
    public Transform AimParent;

    public SpriteRenderer AssistLine;

    [SerializeField] private float AssistLineWidth;

    [SerializeField] private bool SizeModification = true;

    [SerializeField] private Color32 CanColor, CannotColor; //Colors for holo

    // Update is called once per frame
    void Update()
    {

        AimParent.transform.localPosition = new Vector3(0, 0, 0);
        Vector2 EnemyPosition = new Vector2(TargetPosition.position.x, TargetPosition.position.y);
        Vector2 lookDir = EnemyPosition - new Vector2(AimParent.position.x, AimParent.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;// - 90f;
        AimParent.transform.localEulerAngles = new Vector3(0, 0, angle);

        if (SizeModification)
        {
            float AssistSize = Vector2.Distance(AimParent.transform.position, TargetPosition.transform.position);
            AssistLine.transform.localScale = new Vector3(AssistSize, AssistLineWidth, 1);
            AssistLine.transform.localPosition = new Vector3(AssistSize * 0.5f, 0, 0);
        }
    }

    public void ChangeAssistStatus(bool Status)
    {
        if (Status)
            AssistLine.color = CanColor;
        else
            AssistLine.color = CannotColor;

    }
}
