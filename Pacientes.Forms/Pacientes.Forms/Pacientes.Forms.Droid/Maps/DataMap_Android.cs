using System;
using Pacientes.Forms.Droid;
using System.IO;
using Pacientes.Forms.Interfaces;
using Pacientes.Forms.Droid.Database;
using Xamarin.Forms;
using Android.Content.Res;
using Pacientes.Forms.Droid.Maps;
using Pacientes.Forms.Entities;
using Newtonsoft.Json;

[assembly: Dependency(typeof(DataMap_Android))]

namespace Pacientes.Forms.Droid.Maps
{
    public class DataMap_Android : IDataMap
    {

        public DataMap_Android()
        {

        }

        #region IDataMap implementation

        public DataMap GetData()
        {
            DataMap result = null;

            try
            {
                result = new DataMap();
                string json = File.ReadAllText(@"\Files\data.json");
                result = JsonConvert.DeserializeObject<DataMap>(json);               
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }

        #endregion

    }
}