using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;

namespace ExcelLoadTestReport
{


    public class ReportDefaults : ConfigurationSection
    {
        [ConfigurationProperty("reports", IsRequired = false)]
        [ConfigurationCollection(typeof(report), AddItemName = "report")]
        public reports reports
        {
            get
            {
                return (reports)this["reports"];
            }
            set
            {
                this["reports"] = value;
            }
        }

        [ConfigurationProperty("reportTypes", IsRequired = false)]
        [ConfigurationCollection(typeof(reportType), AddItemName = "reportType")]
        public reportTypes reportTypes
        {
            get
            {
                return (reportTypes)this["reportTypes"];
            }
            set
            {
                this["reportTypes"] = value;
            }
        }
    }

    public class reports : ConfigurationElementCollection
    {
        public report this[int index]
        {
            get
            {
                return (report)base.BaseGet(index);
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);

                }
                this.BaseAdd(index, value);
            }
        }

        public new report this[string responseString]
        {
            get { return (report)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new report();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return string.Format("{0}_{1}", ((report)element).ReportName, ((report)element).reportTypeName);
        }

    }

    public class reportType : ConfigurationElement
    {
        [TypeConverter(typeof(TypeNameConverter))]
        [ConfigurationProperty("type", IsRequired  = true)]
        public Type type
        {
            get
            {
                return (Type)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }

        [ConfigurationProperty("name", IsKey = true, IsRequired  = true)]
        public string reportTypeName
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
    }

    public class reportTypes : ConfigurationElementCollection
    {
        public reportType this[int index]
        {
            get
            {
                return (reportType)base.BaseGet(index);
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);

                }
                this.BaseAdd(index, value);
            }
        }

        public new reportType this[string responseString]
        {
            get { return (reportType)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new reportType();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return string.Format("{0}", ((reportType)element).reportTypeName);
        }
    }

    public class report : ConfigurationElement
    {
        [ConfigurationProperty("reportName", IsKey = true, IsRequired = true)]
        public string ReportName
        {
            get
            {
                return (string)this["reportName"];
            }
            set
            {
                this["reportName"] = value;
            }
        }


        [ConfigurationProperty("reportTypeName", IsRequired = true)]
        public string reportTypeName
        {
            get
            {
                return (string)this["reportTypeName"];
            }
            set
            {
                this["reportTypeName"] = value;
            }
        }

        [ConfigurationProperty("createChartData", DefaultValue = true)]
        public bool CreateChart
        {
            get
            {
                return (bool)this["createChartData"];
            }
            set
            {
                this["createChartData"] = value;
            }
        }
        [ConfigurationProperty("rawDataCopy", DefaultValue = true)]
        public bool GenerateRawDataSheets
        {
            get
            {
                return (bool)this["rawDataCopy"];
            }
            set
            {
                this["rawDataCopy"] = value;
            }
        }

        [ConfigurationProperty("counters", IsRequired = false)]
        [ConfigurationCollection(typeof(counter), AddItemName = "counter")]
        public counters Counters
        {
            get
            {
                return (counters)this["counters"];
            }
            set
            {
                this["counters"] = value;
            }
        }

        [ConfigurationProperty("description", IsRequired = false)]
        public string Description
        {
            get
            {
                return (string)this["description"];
            }
            set
            {
                this["description"] = value;
            }
        }
    }

    public class counters : ConfigurationElementCollection
    {
        public counter this[int index]
        {
            get
            {
                return (counter)base.BaseGet(index);
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                    
                }
                this.BaseAdd(index, value);
            }
        }

        public new counter this[string responseString]
        {
            get { return (counter)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new counter();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return string.Format("{0}_{1}", ((counter)element).CounterCategory, ((counter)element).CounterName);
        }
    }

    public class counter : ConfigurationElement
    {
        
        [ConfigurationProperty("counterCategory", IsRequired = true, IsKey = true)]
        public string CounterCategory
        {
            get
            {
                return (string)this["counterCategory"];
            }
            set
            {
                this["counterCategory"] = value;
            }
        }
        [ConfigurationProperty("counterName", IsKey = true, DefaultValue = null)]
        public string CounterName
        {
            get
            {
                return (string)this["counterName"];
            }
            set
            {
                this["counterName"] = value;
            }
        }
        [ConfigurationProperty("counterInstance", DefaultValue = null)]
        public string CounterInstance
        {
            get
            {
                return (string)this["counterInstance"];
            }
            set
            {
                this["counterInstance"] = value;
            }
        }
        
        [ConfigurationProperty("filterOutLoadTestRig", DefaultValue = true)]
        public bool FilterOutLoadTestRig
        {
            get
            {
                return (bool)this["filterOutLoadTestRig"];
            }
            set
            {
                this["filterOutLoadTestRig"] = value;
            }
        }
        
    }
}
