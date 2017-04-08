using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YW.Models;

namespace YW.Service
{
   public class ImportService
    {
        public List<StationData> FindStationData()
        {
            List<StationData> stations = new List<StationData>();
            var xml = XElement.Load(@"d:\檔案\多媒體系統\OTH01728.xml");
            var StationsData = xml.Descendants("Data").ToList();
            StationsData
                .Where(x => !x.IsEmpty).ToList()
                .ForEach(stationData =>
                {
                    var Siteid = stationData.Element("Siteid").Value.Trim();
                    var Site = stationData.Element("Site").Value.Trim();
                    var Address = stationData.Element("Address").Value.Trim();
                    var Phonenumber = stationData.Element("Phonenumber").Value.Trim();

                    StationData Data = new StationData();
                    Data.Siteid = Siteid;
                    Data.Site = Site;
                    Data.Address = Address;
                    Data.Phonenumber = Phonenumber;
                    stations.Add(Data);
                });
            return stations;
        }
    }
}
