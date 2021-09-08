using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace FamilyMoneyApp

{
    public static class LoadFromFiles
    {
        public static void LoadTable(DateTime newDateTime, DataGridView mainTable)
        {
            mainTable.Rows.Clear();
            string filename = "save//MainTable" + newDateTime.Year + "_" + newDateTime.Month + "_" + newDateTime.Day + ".txt";
            try
            {
                using (var br = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    var columnsCount = br.ReadInt32();
                    var rowsCount = br.ReadInt32();
                    for (int i = 0; i < rowsCount; i++)
                    {
                        mainTable.Rows.Add();
                        for (int j = 0; j < columnsCount; j++)
                        {
                            mainTable.Rows[i].Cells[j].Value = br.ReadString();
                        }
                        byte r = br.ReadByte();
                        byte g = br.ReadByte();
                        byte b = br.ReadByte();
                        byte a = br.ReadByte();
                        var color = Color.FromArgb(a, r, g, b);
                        mainTable.Rows[i].DefaultCellStyle.BackColor = color;
                    }
                }
            }
            catch (Exception e)
            {
                mainTable.Rows.Clear();
                using (var bw = new BinaryWriter(File.Open(filename, FileMode.Create))) { }
            }
        }

        public static string[,] LoadData(DateTime newDateTime)
        {
            string filename = "save//MainTable" + newDateTime.Year + "_" + newDateTime.Month + "_" + newDateTime.Day + ".txt";
            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    var columnsCount = br.ReadInt32();
                    var rowsCount = br.ReadInt32();
                    var values = new string[rowsCount, columnsCount];

                    for (int i = 0; i < rowsCount; i++)
                    {
                        for (int j = 0; j < columnsCount - 1; j++)
                        {
                           values[i, j]  = br.ReadString();
                        }
                        br.ReadString();
                        byte r = br.ReadByte();
                        byte g = br.ReadByte();
                        byte b = br.ReadByte();
                        byte a = br.ReadByte();
                        if (r==255)
                        {
                            values[i, columnsCount - 1] = "spend";
                        }
                        else
                        {
                            values[i, columnsCount - 1] = "profit";
                        }
                    }
                    return values;
                }
            }
            catch (Exception e)
            {
                using (var bw = new BinaryWriter(File.Open(filename, FileMode.Create))) { }
                
                MyLogger.Logger.Error(e.ToString);
                
                return null;
            }
        }
    }
}