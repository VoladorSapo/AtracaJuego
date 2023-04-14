using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDialogueHandler : MonoBehaviour
{
    [SerializeField] GameDialogController _GDC;

    // Start is called before the first frame update
    public void sendDialog(string table, string code)
    {
        Debug.LogWarning(table + "   " + code);
        int max = GetLocalizedString.getLocalizedLength(table, code);
        List<string> list = new List<string>();
        Debug.LogWarning(max);
        if (max != 0)
        {
            int rnd = Random.Range(0, max);
            string newcode = code + "_" + rnd;

            list = GetLocalizedString.getLocalizedString(table, newcode);
        }
        //_GDC.loadDialogs(list);
    }
    public void MoveDialogue(string playername)
    {

        string code = "move" + playername;
        sendDialog("MoveandDamage", code);

    }
    public void SelectDialogue(string playername)
    {

        string code = "select" + playername;
        sendDialog("MoveandDamage", code);

    }
    public void DamageDialogue(string playername)
    {
        string code = "damage" + playername;
        sendDialog("MoveandDamage", code);
    }
    public void AttackDialogue(string playername, CustomTileClass tile1, CustomTileClass tile2)
    {
        string type;
        string code = "";
        switch (playername)
        {
            case "Ignacio":
                switch (tile2.GetTileEffect())
                {
                    case 0:
                        type = "Empty";
                        code = "Ignacio_Nada";
                        break;
                    case 1:
                        type = "Gas";
                        code = "IgnacioBoom";
                        break;
                    case 2:
                        type = "Water";
                        code = "Vapor";
                        break;
                    case 3:
                        type = "Gasoline";
                        code = "FireGasoline";
                        break;
                    case 4:
                        type = "Fire";
                        code = "DoubleFire";
                        break;
                    case 5:
                        type = "Frozen";
                        code = "IgnacioMeltIce";
                        break;
                    case 6:

                        type = "Electric";
                        code = "Ignacio_Nada";

                        break;
                    case 7:
                        type = "Gas";
                        code = "IgnacioBoom+";
                        break;
                    case 8:
                        type = "Spikes";
                        code = "IgnacioMeltIce";

                        break;
                    case 9:
                        type = "IceGasoline";
                        code = "MeltGasoline";
                        break;
                    case 10:
                        type = "SpikeGasoline";
                        code = "MeltGasoline";
                        break;
                    case 11:
                        type = "Gasoline";
                        code = "FireGasoline+";
                        break;
                    case 12:

                        type = "Fire";
                        code = "DoubleFire";

                        break;
                    case 13:
                        type = "Fire";
                        code = "DoubleFire";

                        break;
                    case 14:

                        type = "IceGasoline";
                        code = "MeltGasoline";

                        break;
                    case 15:
                        type = "SpikeGasoline";
                        code = "MeltGasoline";

                        break;
                    case 16:
                        type = "Nothing";
                        code = "Ignacio_Nada";

                        break;
                }
                break;
            case "Iowa":
                if (tile2.GetPlayer() != null && (tile2.GetPlayer().tag == "Player" || tile2.GetPlayer().tag == "IceCube"))
                {
                    if (tile2.GetPlayer().tag == "Player")
                    {
                        code = "PushPlayer";
                    }
                    if (tile2.GetPlayer().tag == "IceCube")
                    {
                        code = "PushCube";
                    }
                }
                else
                {

                    switch (tile2.GetTileEffect())
                    {
                        case 0:
                            type = "Empty";
                            code = "Iowa_Nada";
                            break;
                        case 1:
                            type = "Gas";
                            code = "PushGas";
                            break;
                        case 5:
                            type = "Frozen";
                            code = "SpikeIce";
                            break;
                        case 7:
                            type = "Gas";
                            code = "PushGas";
                            break;
                        case 9:
                            type = "IceGasoline";
                            code = "SpikeGasoline";
                            break;
                        case 14:

                            type = "IceGasoline";
                            code = "SpikeGasoline";

                            break;
                        default:
                            type = "Nothing";
                            code = "Iowa_Nada";

                            break;
                    }
                }
                break;
            case "Marl":
                switch (tile2.GetTileEffect())
                {
                    case 0:
                        type = "Empty";
                        code = "Gas";
                        break;
                    case 1:
                        type = "Gas";
                        code = "DoubleGas";
                        break;
                    case 4:
                        type = "Fire";
                        code = "MarlBoom";
                        break;
                    case 5:
                        type = "Frozen";
                        code = "MarlGasoline";
                        break;
                    case 8:
                        type = "Spikes";
                        code = "MarlGasoline";

                        break;

                    case 12:

                        type = "Fire";
                        code = "MarlBoom";

                        break;
                    case 13:
                        type = "Fire";
                        code = "MarlBoom";

                        break;

                        break;
                    default:
                        type = "Nothing";
                        code = "Gas";

                        break;
                }
                break;
            case "Pol":
                if (tile2.GetPlayer() != null && (tile2.GetPlayer().tag == "Player" || tile2.GetPlayer().tag == "Placa"))
                {
                    if (tile2.GetPlayer().tag == "Player")
                    {
                        switch (tile2.GetPlayer().GetType().ToString())
                        {
                            case "Nev":
                                code = "RevNev";
                                break;
                            case "Iowa":
                                code = "RevIowa";
                                break;
                            case "Marl":
                                code = "RevMarl";
                                break;
                            case "Ignacio":
                                code = "RevIgnacio";
                                break;
                        }
                    }
                }
                else
                {
                    switch (tile2.GetTileEffect())
                    {
                        case 0:
                            type = "Empty";
                            code = "Pol_Nada";
                            break;
                        case 1:
                            type = "Gas";
                            code = "ElecPlus";
                            break;
                        case 2:
                            type = "Water";
                            code = "Shock";
                            break;
                        case 3:
                            type = "Gasoline";
                            code = "ElecPlus";
                            break;
                        case 5:
                            type = "Frozen";
                            code = "Pol_Nada";
                            break;
                        case 6:

                            type = "Electric";
                            code = "DoubleElec";

                            break;
                        case 7:
                            type = "Gas";
                            code = "DoubleElec";
                            break;
                        case 8:
                            type = "Spikes";
                            code = "Pol_Nada";

                            break;
                        case 9:
                            type = "IceGasoline";
                            code = "Pol_Nada";
                            break;
                        case 10:
                            type = "SpikeGasoline";
                            code = "Pol_Nada";
                            break;
                        case 11:
                            type = "Gasoline";
                            code = "DoubleElec+";
                            break;

                        case 14:

                            type = "IceGasoline";
                            code = "Pol_Nada";

                            break;
                        case 15:
                            type = "SpikeGasoline";
                            code = "Pol_Nada";

                            break;
                        case 16:
                            type = "Nothing";
                            code = "Pol_Nada";

                            break;
                    }
                }
                break;
            case "Nev":
                switch (tile2.GetTileEffect())
                {
                    case 0:
                        type = "Empty";
                        code = "Freeze";
                        break;
                    case 1:
                        type = "Gas";
                        code = "MakeGasoline";
                        break;
                    case 2:
                        type = "Water";
                        code = "FreezeWater";
                        break;
                    case 3:
                        type = "Gasoline";
                        code = "FreezeGasoline";
                        break;
                    case 4:
                        type = "Fire";
                        code = "NevIceMelts";
                        break;
                    case 5:
                        type = "Frozen";
                        code = "DoubleFreeze";
                        break;
                    case 7:
                        type = "Gas";
                        code = "MakeGasoline";
                        break;
                    case 8:
                        type = "Spikes";
                        code = "DoubleFreeze";

                        break;
                    case 9:
                        type = "IceGasoline";
                        code = "DoubleFreeze";
                        break;
                    case 10:
                        type = "SpikeGasoline";
                        code = "DoubleFreeze";
                        break;
                    case 11:
                        type = "Gasoline";
                        code = "FreezeGasoline";
                        break;
                    case 12:

                        type = "Fire";
                        code = "NevIceMelts";

                        break;
                    case 13:
                        type = "Fire";
                        code = "NevIceMelts";

                        break;
                    case 14:

                        type = "IceGasoline";
                        code = "DoubleFreeze";

                        break;
                    case 15:
                        type = "SpikeGasoline";
                        code = "DoubleFreeze";

                        break;
                    case 16:
                        type = "Nothing";
                        code = "Nev_Nada";

                        break;
                    default:
                        code = "Freeze";
                        break;
                }
                break;
            case "Garrote":
                code = "Garrote";
                break;
        }
        sendDialog("AttackDialog", code);
    }
}
