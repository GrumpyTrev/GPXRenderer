﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 
namespace GPXRenderer {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.topografix.com/GPX/1/1")]
    [System.Xml.Serialization.XmlRootAttribute("gpx", Namespace="http://www.topografix.com/GPX/1/1", IsNullable=false)]
    public partial class gpxType {
        
        private rteType[] rteField;
        
        private string versionField;
        
        private string creatorField;
        
        public gpxType() {
            this.versionField = "1.1";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("rte")]
        public rteType[] rte {
            get {
                return this.rteField;
            }
            set {
                this.rteField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string creator {
            get {
                return this.creatorField;
            }
            set {
                this.creatorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.topografix.com/GPX/1/1")]
    public partial class rteType {
        
        private string nameField;
        
        private string descField;
        
        private wptType[] rteptField;
        
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string desc {
            get {
                return this.descField;
            }
            set {
                this.descField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("rtept")]
        public wptType[] rtept {
            get {
                return this.rteptField;
            }
            set {
                this.rteptField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.topografix.com/GPX/1/1")]
    public partial class wptType {
        
        private decimal latField;
        
        private decimal lonField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal lat {
            get {
                return this.latField;
            }
            set {
                this.latField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal lon {
            get {
                return this.lonField;
            }
            set {
                this.lonField = value;
            }
        }
    }
}
