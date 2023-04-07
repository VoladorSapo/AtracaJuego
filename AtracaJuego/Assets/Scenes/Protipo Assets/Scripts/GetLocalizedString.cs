using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization;
using UnityEngine;

public class GetLocalizedString  
{
    public static List<string> getLocalizedString(string table, string code) {

        List<string> list = new List<string>();
        bool finish = false;
        int i = 0;
        LocalizedString _localizedstring = new LocalizedString();
        while (!false)
        {
            _localizedstring.TableReference = table;
            string reference = code + "_" + i;
            _localizedstring.TableEntryReference = reference;
            if (!_localizedstring.GetLocalizedString().Contains("No translation found for"))
            {
                list.Add(_localizedstring.GetLocalizedString());
            }
            else
            {
                finish = true;
                break;
            }
            i++;
        }
        return list;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
