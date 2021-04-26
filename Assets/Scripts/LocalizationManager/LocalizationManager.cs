using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class LocalizationManager : MonoBehaviour
{
    public Dropdown LanguageSelection;

    [SerializeField] private TextMeshProUGUI[] m_TextToLocalize;
    [SerializeField] PlainTexts textStr;
    [SerializeField] private string[] m_JsonLangPath;
    [SerializeField] private string m_EnThJson;
    // Start is called before the first frame update

    void Start()
    {
        SetLanguageEnum();
        //GenerateLanguage();
        LoadAllLangTexts();
    }

    private void SetLanguageEnum()
    {
        string[] langNames = Enum.GetNames(typeof(LanguageSelect));
        List<string> langs = new List<string>(langNames);
        LanguageSelection.AddOptions(langs);
    }

    public void DisplayTextInLanguage() 
    {
    
    }
    private void GenerateLanguage()
    {
        //string d = AssetDatabase.GetAssetPath(); ;
        textStr = new PlainTexts();
        //m_EnThJson = JsonUtility.FromJson<string>(AssetDatabase.LoadAssetAtPath(m_JsonLangPath[0])) ;
    }

    [ContextMenu("LoadAllLangTexts")]
    private void LoadAllLangTexts() 
    {
        Debug.Log(Directory.GetCurrentDirectory().Replace("\\","/") + "/" + m_JsonLangPath[0]);
        using (StreamReader stream = new StreamReader(Directory.GetCurrentDirectory().Replace("\\", "/") + "/" + m_JsonLangPath[0]))
        {
            m_EnThJson = stream.ReadToEnd();
            textStr = JsonUtility.FromJson<PlainTexts>(m_EnThJson);
        }

        //Debug.Log("Loading... " + textStr.ClainStr.Length);
    }

}

[Serializable]
public class PlainTexts 
{
    public string[] DialogueStorageStr;
    public string CollectionName;

    public static PlainTexts CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<PlainTexts>(jsonString);
    }

}
public enum LanguageSelect
{
    Select,
    Eng,
    Thai,
    Espanol
}
