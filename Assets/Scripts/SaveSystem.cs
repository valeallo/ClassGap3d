using UnityEngine;
using System.IO;// IO input output 
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(PlayerData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerdata.val";// i can give to it any extension i want cause everything can be read in binary
        FileStream fs = new FileStream(path, FileMode.Create);// STream is a stream of information that goes from a file to another 


        bf.Serialize(fs, data);// convert the player data to binary 
        fs.Close();//filestream dot close, when you creat a file stream you always want to close it whenever you finish you should always close cause you don't want anythinh more to go in there
    }


    public static PlayerData Load ()
    {
        string path = Application.persistentDataPath + "/playerdata.val";
        if(File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            
            PlayerData data = bf.Deserialize(fs) as PlayerData; // we say to it i'm reading it as player data object in our case as a score 
            fs.Close();
            return data;

        }


        else
        {
            Debug.Log("Save File Noth found in " + path);
            return null; /// the difference between void and null is that void is not data null is data but is empty data 

        }
    }
}

//I can USE this for any c# information except for the Application but that is just the address of the file
