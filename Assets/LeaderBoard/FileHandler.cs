using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileHandler : MonoBehaviour {


    public static string savePath = "Assets/data/";
    public static string fileExtension = ".txt";
    public static string[] defaultExtensions = new string[] { ".meta" };

    public static List<string> LinesOfFile(string filePath, bool removeBlankLines = true)
    {
        filePath = AttemptCorrectFilePath(filePath);
        if (File.Exists(filePath))
        {
            string content = GetRawFileContent(filePath);
            List<string> lines = GetLinesFromContent(content, removeBlankLines);
            return lines;

        }
        else
        {
            string errorMessage = "ERROR, FILE " + filePath + "does not exist";
            Debug.Log(errorMessage);
            return new List<string>() { errorMessage };

        }
    }

    static string AttemptCorrectFilePath(string filePath)
    {
        filePath = filePath.Replace("[]", savePath);
        if (!filePath.Contains(".")) filePath += fileExtension;
        return filePath;
    }

    public static void SaveFileWithLines(string filePath, List<string> lines)
    {
        filePath = AttemptCorrectFilePath(filePath);

        TryCreateDirectoryFromPath(filePath);

        StreamWriter sw = new StreamWriter(filePath);
        int i = 0;
        for (i = 0; i < lines.Count; i++)
        {
            sw.WriteLine(lines[i]);
        }   
        sw.Close();
        print("Saved" +  i.ToString()+"lines to file [" + filePath+"]");
    }

    public static string GetRawFileContent(string filePath)
    {
        StreamReader sr = new StreamReader(filePath);
        string content = sr.ReadToEnd();
        sr.Dispose();
        return content;
    }

    public static List<string> GetLinesFromContent(string content, bool removeBlankLines = true)
    {
        string[] splitLines = RemoveLineReadLine(content);
        List<string> trueList = ArrayToList(splitLines, removeBlankLines);
        return trueList;
    }

    static string[] RemoveLineReadLine(string content)
    {
        string[] splitLines;
        char[] splitters = new char[] { '\n', '\r' };
        splitLines = content.Split(splitters);
        return splitLines;
;    }

    static List<string> ArrayToList(string[] array, bool removeBlankLines = true)
    {
        List<string> list = new List<string>();
        for (int i = 0; i < array.Length; i++)
        {
            string s = array[i];
            if (s.Length > 0 || !removeBlankLines)
            {
                list.Add(s);
            }
        }
        return list;
    }

    public static bool TryCreateDirectoryFromPath(string path)
    {
        string directoryPath = path;
        if (Directory.Exists(path) || File.Exists(path)) return true;
        if (path.Contains("."))
        {
            directoryPath = "";
            string[] parts = path.Split('/');
            foreach (string part in parts)
            {
                if (!part.Contains("."))
                    directoryPath += path + "/";

            }
            if (Directory.Exists(directoryPath))
                return true;
        }
        if (directoryPath != "" && !directoryPath.Contains("."))
         {
            Directory.CreateDirectory(directoryPath);
            return true;
        }
        else
        {
            Debug.LogError("Directory was invalid" + directoryPath );
            return false;
        }
    }


    public static bool DirectoryExists(string path)
    {
        path = path.Replace("[]", savePath);
        return Directory.Exists(path);
    }

    public static bool FileExists(string path)
    {
        path = AttemptCorrectFilePath(path);
        return File.Exists(path);
    }

    public static List<string> GetAllFilesInDirectory(string directory, string[] excludeExtensions, string searchExtension = "")
    {
        directory = directory.Replace("[]", savePath);

        List<string> retVal = new List<string>();
        if (DirectoryExists(directory))
        {
            DirectoryInfo d = new DirectoryInfo(directory);
            FileInfo[] files = (searchExtension == "") ? d.GetFiles() : d.GetFiles((searchExtension.StartsWith("*")? searchExtension: "*"+ searchExtension));

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i];
                foreach (string ext in excludeExtensions)
                {
                    if (file.FullName.ToLower().EndsWith(ext.ToLower()))
                        continue;
                    else
                    {
                        retVal.Add(file.Name);
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Directory does not exist." + directory+"- could not get files.");
        }
        return retVal;
    }

}
