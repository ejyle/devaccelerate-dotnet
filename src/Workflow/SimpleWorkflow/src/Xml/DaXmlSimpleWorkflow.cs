// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

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
    [XmlTypeAttribute(AnonymousType = true, Namespace = "https://devaccelerate.github.io/schema/simple-workflow-v10.html")]
    [XmlRootAttribute(ElementName = "simpleWorkflow", Namespace = "https://devaccelerate.github.io/schema/simple-workflow-v10.html", IsNullable = false)]
    public class DaXmlSimpleWorkflow : DaXmlSimpleWorkflow<DaXmlSimpleWorkflowItem, DaXmlSimpleWorkflowItemSetting, DaXmlSimpleWorkflowItemParameterDefinition>
    { }

    [SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "https://devaccelerate.github.io/schema/simple-workflow-v10.html")]
    [XmlRootAttribute(ElementName= "simpleWorkflow", Namespace = "https://devaccelerate.github.io/schema/simple-workflow-v10.html", IsNullable = false)]
    public class DaXmlSimpleWorkflow<TSimpleWorkflowItem, TSimpleWorkflowItemSetting, TSimpleWorkflowItemParameterDefinition> : IDaSimpleWorkflow<TSimpleWorkflowItem, TSimpleWorkflowItemSetting, TSimpleWorkflowItemParameterDefinition>
        where TSimpleWorkflowItem : IDaSimpleWorkflowItem<TSimpleWorkflowItemSetting, TSimpleWorkflowItemParameterDefinition>
        where TSimpleWorkflowItemSetting : IDaSimpleWorkflowItemSetting
        where TSimpleWorkflowItemParameterDefinition : IDaSimpleWorkflowParameterDefinition
    {
        private TSimpleWorkflowItem[] _workflowItems;
        private string _name;
        private bool _abortOnError;

        [XmlElementAttribute(ElementName="workflowItems")]
        public TSimpleWorkflowItem[] WorkflowItems
        {
            get
            {
                return this._workflowItems;
            }
            set
            {
                this._workflowItems = value;
            }
        }

        [XmlAttributeAttribute(AttributeName="name")]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        [XmlAttributeAttribute(AttributeName = "abortOnError")]
        public bool AbortOnError
        {
            get
            {
                return this._abortOnError;
            }
            set
            {
                this._abortOnError = value;
            }
        }
    }
}
