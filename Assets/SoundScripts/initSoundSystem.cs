using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class initSoundSystem : MonoBehaviour {
    public FMOD_StudioSystem soundSystem;
	void Awake () {
        soundSystem = FMOD_StudioSystem.instance;
        string fileName = Application.dataPath + "/StreamingAssets/Master Bank.bank";
        FMOD.Studio.Bank bank;
        soundSystem.System.loadBankFile(fileName, out bank);
        FMOD.Studio.Bank bankStrings;
        soundSystem.System.loadBankFile(fileName + ".strings", out bankStrings);
        Debug.Log("Sound system loaded.");
	}

    void OnDestroy()
    {
        //soundSystem.System.release();
    }
}
