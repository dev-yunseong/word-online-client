using System.Collections.Generic;
using Script.Data;
using TMPro;
using UnityEngine;

public class ServerDropDown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    private void Start()
    {
        dropdown.ClearOptions();
        
        List<string> options = new List<string>();
        ServerList.servers.ForEach(server => options.Add(server.name));
        
        dropdown.AddOptions(options);
        
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        LoadPings();
    }

    private void LoadPings()
    {
        int index = 0;
        foreach (Server server in ServerList.servers)
        {
            var index1 = index;
            StartCoroutine(server.GetPing(ping => ChangeOptionText(index1, $"{server.name} {(ping < 0 ? "no signal" : $"({ping} ms)")}")));
            index++;
        }
    }
        
    private void ChangeOptionText(int optionIndex, string newText)
    {
        
        if (optionIndex >= 0 && optionIndex < dropdown.options.Count)
        {
            dropdown.options[optionIndex].text = newText;
            
            dropdown.RefreshShownValue();
        }
    }
    
    private void OnDropdownValueChanged(int index)
    {
        SceneContext.SetServer(index);
    }
}