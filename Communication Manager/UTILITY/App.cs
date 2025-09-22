using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication_Manager
{
    /// <summary>
    /// Defines an application
    /// </summary>
    public class App
    {
        public string name { get; }
        public int ID { get; }
        public Dictionary<string, Frame.Field> dataFields = new Dictionary<string, Frame.Field>();  // format: {field name : Frame.Field object defining the field mapping}
         
        public App(string name, int ID, Dictionary<string, Frame.Field> dataFields) 
        {
            this.name = name;
            this.ID = ID;
            this.dataFields = dataFields;
        }
    }
}
