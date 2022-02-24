using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTtest
{
    public class ProtobufUplink
    {
        /* chirpstack-application-server.toml dosyası
         * [application_server.integration] kısmında 
         * marshaler="json" olmalı
         */

        public string applicationID { get; set; }
        public string applicationName { get; set; }
        public string deviceName { get; set; }
        public string devEUI { get; set; }
        public List<rxInfoClass> rxInfo { get; set; }
        public txInfoClass txInfo { get; set; }
        public bool adr { get; set; }
        public double dr { get; set; }

        public double fCnt { get; set; }
        public double fPort { get; set; }
        public string data { get; set; }
        public string objectJSON { get; set; }
        public tagsClass tags { get; set; }
        public string strDate { get; set; }
    }
    public class rxInfoClass
    {
        public string gatewayID { get; set; }
        public string time { get; set; }
        public string timeSinceGPSEpoch { get; set; }
        public double rssi { get; set; }
        public double loRaSNR { get; set; }
        public double channel { get; set; }
        public double rfChain { get; set; }
        public double board { get; set; }
        public double antenna { get; set; }
        public locationClass location { get; set; }
        public string fineTimestampType { get; set; }
        public string context { get; set; }
        public string uplinkID { get; set; }

    }

    public class locationClass
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double altitude { get; set; }
    }

    public class txInfoClass
    {
        public int frequency { get; set; }
        public string modulation { get; set; }
        public loRaModulationInfoClass loRaModulationInfo { get; set; }
    }

    public class loRaModulationInfoClass
    {
        public int bandwidth { get; set; }
        public int spreadingFactor { get; set; }
        public string codeRate { get; set; }
        public bool polarizationInversion { get; set; }

    }

    public class tagsClass
    {
        public string key { get; set; }
    }
}
