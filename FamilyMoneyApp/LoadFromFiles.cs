using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using NLog;

namespace NewFamilyMoney

{
    public class LoadFromFiles
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public static void LoadTable(DateTime newDateTime, DataGridView MainTable)
        {
            logger.Info("начало загрузки MainTable");

            MainTable.Rows.Clear();
            string filename = "save//MainTable" + newDateTime.Year + "_" + newDateTime.Month + "_" + newDateTime.Day + ".txt";
            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    int columnsCount = br.ReadInt32();
                    int rowsCount = br.ReadInt32();
                    for (int i = 0; i < rowsCount; i++)
                    {
                        MainTable.Rows.Add();
                        for (int j = 0; j < columnsCount; j++)
                        {
                            MainTable.Rows[i].Cells[j].Value = br.ReadString();
                        }
                        byte R = br.ReadByte();
                        byte G = br.ReadByte();
                        byte B = br.ReadByte();
                        byte A = br.ReadByte();
                        Color color = Color.FromArgb(A, R, G, B);
                        MainTable.Rows[i].DefaultCellStyle.BackColor = color;
                    }
                }

                logger.Info("успешная загрузка MainTable");
            }
            catch (Exception e)
            {
                MainTable.Rows.Clear();
                using (BinaryWriter bw = new BinaryWriter(File.Open(filename, FileMode.Create))) { }

                logger.Error(e.ToString);
            }
        }

        public static string[,] LoadData(DateTime newDateTime)
        {
            string[,] values;
            string filename = "save//MainTable" + newDateTime.Year + "_" + newDateTime.Month + "_" + newDateTime.Day + ".txt";
            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    int columnsCount = br.ReadInt32();
                    int rowsCount = br.ReadInt32();
                    values = new string[rowsCount, columnsCount];

                    for (int i = 0; i < rowsCount; i++)
                    {
                        for (int j = 0; j < columnsCount - 1; j++)
                        {
                           values[i, j]  = br.ReadString();
                        }
                        br.ReadString();
                        byte R = br.ReadByte();
                        byte G = br.ReadByte();
                        byte B = br.ReadByte();
                        byte A = br.ReadByte();
                        if (R==255)
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
                using (BinaryWriter bw = new BinaryWriter(File.Open(filename, FileMode.Create))) { }
                
                logger.Error(e.ToString);
                
                return null;
            }
        }
    }
}