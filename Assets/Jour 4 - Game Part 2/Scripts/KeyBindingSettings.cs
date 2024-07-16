using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class KeyBindingSettings : MonoBehaviour
{
    public InputActionReference fireAction = null;
    public PlayerController playerController = null;
    public Text bindingDisplayNameText = null;
    public GameObject startRebindObject = null;
    public GameObject waitingForInputObject = null;

    private string rebindsKey = "Rebinds";
    // private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    public void Start()
    {
        string rebinds = PlayerPrefs.GetString(rebindsKey, string.Empty);
        if (string.IsNullOrEmpty(rebinds))
        {
            return;
        }
        playerController.PlayerInput.actions.LoadBindingOverridesFromJson(rebinds);

        int bindingIndex = fireAction.action.GetBindingIndexForControl(fireAction.action.controls[0]);
        bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(fireAction.action.bindings[bindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
    }

    public void StartRebinding()
    {
        startRebindObject.SetActive(false);
        waitingForInputObject.SetActive(true);

        playerController.PlayerInput.SwitchCurrentActionMap("Menu");

        fireAction.action.PerformInteractiveRebinding()
            // .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(RebindComplete)
            .Start();
    }

    public void Save()
    {
        string rebinds = playerController.PlayerInput.actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString(rebindsKey, rebinds);
    }

    private void RebindComplete(InputActionRebindingExtensions.RebindingOperation operation)
    {
        int bindingIndex = fireAction.action.GetBindingIndexForControl(fireAction.action.controls[0]);
        bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(fireAction.action.bindings[bindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        operation.Dispose();

        startRebindObject.SetActive(true);
        waitingForInputObject.SetActive(false);

        playerController.PlayerInput.SwitchCurrentActionMap("Player");
        Save();
    }
}
