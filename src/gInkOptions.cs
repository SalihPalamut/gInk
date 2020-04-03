using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Ink;

namespace gInk
{
    class gInkOptions : IDisposable
    {
        public void Dispose()
        {

        }
       
        [JsonConstructor]
        public gInkOptions(bool a = true)
        {

        }

        public gInkOptions()
        {
            if (!File.Exists(SavePath))
            {
                Save();
            }
            using (StreamReader streamReader = new StreamReader(SavePath))
            using (gInkOptions options = JsonConvert.DeserializeObject<gInkOptions>(streamReader.ReadToEnd()))
            {
                foreach (var property in typeof(gInkOptions).GetProperties())
                {
                    try
                    {
                        property.SetValue(this, property.GetValue(options));
                    }
                    catch { }
                }
            }
        }
        public void Save()
        {
            lock (this)
            {
                using (FileStream fileStream = new FileStream(SavePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                using (JsonTextWriter jsonWriter = new JsonTextWriter(streamWriter))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.ContractResolver = new WritablePropertiesOnlyResolver();
                    serializer.Converters.Add(new StringEnumConverter());
                    serializer.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(jsonWriter, this);
                    jsonWriter.Flush();
                }
            }
        }
        internal class WritablePropertiesOnlyResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
                return props.Where(p => p.Writable).ToList();
            }
        }

        private string SavePath = Directory.GetCurrentDirectory() + @"\Settings\gInk.json";
        public const int MaxPenCount = 10;
        public bool EraserEnabled { get; set; } = true;
        public bool PointerEnabled { get; set; } = true;
        public bool PenWidthEnabled { get; set; } = true;
        public bool SnapEnabled { get; set; } = true;
        public bool UndoEnabled { get; set; } = true;
        public bool ClearEnabled { get; set; } = true;
        public bool PanEnabled { get; set; } = true;
        public bool AllowDraggingToolbar { get; set; } = true;
        public bool AllowHotkeyInPointerMode { get; set; } = true;
        public bool InkVisibleEnabled { get; set; } = true;

        public bool[] PenEnabled { get; set; } = new bool[MaxPenCount];

        public string SnapshotBasePath { get; set; } = "%USERPROFILE%/Pictures/gInk/";

        public int CanvasCursor { get; set; } = 0;

        public double ToolbarSize { get; set; } = 0.04;//%3 ~ 10

        public DrawingAttributes[] PenAttr { get; set; } = new DrawingAttributes[MaxPenCount];

        public Hotkey Hotkey_Global { get; set; } = new Hotkey();
        public Hotkey[] Hotkey_Pens { get; set; } = new Hotkey[10];
        public Hotkey Hotkey_Eraser { get; set; } = new Hotkey();
        public Hotkey Hotkey_InkVisible { get; set; } = new Hotkey();
        public Hotkey Hotkey_Pointer { get; set; } = new Hotkey();
        public Hotkey Hotkey_Pan { get; set; } = new Hotkey();
        public Hotkey Hotkey_Undo { get; set; } = new Hotkey();
        public Hotkey Hotkey_Redo { get; set; } = new Hotkey();
        public Hotkey Hotkey_Snap { get; set; } = new Hotkey();
        public Hotkey Hotkey_Clear { get; set; } = new Hotkey();

    }
}