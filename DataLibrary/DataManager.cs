using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class DataManager
    {
        private List<NamedPoint> itemList;
        private const string DATA_FILE_NAME = @"SavedData.txt";
        private const int MAX_SIZE = 20;

        /// <summary>
        /// Initialize from the default database file
        /// </summary>
        public DataManager()
        {
            TextReader reader = new StreamReader(DATA_FILE_NAME);
            LoadDatabase(reader);
            reader.Close();
        }

        /// <summary>
        /// Initialize from a TextReader (for unit testing)
        /// </summary>
        public DataManager(TextReader reader)
        {
            LoadDatabase(reader);
        }

        /// <summary>
        /// Add a new item to the data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void AddItem(string name, int x, int y)
        {
            NamedPoint newItem = new NamedPoint(name, x, y);
            AddItem(newItem);
        }

        public void AddItem(NamedPoint newItem) {
            AddAndKeepSorted(newItem);
            CheckListSize();
            SaveData();
        }

        public int GetSize()
        {
            return itemList.Count;
        }

        /// <summary>
        /// Parse the database file.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private void LoadDatabase(TextReader reader)
        {
            itemList = new List<NamedPoint>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                AddAndKeepSorted(NamedPoint.Parse(line));
            }
            CheckListSize();
        }

        private void AddAndKeepSorted(NamedPoint newItem)
        {
            // Add the newItem while keeping the list sorted
            for (int i = 0; i < itemList.Count; i++)
            {
                if (newItem.CompareTo(itemList[i]) < 0) {
                    // The newItem is smaller, so insert it before item i
                    itemList.Insert(i, newItem);
                    // Found a place to put newItem, so stop processing
                    return;
                }
            }
            // Didn't find a place to put newItem, so add it to the end
            if (itemList.Count < MAX_SIZE)
            {
                itemList.Add(newItem);
            }
        }

        private void CheckListSize(int maxSize=MAX_SIZE) {
            // We may need to remove more than one extra item (if we just loaded from a data file with too many records)
            while (itemList.Count > maxSize) {
                itemList.RemoveAt(maxSize);
            }
        }

        /// <summary>
        /// Save the updated data to the disk file
        /// </summary>
        private void SaveData()
        {
            TextWriter writer = new StreamWriter(DATA_FILE_NAME);
            DumpTo(writer);
            writer.Close();
        }

        public void DumpTo(TextWriter writer)
        {
            foreach(NamedPoint item in itemList)
            {
                writer.WriteLine(item.ToCsv());
            }
        }
    }
}
