using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
