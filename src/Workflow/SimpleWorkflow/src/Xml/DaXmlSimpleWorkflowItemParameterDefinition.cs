using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ejyle.DevAccelerate.SimpleWorkflow.Xml
{
    [SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(TypeName = "expectedParameters", AnonymousType = true, Namespace = "https://devaccelerate.github.io/schema/simple-workflow-v10.html")]
    public class DaXmlSimpleWorkflowItemParameterDefinition : IDaSimpleWorkflowParameterDefinition
    {
        [XmlAttributeAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttributeAttribute(AttributeName = "parameterType")]
        public string ParameterType { get; set; }

        [XmlAttributeAttribute(AttributeName = "required")]
        public bool Required { get; set; }
    }
}
