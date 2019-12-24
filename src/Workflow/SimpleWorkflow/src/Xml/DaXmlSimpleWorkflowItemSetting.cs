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

namespace Ejyle.DevAccelerate.Workflow.SimpleWorkflow.Xml
{
    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "https://devaccelerate.github.io/schema/simple-workflow-v10.html")]
    public class DaXmlSimpleWorkflowItemSetting : IDaSimpleWorkflowItemSetting
    {
        private string _name;
        private string _value;

        [XmlAttributeAttribute(AttributeName = "name")]
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

        [XmlAttributeAttribute(AttributeName = "value")]
        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
}
