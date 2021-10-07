﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excelusing = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Excel
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();
        List<Flat> Flats;
        Excelusing.Application xlApp;
        Excelusing.Workbook xlWB;
        Excelusing.Worksheet xlSheet;

        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
          
        }
        void LoadData()
        {
            Flats = context.Flats.ToList();
        }

        void CreateExcel()
        {
            try
            {
                xlApp = new Excelusing.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;
                CreateTable();
                xlApp.Visible = true;
                xlApp.UserControl = true;

            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;

            }
        } 
        string[] headers = new string[]
                {
                 "Kód",
                 "Eladó",
                 "Oldal",
                 "Kerület",
                 "Lift",
                 "Szobák száma",
                 "Alapterület (m2)",
                 "Ár (mFt)",
                 "Négyzetméter ár (Ft/m2)"
                };
        void CreateTable()
        {
          
            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1,i+1] = headers[i];
            }
            object[,] values = new object[Flats.Count, headers.Length];
            int counter = 0;
            foreach (Flat f in Flats)
            {
                values[counter, 0] = f.Code;
                values[counter, 1] = f.Vendor;
                values[counter,2] = f.Side;
                values[counter,3] = f.District;
                if (f.Elevator)
                {
                    values[counter, 4] = "Van";
                }
                else
                {
                    values[counter, 4] = "Nincs";
                }
                values[counter,5] = f.NumberOfRooms;
                values[counter,6] = f.FloorArea;
                values[counter,7] = f.Price;
                values[counter, 8] = $"={GetCell(counter+2, 8)}/{GetCell(counter+2, 7)}*{1000000}";
                counter++;
            }
            xlSheet.get_Range(
                GetCell(2, 1),
                GetCell(1+values.GetLength(0),values.GetLength(1))).Value2 = values;
            FormatTable();


        }
        private string GetCell(int x, int y) 
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;
            while (dividend>0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);

            }
            ExcelCoordinate += x.ToString();
            return ExcelCoordinate;
        }
        void FormatTable()
        {
            Excelusing.Range headerRange = xlSheet.get_Range(GetCell(1,1), GetCell(1,headers.Length));
            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = Excelusing.XlVAlign.xlVAlignCenter;
            headerRange.HorizontalAlignment = Excelusing.XlHAlign.xlHAlignCenter;
            headerRange.EntireColumn.AutoFit();
            headerRange.RowHeight = 40;
            headerRange.Interior.Color = Color.LightBlue;
            headerRange.BorderAround2(Excelusing.XlLineStyle.xlContinuous, Excelusing.XlBorderWeight.xlThick);


            Excelusing.Range wholeTable = xlSheet.get_Range(GetCell(1, 1), GetCell(Flats.Count+1, headers.Length));
            wholeTable.BorderAround2(Excelusing.XlLineStyle.xlContinuous, Excelusing.XlBorderWeight.xlThick);

            Excelusing.Range FirstCol = xlSheet.get_Range(GetCell(2, 1), GetCell(Flats.Count+1, 1));
            FirstCol.Font.Bold = true;
            FirstCol.Interior.Color = Color.LightYellow;


            Excelusing.Range LastCol = xlSheet.get_Range(GetCell(2, headers.Length), GetCell(Flats.Count+1, headers.Length));
            LastCol.Interior.Color = Color.LightGreen;
            



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
