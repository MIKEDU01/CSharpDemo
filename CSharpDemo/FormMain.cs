using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpDemo
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 写Excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_01_Click(object sender, EventArgs e)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook = application.Workbooks.Create(2);
                IWorksheet worksheet = workbook.Worksheets[0];

                worksheet.Name = "mySheet1";

                worksheet.Range["A1:C2"].Merge();
                worksheet.Range["A1"].Text = "123";
                worksheet.Range["A1"].CellStyle.Font.FontName = "微软雅黑";
                worksheet.Range["A1"].CellStyle.Font.Size = 16;
                worksheet.Range["A1"].CellStyle.Font.RGBColor = Color.Red;

                worksheet.Range["A1"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                worksheet.Range["A1"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;

                worksheet.Range["A1:C3"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
                worksheet.Range["A1:C3"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].Color = ExcelKnownColors.Blue;

                worksheet.Range["A1:C3"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
                worksheet.Range["A1:C3"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].Color = ExcelKnownColors.Lime;

                worksheet.Range["A1:C3"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
                worksheet.Range["A1:C3"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].Color = ExcelKnownColors.Red;

                worksheet.Range["A1:C3"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Double;
                worksheet.Range["A1:C3"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].Color = ExcelKnownColors.Green;

                worksheet.Activate();
                workbook.SaveAs("Book1.xlsx");
            }
        }

        private void BTN_02_Click(object sender, EventArgs e)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook = application.Workbooks.Create(1);//.Open("Chart.xlsx");//.Create(1);
                IWorksheet sheet = workbook.Worksheets[0];

                Dictionary<int, Color> dict = new Dictionary<int, Color>();
                dict.Add(1, Color.Red);
                dict.Add(2, Color.Green);
                dict.Add(3, Color.Blue);

                object[] yValues = new object[] { 1, 2, 3, 2, 3, 1 };
                object[] xValues = new object[] { 1, 2, 3, 2, 3, 1 };

                //Adding series and values
                IChartShape chart = sheet.Charts.Add();
                IChartSerie serie = chart.Series.Add(ExcelChartType.Doughnut);

                //Enters the X and Y values directly
                serie.EnteredDirectlyValues = yValues;
                serie.EnteredDirectlyCategoryLabels = xValues;

                serie.DataPoints[0].DataFormat.Fill.ForeColor = dict[(int)xValues[0]];
                serie.DataPoints[1].DataFormat.Fill.ForeColor = dict[(int)xValues[1]];
                serie.DataPoints[2].DataFormat.Fill.ForeColor = dict[(int)xValues[2]];
                serie.DataPoints[3].DataFormat.Fill.ForeColor = dict[(int)xValues[3]];
                serie.DataPoints[4].DataFormat.Fill.ForeColor = dict[(int)xValues[4]];

                workbook.SaveAs("Chart.xlsx");
            }
        }

        private void BTN_03_Click(object sender, EventArgs e)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet sheet = workbook.Worksheets[0];

                const int LEN = 20;

                object[] xValues = new object[LEN];
                object[] yValues1 = new object[LEN];
                object[] yValues2 = new object[LEN];

                Random random = new Random();
                for (int i = 0; i < LEN; i++)
                {
                    xValues[i] = i + 1;
                    yValues1[i] = random.Next(100);
                    yValues2[i] = random.Next(100);
                }

                //Adding series and values
                IChartShape chart = sheet.Charts.Add();

                chart.ChartTitle = "测试图表";
                chart.ChartTitleArea.Bold = true;
                chart.ChartTitleArea.RGBColor = Color.Blue;

                // 图标在单元格上的位置
                chart.LeftColumn = 2;
                chart.RightColumn = 10;
                chart.TopRow = 2;
                chart.BottomRow = 15;

                // Legend水平放在底部
                chart.Legend.Position = ExcelLegendPosition.Bottom;
                chart.Legend.IsVerticalLegend = false;
                chart.Legend.TextArea.FontName = "微软雅黑";
                chart.Legend.TextArea.Size = 8;

                IChartSerie serie1 = chart.Series.Add(ExcelChartType.Line);
                IChartSerie serie2 = chart.Series.Add(ExcelChartType.Scatter_SmoothedLine);

                //Enters the X and Y values directly
                serie1.EnteredDirectlyCategoryLabels = xValues;
                serie1.EnteredDirectlyValues = yValues1;
                serie1.Name = "曲线1";

                serie2.EnteredDirectlyCategoryLabels = xValues;
                serie2.EnteredDirectlyValues = yValues2;
                serie2.Name = "曲线2";

                workbook.SaveAs("Chart2.xlsx");
            }
        }

        private void BTN_04_Click(object sender, EventArgs e)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;

                IWorkbook workbook = application.Workbooks.Create(3);
                for (int k = 0; k < 3; k++)
                {
                    IWorksheet sheet = workbook.Worksheets[k];

                    for (int row = 1; row <= 15; row++)
                    {
                        for (int col = 1; col <= 10; col++)
                        {
                            sheet.Range[row, col].Text = (row * col).ToString();
                            sheet.Range[row, col].NumberFormat = "0.00";
                        }
                    }

                    sheet.PageSetup.LeftHeader = "&D";
                    sheet.PageSetup.RightHeader = @"&B&16&""微软雅黑""&U" + sheet.Name;
                    
                    sheet.PageSetup.LeftFooter = "XXX公司";
                    sheet.PageSetup.RightFooter = "&P/&N";
                }

                workbook.SaveAs("Chart3.xlsx");

                //Open the Excel document to Convert
                ExcelToPdfConverter converter = new ExcelToPdfConverter(workbook);

                //Initialize PDF document
                PdfDocument pdfDocument = new PdfDocument();

                //Convert Excel document into PDF document
                pdfDocument = converter.Convert();

                //Save the PDF file
                pdfDocument.Save("Chart3.pdf");
            }
        }

        private void BTN_05_Click(object sender, EventArgs e)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;

                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet sheet = workbook.Worksheets[0];

                WriteData(sheet);

                workbook.SaveAs("Chart5.xlsx");
            }
        }

        public void WriteData(IWorksheet worksheet)
        {
            if (worksheet == null)
            {
                throw new ArgumentNullException(nameof(worksheet));
            }

            worksheet.Range[$"A1:G1"].ColumnWidth = 12;
            worksheet.Range[$"A3:A9"].RowHeight = 25;            

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("轮胎类型", "C1");
            dict.Add("轮胎直径(mm)", "630");
            dict.Add("轮胎周长(mm)", "1979.203");
            dict.Add("断面宽度(mm)", "205");
            dict.Add("节距列数", "5");
            dict.Add("优化前", "1600");
            dict.Add("优化后", "630");

            int rowIndex = 3;
            foreach (var obj in dict)
            {
                worksheet.Range[$"A{rowIndex}"].Text = obj.Key;
                worksheet.Range[$"A{rowIndex}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                worksheet.Range[$"A{rowIndex}"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
                worksheet.Range[$"A{rowIndex}"].CellStyle.Font.FontName = "微软雅黑";
                worksheet.Range[$"A{rowIndex}"].CellStyle.Font.Size = 12;

                worksheet.Range[$"B{rowIndex}"].Text = obj.Key;
                worksheet.Range[$"B{rowIndex}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                worksheet.Range[$"B{rowIndex}"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
                worksheet.Range[$"B{rowIndex}"].CellStyle.Font.FontName = "微软雅黑";
                worksheet.Range[$"B{rowIndex}"].CellStyle.Font.Size = 12;
                rowIndex++;
            }

            // 雷达图
            worksheet.Range[$"A17:G26"].Merge();
            worksheet.Range[$"A17:G26"].RowHeight = 20;

            //Adding series and values
            IChartShape chart = worksheet.Charts.Add();

            //chart.ChartTitle = "测试图表";
            //chart.ChartTitleArea.Bold = true;
            //chart.ChartTitleArea.RGBColor = Color.Blue;

            // 图标在单元格上的位置
            chart.LeftColumn = 1;
            chart.RightColumn = 8;
            chart.TopRow = 17;
            chart.BottomRow = 30;
            chart.ChartArea.Border.LinePattern = ExcelChartLinePattern.None;

            // Legend水平放在底部
            chart.Legend.Position = ExcelLegendPosition.Bottom;
            chart.Legend.IsVerticalLegend = false;
            chart.Legend.TextArea.FontName = "微软雅黑";
            chart.Legend.TextArea.Size = 8;
            chart.Legend.TextArea.Bold = true;

            IChartSerie serie1 = chart.Series.Add(ExcelChartType.Radar);
            IChartSerie serie2 = chart.Series.Add(ExcelChartType.Radar);

            object[] labels = new object[] { "噪声", "饱和度", "刚度", "PRAT", "Groove Wander", "Snow Traction" };
            object[] yValues1 = new object[] { 10, 20, 30, 40, 50, 60 };
            object[] yValues2 = new object[] { 40, 50, 70, 10, 80, 90 };

            serie1.EnteredDirectlyCategoryLabels = labels;            
            serie1.EnteredDirectlyValues = yValues1;
            serie1.Name = "设计目标";

            serie2.EnteredDirectlyCategoryLabels = labels;
            serie2.EnteredDirectlyValues = yValues2;
            serie2.Name = "分析结果";

            // 浦林成山（山东）轮胎有限公司
            rowIndex = 32;
            worksheet.Range[$"B{rowIndex}:F{rowIndex}"].Merge();
            worksheet.Range[$"B{rowIndex}:F{rowIndex}"].Text = "浦林成山（山东）轮胎有限公司";
            worksheet.Range[$"B{rowIndex}:F{rowIndex}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            worksheet.Range[$"B{rowIndex}:F{rowIndex}"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
            worksheet.Range[$"B{rowIndex}:F{rowIndex}"].CellStyle.Font.FontName = "微软雅黑";
            worksheet.Range[$"B{rowIndex}:F{rowIndex}"].CellStyle.Font.Size = 10;
            worksheet.Range[$"B{rowIndex}:F{rowIndex}"].CellStyle.Font.Bold = true;
        }
    }
}
