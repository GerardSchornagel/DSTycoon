using System;

/// <summary>
/// Get or Set the current Player Statistics data.
/// </summary>
public class playerStatistics
{
    public string InformationRequest;
    iniHandler iniFileHandler = new iniHandler();
    string[,] stringStatisticsData;

    /// <summary>
    /// Creates a new Profile Statistics file.
    /// </summary>
    internal void NewPlayerStatistics(string[] StatisticsInfo)
    {
        stringStatisticsData = new string[,] {
            { "[Player Statistics]", "" },
            { "<TotalCharacters>", "0" },
            { "<TotalSpendings>", "0" },
            { "<TotalEarnings>", "0" },
            { "<TotalPlayTime>", "0" },
            { "<CreateDate>", StatisticsInfo[0] },
            { "<CreateTime>", StatisticsInfo[1] }
        };
        //Start Writing New Profile
        SaveState();
    }
    
    /// <summary>
    /// Loads a Profile Statistics.
    /// </summary>
    internal void LoadPlayerStatistics()
    {
        stringStatisticsData = iniFileHandler.Load(System.IO.Directory.GetCurrentDirectory() + "\\save\\" + gamecache.currentSettings.LastProfile + "\\player\\statistics.ini");
    }
    
    /// <summary>
    /// Searches in stringStatisticsData for requested Setting and set/returns that value.
    /// </summary>
    /// <returns></returns>
    public string ReturnValue {
        get {
            int integerColumn = 0;
            int integerRow = 0;
            do {
                do {
                    if (stringStatisticsData[integerColumn, integerRow].Contains(InformationRequest)) {
                        return stringStatisticsData[integerColumn, integerRow + 1];
                    }
                    integerRow += 1;
                } while (!(integerRow > stringStatisticsData.GetUpperBound(1)));
                integerColumn += 1;
            } while (!(integerColumn > stringStatisticsData.GetUpperBound(0)));
            return "";
        }

        set {
            int integerColumn = 0;
            int integerRow = 0;
            do {
                do {
                    if (stringStatisticsData[integerColumn, integerRow].Contains(InformationRequest)) {
                        stringStatisticsData[integerColumn, integerRow + 1] = value;
                        SaveState();
                        return;
                    }
                    integerRow += 1;
                } while (!(integerRow > stringStatisticsData.GetUpperBound(1)));
                integerColumn += 1;
            } while (!(integerColumn > stringStatisticsData.GetUpperBound(0)));
        }
    }
    
    /// <summary>
    /// Saves the current state of the Profile Statistics data.
    /// </summary>
    public void SaveState()
    {
        System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\save\\" + gamecache.currentSettings.LastProfile + "\\player");
        iniFileHandler.Save(System.IO.Directory.GetCurrentDirectory() + "\\save\\" + gamecache.currentSettings.LastProfile + "\\player\\statistics.ini", stringStatisticsData);
    }
    
    /// <summary>
    /// Returns/Sets an Integer with the Total Characters.
    /// </summary>
    public int TotalCharacters {
        get {
            InformationRequest = "TotalCharacters";
            return Convert.ToInt32(ReturnValue);
        }
        set {
            InformationRequest = "TotalCharacters";
            ReturnValue = value.ToString();
            SaveState();
        }
    }
    
    /// <summary>
    /// Returns/Sets an Integer with the Total Spendings.
    /// </summary>
    public int TotalSpendings {
        get {
            InformationRequest = "TotalSpendings";
            return Convert.ToInt32(ReturnValue);
        }
        set {
            InformationRequest = "TotalSpendings";
            ReturnValue = value.ToString();
            SaveState();
        }
    }
    
    /// <summary>
    /// Returns/Sets an Integer with the Total Earnings.
    /// </summary>
    public int TotalEarnings {
        get {
            InformationRequest = "TotalEarnings";
            return Convert.ToInt32(ReturnValue);
        }
        set {
            InformationRequest = "TotalEarnings";
            ReturnValue = value.ToString();
            SaveState();
        }
    }
    
    /// <summary>
    /// Returns/Sets an Integer with the Total Play Time in Minutes.
    /// </summary>
    public int TotalPlayTime {
        get {
            InformationRequest = "TotalPlayTime";
            return Convert.ToInt32(ReturnValue);
        }
        set {
            InformationRequest = "TotalPlayTime";
            ReturnValue = value.ToString();
            SaveState();
        }
    }
    
    /// <summary>
    /// Returns/Sets a String with the profile creation date.
    /// </summary>
    public string CreateDate {
        get {
            InformationRequest = "CreateDate";
            return ReturnValue;
        }
        set {
            InformationRequest = "CreateDate";
            ReturnValue = value;
            SaveState();
        }
    }
    
    /// <summary>
    /// Returns/Sets a String with the profile creation time.
    /// </summary>
    public string CreateTime {
        get {
            InformationRequest = "CreateTime";
            return ReturnValue;
        }
        set {
            InformationRequest = "CreateTime";
            ReturnValue = value;
            SaveState();
        }
    }
}