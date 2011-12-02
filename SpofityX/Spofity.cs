using System;
using System.Drawing;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Threading;
namespace Spofity
{
    public class Spofity
    {
        public delegate void ActionEvent();
        public  event ActionEvent BeginLoading;
        public event ActionEvent FinishedLoading;
        private View view;
        public View View
        {
            get
            {
                return view;
            }
            set
            {
                view = value;
            }
        }
        private string uri;
        public string URI
        {
            get
            {
                return uri;
            }
            set
            {
                uri = value;
            }
        }
        public void Process()
        {
            WebClient WC = new WebClient();
           
            Stream D = null;
            if (uri.StartsWith("http://"))
            {
                D = WC.OpenRead(new Uri(uri));
            }
            else
            {
                D = new FileStream(uri, FileMode.Open, FileAccess.Read);
            }
          
            XmlSerializer DS = new XmlSerializer(typeof(View));
            this.View = (View)DS.Deserialize(D);
            
        }
        public Thread loadThread;
        public void LoadData()
        {
            BeginLoading();
            loadThread = new Thread(Process);
            loadThread.Start();
        }
        public Spofity(string uri)
        {

            this.uri = uri;
            Process();
            
            /*   XmlDocument SR = new XmlDocument();
               SR.Load(uri);   */
            

           
        }
    }
    [XmlRoot("view")]
    public class View
    {
        public View()
        {
            sections = new List<Section>();
       //     feeds = new List<Feed>();
        }
       
        private List<Section> sections;
        [XmlElement("section")]
        public List<Section> Sections
        {
            get
            {
                return sections;
            }
            set
            {
                sections = value;
            }
        }
        [XmlAttribute("name")]
        public string name;
        [XmlAttribute("url")]
        public string url;
       private List<Feed> feeds;
        [XmlElement("feed")]
        public List<Feed> Feeds
        {
            get
            {
                return feeds;
            }
            set
            {
                feeds = value;
            }
        }
    }

   public class Feed
    {
        private string name;
        private string url;
        [XmlAttribute("url")]
        public string URL
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }
        [XmlAttribute("name")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

    }
    public class Section
    {
        public  Section()
        {
            elements = new List<Element>();
     
        }
        private string name;

        [XmlAttribute("name")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private List<Element> elements;
        [XmlElement("element")]
        public List<Element> Elements
        {
            get
            {
                return elements;
            }
            set
            {
                elements = value;
            }
        }
      
    }
    /// <summary>
    /// This interface will make a control be hookable in a list, for example a list View.
    /// </summary>
    public interface ISpotifyEntry
    {
        bool Even
        {
            get;
            set;
        }
        Color OldColor
        {
            get;
            set;
        }
        Color OldForegroundColor
        {
            get;
            set;
        }
    }
    public class Attribute
    {
        public Attribute()
        {
        }
        public Attribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
        [XmlAttribute("name")]
        public string name;
        [XmlAttribute("value")]
        public string value;
    }
    
    public class Element
    {
       
        public Element(int x, int y, int width, int height)
        {
            attributes = new List<Attribute>();
            this.attributes.Add(new Attribute("x", x.ToString()));
            this.attributes.Add(new Attribute("y", y.ToString()));
            this.attributes.Add(new Attribute("width", width.ToString()));
            this.attributes.Add(new Attribute("height", height.ToString()));
        
        }
        public void Click(object sender,EventArgs e)
        {
            OnClick(sender,e);
        }
        private string feed;
    
        public string Feed
        {
            get
            {
                return feed;
            }
            set
            {
                feed = value;
            }
        }
        public Element()
        {
            attributes = new List<Attribute>();
            elements = new List<Element>();
        }
        public event EventHandler OnClick;
        private string type;
        [XmlAttribute("type")]
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        private List<Attribute> attributes;
        [XmlElement("attribute")]
        public List<Attribute> Attributes
        {
            get
            {
                return attributes;
            }
            set
            {
                attributes = value;
            }
        }
        public string GetAttribute(string name)
        {
            foreach (Attribute a in attributes)
            {
                if (a.name == name)
                {
                    return a.value;
                }
            }
            return "";
        }
        private List<Element> elements;
        [XmlElement("element")]
        public List<Element> Elements
        {
            get
            {
                return elements;
            }
            set
            {
                elements = value;
            }
        }
    }
}
