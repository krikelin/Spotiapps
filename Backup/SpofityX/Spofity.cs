using System;
using System.Collections.Generic;
using System.Linq;
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
    public class Attribute
    {
        [XmlAttribute("name")]
        public string name;
        [XmlAttribute("value")]
        public string value;
    }
    public class Element
    {
        public Element()
        {
            attributes = new List<Attribute>();
            elements = new List<Element>();
        }
        
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
