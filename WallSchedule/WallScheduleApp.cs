using Autodesk.Revit.DB;
using DesignAutomationFramework;
using Autodesk.Revit.ApplicationServices;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace WallSchedule
{
    public class WallScheduleApp : IExternalDBApplication
    {
        public ExternalDBApplicationResult OnStartup(Autodesk.Revit.ApplicationServices.ControlledApplication app)
        {
            DesignAutomationBridge.DesignAutomationReadyEvent += HandleDesignAutomationReadyEvent;
            return ExternalDBApplicationResult.Succeeded;
        }

        private void HandleDesignAutomationReadyEvent(object sender, DesignAutomationReadyEventArgs e)
        {
            LogTrace("Design Automation Ready event triggered...");
            e.Succeeded = true;
            ScheduleWalls(e.DesignAutomationData);
        }

        public ExternalDBApplicationResult OnShutdown(Autodesk.Revit.ApplicationServices.ControlledApplication app)
        {
            return ExternalDBApplicationResult.Succeeded;
        }

        public static void ScheduleWalls(DesignAutomationData data)
        {
            InputParams inputParameters = JsonSerializer.Deserialize<InputParams>(File.ReadAllText("params.json"));

            if (data == null) throw new ArgumentNullException(nameof(data));

            Application rvtApp = data.RevitApp;
            if (rvtApp == null) throw new InvalidDataException(nameof(rvtApp));

            string modelPath = data.FilePath;
            if (String.IsNullOrWhiteSpace(modelPath)) throw new InvalidDataException(nameof(modelPath));

            Document doc = data.RevitDoc;
            if (doc == null) throw new InvalidOperationException("Could not open document.");


            List<String> lines = new List<string>();
            string separator = ",";

            FilteredElementCollector col = new FilteredElementCollector(doc).OfClass(typeof(Wall));
            List<Wall> walls = col.WhereElementIsNotElementType().ToElements().Cast<Wall>().ToList();

            foreach (Wall wall in walls)
            {
                string[] line = new string[5]
                {
                    wall.Id.ToString(),
                    wall.Name.ToString(),
                    wall.WallType.Name.ToString(),
                    wall.Width.ToString(),
                    wall.StructuralUsage.ToString()
                };

                lines.Add(string.Join(separator, line));
            }

            LogTrace("Saving Schedule file...");
            File.WriteAllLines(inputParameters.ScheduleName, lines.ToArray());
            // File.WriteAllLines("WallSchedule.csv", lines.ToArray());

        }

        public class InputParams
        {
            public string ScheduleName { get; set; }
        }

        /// <summary>
        /// This will appear on the Design Automation output
        /// </summary>
        private static void LogTrace(string format, params object[] args) { System.Console.WriteLine(format, args); }
    }
}
