using System.Collections;
using System.Collections.Generic;
using _Scripts._Actions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshActionText;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _selectedGameObject;

    private BaseAction _baseAction;

    public void SetBaseAction(BaseAction baseAction)
    {
        this._baseAction = baseAction;
        _textMeshActionText.text = baseAction.GetActionName().ToUpper();
        
        _button.onClick.AddListener((() =>
        {
            UnitActionSystem.Instance.SetSelectedAction(baseAction);
        }));
    }

    public void UpdateSelectedVisual()
    {
        BaseAction selectedBaseAction = UnitActionSystem.Instance.GetSelectedAction();
        _selectedGameObject.SetActive(selectedBaseAction == _baseAction);
    }
}
