using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YW.Models;
using System.IO;

namespace YW
{
    class Program
    {
        static void setDBFilePath()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relative = @"..\..\App_Data\";
            string absolute = Path.GetFullPath(Path.Combine(baseDirectory, relative));
            AppDomain.CurrentDomain.SetData("DataDirectory", absolute);
        }
        static void Main(string[] args)
        {
            setDBFilePath();
            var import = new YW.Service.ImportService();
            var db = new YW.Repository.StationRepsitory();
            var stations = import.FindStationData(); //xml
            //stations
            //    .ToList().ForEach(station =>
            //{
            //    db.Create(stations);
            //});
            //var stations = db.FindAllStations();
            ShowStationData(stations);
            Console.ReadLine();
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
