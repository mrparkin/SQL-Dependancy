using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTableDependancy
{
    class location_name
    {
        public string name { get; set; }
    }
    class active_RadioList
    {
        public string _callsign;
        public string _location;
        public string _dateTime;
   
        public active_RadioList(string callSign,string location,string dateTime)
        {
            this._callsign = callSign;
            this._location = location;
            this._dateTime = dateTime;
        }
    }
    class insideMustard_radioList
    {
        public string _callsign;
        public string _location;
        public string _dateTime;

        public insideMustard_radioList(string callSign, string location, string dateTime)
        {
            this._callsign = callSign;
            this._location = location;
            this._dateTime = dateTime;
        }
    }
    class outsideMustard_radioList
    {
        public string _callsign;
        public string _location;
        public string _dateTime;

        public outsideMustard_radioList(string callSign, string location, string dateTime)
        {
            this._callsign = callSign;
            this._location = location;
            this._dateTime = dateTime;
        }

    }
}
