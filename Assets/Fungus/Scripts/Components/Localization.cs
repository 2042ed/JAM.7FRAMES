// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using Ideafixxxer.CsvParser;
using Fungus.Commands;

namespace Fungus
{
    /// <summary>
    /// Multi-language localization support.
    /// </summary>
    public class Localization : MonoBehaviour, ILocalization, ISubstitutionHandler
    {
        /// <summary>
        /// Temp storage for a single item of standard text and its localizations.
        /// </summary>
        protected class TextItem
        {
            public string description = "";
            public string standardText = "";
            public Dictionary<string, string> localizedStrings = new Dictionary<string, string>();
        }

        [Tooltip("Language to use at startup, usually defined by a two letter language code (e.g DE = German)")]
        [SerializeField] protected string activeLanguage = "";

        [Tooltip("CSV file containing localization data which can be easily edited in a spreadsheet tool")]
        [SerializeField] protected TextAsset localizationFile;

        protected Dictionary<string, ILocalizable> localizeableObjects = new Dictionary<string, ILocalizable>();

        protected string notificationText = "";

        protected bool initialized;

        protected static Dictionary<string, string> localizedStrings = new Dictionary<string, string>();

        #if UNITY_5_4_OR_NEWER
        protected virtual void Awake()
        {
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += (A, B) => {
                LevelWasLoaded();
            };
        }
        #else
        public virtual void OnLevelWasLoaded(int level) 
        {
            LevelWasLoaded();
        }
        #endif

        protected virtual void LevelWasLoaded()
        {
            // Check if a language has been selected using the Set Language command in a previous scene.
            if (SetLanguage.mostRecentLanguage != "")
            {
                // This language will be used when Start() is called
                activeLanguage = SetLanguage.mostRecentLanguage;
            }
        }

        protected virtual void Start()
        {
            Init();
        }

        /// <summary>
        /// String subsitution can happen during the Start of another component, so we
        /// may need to call Init() from other methods.
        /// </summary>
        protected virtual void Init()
        {
            if (initialized)
            {
                return;
            }

            CacheLocalizeableObjects();

            if (localizationFile != null &&
                localizationFile.text.Length > 0)
            {
                SetActiveLanguage(activeLanguage);
            }

            initialized = true;
        }

        /// <summary>
        /// Looks up the specified string in the localized strings table.
        /// For this to work, a localization file and active language must have been set previously.
        /// Return null if the string is not found.            
        /// </summary>
        public static string GetLocalizedString(string stringId)
        {
            if (localizedStrings == null)
            {
                return null;
            }

            if (localizedStrings.ContainsKey(stringId))
            {
                return localizedStrings[stringId];
            }

            return null;
        }

        // Build a cache of all the localizeable objects in the scene
        protected virtual void CacheLocalizeableObjects()
        {
            UnityEngine.Object[] objects = Resources.FindObjectsOfTypeAll(typeof(Component));
            foreach (UnityEngine.Object o in objects)
            {
                ILocalizable localizable = o as ILocalizable;
                if (localizable != null)
                {
                    localizeableObjects[localizable.GetStringId()] = localizable;
                }
            }
        }

        /// <summary>
        /// Builds a dictionary of localizable text items in the scene.
        /// </summary>
        protected Dictionary<string, TextItem> FindTextItems()
        {
            Dictionary<string, TextItem> textItems = new Dictionary<string, TextItem>();

            // Add localizable commands in same order as command list to make it
            // easier to localise / edit standard text.
            var flowcharts = GameObject.FindObjectsOfType<Flowchart>();
            foreach (var flowchart in flowcharts)
            {
                var blocks = flowchart.GetComponents<IBlock>();
                foreach (var block in blocks)
                {
                    foreach (var command in block.CommandList)
                    {
                        ILocalizable localizable = command as ILocalizable;
                        if (localizable != null)
                        {
                            TextItem textItem = new TextItem();
                            textItem.standardText = localizable.GetStandardText();
                            textItem.description = localizable.GetDescription();
                            textItems[localizable.GetStringId()] = textItem;
                        }
                    }
                }
            }

            // Add everything else that's localizable (including inactive objects)
            UnityEngine.Object[] objects = Resources.FindObjectsOfTypeAll(typeof(Component));
            foreach (UnityEngine.Object o in objects)
            {
                ILocalizable localizable = o as ILocalizable;
                if (localizable != null)
                {
                    string stringId = localizable.GetStringId();
                    if (textItems.ContainsKey(stringId))
                    {
                        // Already added
                        continue;
                    }

                    TextItem textItem = new TextItem();
                    textItem.standardText = localizable.GetStandardText();
                    textItem.description = localizable.GetDescription();
                    textItems[stringId] = textItem;
                }
            }

            return textItems;
        }

        /// <summary>
        /// Adds localized strings from CSV file data to a dictionary of text items in the scene.
        /// </summary>
        protected virtual void AddCSVDataItems(Dictionary<string, TextItem> textItems, string csvData)
        {
            CsvParser csvParser = new CsvParser();
            string[][] csvTable = csvParser.Parse(csvData);

            if (csvTable.Length <= 1)
            {
                // No data rows in file
                return;
            }

            // Parse header row
            string[] columnNames = csvTable[0];
            
            for (int i = 1; i < csvTable.Length; ++i)
            {
                string[] fields = csvTable[i];
                if (fields.Length < 3)
                {
                    // No standard text or localized string fields present
                    continue;
                }
                
                string stringId = fields[0];

                if (!textItems.ContainsKey(stringId))
                {
                    if (stringId.StartsWith("CHARACTER.") || 
                        stringId.StartsWith("SAY.") || 
                        stringId.StartsWith("MENU.") ||
                        stringId.StartsWith("WRITE.") ||
                        stringId.StartsWith("SETTEXT."))
                    {
                        // If it's a 'built-in' type this probably means that item has been deleted from its flowchart,
                        // so there's no need to add a text item for it.
                        continue;
                    }

                    // Key not found. Assume it's a custom string that we want to retain, so add a text item for it.
                    TextItem newTextItem = new TextItem();
                    newTextItem.description = CSVSupport.Unescape(fields[1]);
                    newTextItem.standardText = CSVSupport.Unescape(fields[2]);
                    textItems[stringId] = newTextItem;
                }

                TextItem textItem = textItems[stringId];

                for (int j = 3; j < fields.Length; ++j)
                {
                    if (j >= columnNames.Length)
                    {
                        continue;
                    }
                    string languageCode = columnNames[j];
                    string languageEntry = CSVSupport.Unescape(fields[j]);
                    
                    if (languageEntry.Length > 0)
                    {
                        textItem.localizedStrings[languageCode] = languageEntry;
                    }
                }
            }
        }

        #region ILocalization interface

        public virtual string ActiveLanguage { get { return activeLanguage; } }

        public virtual TextAsset LocalizationFile { get { return localizationFile; } set { localizationFile = value; } }

        public virtual string NotificationText { get { return notificationText; } set { notificationText = value; } }

        public virtual void ClearLocalizeableCache()
        {
            localizeableObjects.Clear();
        }

        public virtual string GetCSVData()
        {
            // Collect all the text items present in the scene
            Dictionary<string, TextItem> textItems = FindTextItems();

            // Update text items with localization data from CSV file
            if (localizationFile != null &&
                localizationFile.text.Length > 0)
            {
                AddCSVDataItems(textItems, localizationFile.text);
            }

            // Build CSV header row and a list of the language codes currently in use
            string csvHeader = "Key,Description,Standard";
            List<string> languageCodes = new List<string>();
            foreach (TextItem textItem in textItems.Values)
            {
                foreach (string languageCode in textItem.localizedStrings.Keys)
                {
                    if (!languageCodes.Contains(languageCode))
                    {
                        languageCodes.Add(languageCode);
                        csvHeader += "," + languageCode;
                    }
                }
            }

            // Build the CSV file using collected text items
            int rowCount = 0;
            string csvData = csvHeader + "\n";
            foreach (string stringId in textItems.Keys)
            {
                TextItem textItem = textItems[stringId];

                string row = CSVSupport.Escape(stringId);
                row += "," + CSVSupport.Escape(textItem.description);
                row += "," + CSVSupport.Escape(textItem.standardText);

                foreach (string languageCode in languageCodes)
                {
                    if (textItem.localizedStrings.ContainsKey(languageCode))
                    {
                        row += "," + CSVSupport.Escape(textItem.localizedStrings[languageCode]);
                    }
                    else
                    {
                        row += ","; // Empty field
                    }
                }

                csvData += row + "\n";
                rowCount++;
            }

            notificationText = "Exported " + rowCount + " localization text items.";

            return csvData;
        }

        public virtual void SetActiveLanguage(string languageCode, bool forceUpdateSceneText = false)
        {
            if (!Application.isPlaying)
            {
                // This function should only ever be called when the game is playing (not in editor).
                return;
            }

            if (localizationFile == null)
            {
                // No localization file set
                return;
            }

            localizedStrings.Clear();

            CsvParser csvParser = new CsvParser();
            string[][] csvTable = csvParser.Parse(localizationFile.text);

            if (csvTable.Length <= 1)
            {
                // No data rows in file
                return;
            }

            // Parse header row
            string[] columnNames = csvTable[0];

            if (columnNames.Length < 3)
            {
                // No languages defined in CSV file
                return;
            }

            // First assume standard text column and then look for a matching language column
            int languageIndex = 2;
            for (int i = 3; i < columnNames.Length; ++i)
            {
                if (columnNames[i] == languageCode)
                {
                    languageIndex = i;
                    break;
                }
            }

            if (languageIndex == 2)
            {
                // Using standard text column
                // Add all strings to the localized strings dict, but don't replace standard text in the scene.
                // This allows string substitution to work for both standard and localized text strings.
                for (int i = 1; i < csvTable.Length; ++i)
                {
                    string[] fields = csvTable[i];
                    if (fields.Length < 3)
                    {
                        continue;
                    }

                    localizedStrings[fields[0]] = fields[languageIndex];
                }

                // Early out unless we've been told to force the scene text to update.
                // This happens when the Set Language command is used to reset back to the standard language.
                if (!forceUpdateSceneText)
                {
                    return;
                }
            }

            // Using a localized language text column
            // 1. Add all localized text to the localized strings dict
            // 2. Update all scene text properties with localized versions
            for (int i = 1; i < csvTable.Length; ++i)
            {
                string[] fields = csvTable[i];

                if (fields.Length < languageIndex + 1)
                {
                    continue;
                }

                string stringId = fields[0];
                string languageEntry = CSVSupport.Unescape(fields[languageIndex]);

                if (languageEntry.Length > 0)
                {
                    localizedStrings[stringId] = languageEntry;
                    PopulateTextProperty(stringId, languageEntry);
                }
            }
        }

        public virtual bool PopulateTextProperty(string stringId, string newText)
        {
            // Ensure that all localizeable objects have been cached
            if (localizeableObjects.Count == 0)
            {
                CacheLocalizeableObjects();
            }

            ILocalizable localizable = null;
            localizeableObjects.TryGetValue(stringId, out localizable);
            if (localizable != null)
            {
                localizable.SetStandardText(newText);
                return true;
            }

            return false;
        }

        public virtual string GetStandardText()
        {
            // Collect all the text items present in the scene
            Dictionary<string, TextItem> textItems = FindTextItems();

            string textData = "";
            int rowCount = 0;
            foreach (string stringId in textItems.Keys)
            {
                TextItem languageItem = textItems[stringId];

                textData += "#" + stringId + "\n";
                textData += languageItem.standardText.Trim() + "\n\n";
                rowCount++;
            }

            notificationText = "Exported " + rowCount + " standard text items.";

            return textData;
        }

        public virtual void SetStandardText(string textData)
        {
            string[] lines = textData.Split('\n');

            int updatedCount = 0;

            string stringId = "";
            string buffer = "";
            foreach (string line in lines)
            {
                // Check for string id line 
                if (line.StartsWith("#"))
                {
                    if (stringId.Length > 0)
                    {
                        // Write buffered text to the appropriate text property
                        if (PopulateTextProperty(stringId, buffer.Trim()))
                        {
                            updatedCount++;
                        }
                    }

                    // Set the string id for the follow text lines
                    stringId = line.Substring(1, line.Length - 1);
                    buffer = "";
                }
                else
                {
                    buffer += line + "\n";
                }
            }

            // Handle last buffered entry
            if (stringId.Length > 0)
            {
                if (PopulateTextProperty(stringId, buffer.Trim()))
                {
                    updatedCount++;
                }
            }

            notificationText = "Updated " + updatedCount + " standard text items.";
        }

        #endregion

        #region StringSubstituter.ISubstitutionHandler imlpementation

        public virtual bool SubstituteStrings(StringBuilder input)
        {
            // This method could be called from the Start method of another component, so we
            // may need to initilize the localization system.
            Init();

            // Instantiate the regular expression object.
            Regex r = new Regex("{\\$.*?}");

            bool modified = false;

            // Match the regular expression pattern against a text string.
            var results = r.Matches(input.ToString());
            foreach (Match match in results)
            {
                string key = match.Value.Substring(2, match.Value.Length - 3);

                // Next look for matching localized string
                string localizedString = Localization.GetLocalizedString(key);
                if (localizedString != null)
                {
                    input.Replace(match.Value, localizedString);
                    modified = true;
                }
            }

            return modified;
        }

        #endregion
    }
}