using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chiayi_YW
{
    class Program
    {
        static void Main(string[] args)
        {
            var station = FindStationData();
            ShowStationData(station);
            Console.ReadLine();
        }

        public static List<StationData> FindStationData()
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
        public static void ShowStationData(List<StationData> stations)
        {
            Console.WriteLine(string.Format("共收到{0}筆監測站的資料", stations.Count));
            stations.ForEach(x =>
            {
                Console.WriteLine(string.Format("站點名稱：{0}，地址:{1}", x.Site, x.Address));
            });
        }
    }
}
