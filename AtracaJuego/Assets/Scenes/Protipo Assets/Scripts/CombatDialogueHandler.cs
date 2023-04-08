using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDialogueHandler : MonoBehaviour
{
    GameDialogController _GDC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackDialogue(string playername, CustomTileClass tile1, CustomTileClass tile2)
    {
        string type;
        string code;
        switch (playername)
        {
            case "Ignacio":
                switch (tile2.GetTileEffect())
                {
                    case 0:
                        type = "Empty";
                        break;
                    case 1:
                        type = "Gas";
                            code = "Boom";
                        break;
                    case 2:
                        type = "Water";
                            code = "Vapor";
                        break;
                    case 3:
                        type = "Gasoline";
                            code = "";
                        break;
                    case 4:
                        type = "Fire";
                        code = "DoubleFire";
                        break;
                    case 5:
                        type = "Frozen";
                            code = "MeltIce";
                        break;
                    case 6:

                        type = "Electric";
                        break;
                    case 7:
                        type = "";
                        break;
                    case 8:
                        type = "Spikes";

                        break;
                    case 9:
                        type = "IceGasoline";
                        code = "MeltGasoline";
                        break;
                    case 10:
                        type = "SpikeGasoline";
                        
                        break;
                    case 11:
                        type = "Gas";
                        break;
                    case 12:

                        type = "Fire";
                        break;
                    case 13:
                        type = "Fire";
                        break;
                    case 14:

                        type = "IceGasoline";
                        break;
                    case 15:
                        type = "SpikeGasoline";
                        break;
                    case 16:
                        type = "Nothing";

                        break;
                }
                break;
            case "Iowa":
                break;
            case "Marl":
                break;
            case "Pol":
                break;
            case "Nev":
                break;
            case "Garrote":
                break;
        }
        
    }
}
