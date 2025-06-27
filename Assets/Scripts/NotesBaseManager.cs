using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Note[]notes;
}

[Serializable]
public class Note{
    public int type;
    public int num;
    public int block;
    public int LPB;
}

public class NotesBaseManager : MonoBehaviour
{
    public int noteNum;
    public string songName;

    public List <int> LaneNum = new List <int>();
    public List <int> NoteType = new List <int>();
    public List <float> NotesTime = new List <float>();
    public List <GameObject> NotesObj = new List<GameObject>();

    [SerializeField] public float NotesSpeed;
    [SerializeField] public GameObject noteObj;


    public virtual void Load(string SongName){
        TextAsset textAsset = Resources.Load<TextAsset>(SongName);

        if(textAsset == null){
            Debug.LogError($"Resources から {SongName} を読み込めませんでした。ファイル名やパスを確認してください。");
            return;
        }

        string inputString = Resources.Load<TextAsset>(SongName).ToString();
        Data inputJson = JsonUtility.FromJson<Data>(inputString);

        noteNum = inputJson.notes.Length;

        for(int i = 0; i < inputJson.notes.Length; i++){
            float kankaku = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
            float beatSec = kankaku * (float)inputJson.notes[i].LPB;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset * 0.01f;
            NotesTime.Add(time);
            LaneNum.Add(inputJson.notes[i].block);
            NoteType.Add(inputJson.notes[i].type);

            float z = NotesTime[i] * NotesSpeed -11.5f;
            NotesObj.Add(Instantiate(noteObj, new Vector3(2.7f * inputJson.notes[i].block -0.6f,0.0f,z), Quaternion.identity));
            Debug.Log(inputJson.notes[i].block);
        }
        
    }

    

    public virtual void GameClear(){
        
    }
}
