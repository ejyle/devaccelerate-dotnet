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
    [XmlTypeAttribute(AnonymousType = true, Namespace = "https://devaccelerate.github.io/schema/simple-workflow/v1.0")]
    [XmlRootAttribute(ElementName = "simpleWorkflow", Namespace = "https://devaccelerate.github.io/schema/simple-workflow/v1.0", IsNullable = false)]
    public class DaXmlSimpleWorkflow : DaXmlSimpleWorkflow<DaXmlSimpleWorkflowItem, DaXmlSimpleWorkflowItemSetting>
    { }

    [SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "https://devaccelerate.github.io/schema/simple-workflow/v1.0")]
    [XmlRootAttribute(ElementName= "simpleWorkflow", Namespace = "https://devaccelerate.github.io/schema/simple-workflow/v1.0", IsNullable = false)]
    public class DaXmlSimpleWorkflow<TSimpleWorkflowItem, TSimpleWorkflowItemSetting> : IDaSimpleWorkflow<TSimpleWorkflowItem, TSimpleWorkflowItemSetting>
        where TSimpleWorkflowItem : IDaSimpleWorkflowItem<TSimpleWorkflowItemSetting>
        where TSimpleWorkflowItemSetting : IDaSimpleWorkflowItemSetting
    {
        private TSimpleWorkflowItem[] workflowItemField;

        private string nameField;

        private bool abortOnErrorField;

        [XmlElementAttribute(ElementName="workflowItems")]
        public TSimpleWorkflowItem[] WorkflowItems
        {
            get
            {
                return this.workflowItemField;
            }
            set
            {
                this.workflowItemField = value;
            }
        }

        [XmlAttributeAttribute(AttributeName="name")]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [XmlAttributeAttribute(AttributeName = "abortOnError")]
        public bool AbortOnError
        {
            get
            {
                return this.abortOnErrorField;
            }
            set
            {
                this.abortOnErrorField = value;
            }
        }
    }
}
