using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueStacksConfigEditer
{
    public class ChannelApps
    {
        private string title;
        private string pkgname;
        private string featureIconUrl;
        private string iconUrl;
        private string bannerUrl;
        private string channelIds;
        private string rank;
        private string description;
        private string rating;
        private string pkgver;
        private string apkUrl;
        private string screenshots;
        private string developer;

        public string TITLE
        {
            get { return title; }
            set { title = value; }
        }

        public string PKGNAME
        {
            get { return pkgname; }
            set { pkgname = value; }
        }

        public string FEATUREICONURL
        {
            get { return featureIconUrl; }
            set { featureIconUrl = value; }
        }

        public string ICONURL
        {
            get { return iconUrl; }
            set { iconUrl = value; }
        }

        public string BANNERURL
        {
            get { return bannerUrl; }
            set { bannerUrl = value; }
        }

        public string CHANNELIDS
        {
            get { return channelIds; }
            set { channelIds = value; }
        }

        public string RANK
        {
            get { return rank; }
            set { rank = value; }
        }

        public string DESCRIPTION
        {
            get { return description; }
            set { description = value; }
        }

        public string RATING
        {
            get { return rating; }
            set { rating = value; }
        }

        public string PKGVER
        {
            get { return pkgver; }
            set { pkgver = value; }
        }

        public string APKURL
        {
            get { return apkUrl; }
            set { apkUrl = value; }
        }

        public string SCREENSHOTS
        {
            get { return screenshots; }
            set { screenshots = value; }
        }

        public string DEVELOPER
        {
            get { return developer; }
            set { developer = value; }
        }
    }
    
    public class Channelname
    {
        private string id;
        private string name;
        private string type;
        private string key;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        public string TYPE
        {
            get { return type; }
            set { type = value; }
        }

        public string KEY
        {
            get { return key; }
            set { key = value; }
        }
    }
}
